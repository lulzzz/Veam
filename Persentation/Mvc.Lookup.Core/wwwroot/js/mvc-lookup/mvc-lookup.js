/*!
 * Mvc.Lookup 4.2.0
 * https://github.com/NonFactors/MVC6.Lookup
 *
 * Copyright © NonFactors
 *
 * Licensed under the terms of the MIT License
 * http://www.opensource.org/licenses/mit-license.php
 */
var MvcLookupFilter = (function () {
    function MvcLookupFilter(lookup) {
        var filter = this;
        var data = lookup.group.dataset;

        filter.offset = 0;
        filter.lookup = lookup;
        filter.sort = data.sort || '';
        filter.order = data.order || '';
        filter.search = data.search || '';
        filter.rows = parseInt(data.rows) || 20;
        filter.additional = (data.filters || '').split(',').filter(Boolean);
    }

    MvcLookupFilter.prototype = {
        formUrl: function (search) {
            var encode = encodeURIComponent;
            var url = this.lookup.url.split('?')[0];
            var urlQuery = this.lookup.url.split('?')[1];
            var filter = this.lookup.extend({ ids: [], checkIds: [], selected: [] }, this, search);
            var query = '?' + (urlQuery ? urlQuery + '&' : '') + 'search=' + encode(filter.search);

            filter.additional.forEach(function (name) {
                [].forEach.call(document.querySelectorAll('[name="' + name + '"]'), function (filter) {
                    query += '&' + encode(name) + '=' + encode(filter.value);
                });
            });

            filter.selected.forEach(function (selected) {
                query += '&selected=' + encode(selected.Id);
            });

            filter.checkIds.forEach(function (id) {
                query += '&checkIds=' + encode(id.value);
            });

            filter.ids.forEach(function (id) {
                query += '&ids=' + encode(id.value);
            });

            query += '&sort=' + encode(filter.sort) +
                '&order=' + encode(filter.order) +
                '&offset=' + encode(filter.offset) +
                '&rows=' + encode(filter.rows) +
                '&_=' + Date.now();

            return url + query;
        }
    };

    return MvcLookupFilter;
}());
var MvcLookupDialog = (function () {
    function MvcLookupDialog(lookup) {
        var dialog = this;
        var element = document.getElementById(lookup.group.dataset.dialog || 'MvcLookupDialog');

        dialog.lookup = lookup;
        dialog.element = element;
        dialog.title = lookup.group.dataset.title || '';
        dialog.options = { preserveSearch: true, rows: { min: 1, max: 99 }, openDelay: 100 };

        dialog.overlay = new MvcLookupOverlay(this);
        dialog.table = element.querySelector('table');
        dialog.tableHead = element.querySelector('thead');
        dialog.tableBody = element.querySelector('tbody');
        dialog.rows = element.querySelector('.mvc-lookup-rows');
        dialog.header = element.querySelector('.mvc-lookup-title');
        dialog.search = element.querySelector('.mvc-lookup-search');
        dialog.footer = element.querySelector('.mvc-lookup-load-more');
        dialog.selector = element.querySelector('.mvc-lookup-selector');
        dialog.closeButton = element.querySelector('.mvc-lookup-close');
        dialog.error = element.querySelector('.mvc-lookup-dialog-error');
        dialog.loader = element.querySelector('.mvc-lookup-dialog-loader');
    }

    MvcLookupDialog.prototype = {
        open: function () {
            var dialog = this;
            var filter = dialog.lookup.filter;
            MvcLookupDialog.prototype.current = dialog;

            filter.offset = 0;
            filter.search = dialog.options.preserveSearch ? filter.search : '';

            dialog.error.style.display = 'none';
            dialog.loader.style.display = 'none';
            dialog.header.innerText = dialog.title;
            dialog.selected = dialog.lookup.selected.slice();
            dialog.rows.value = dialog.limitRows(filter.rows);
            dialog.error.innerHTML = dialog.lookup.lang.error;
            dialog.footer.innerText = dialog.lookup.lang.more;
            dialog.search.placeholder = dialog.lookup.lang.search;
            dialog.selector.style.display = dialog.lookup.multi ? '' : 'none';
            dialog.selector.innerText = dialog.lookup.lang.select.replace('{0}', dialog.lookup.selected.length);

            dialog.bind();
            dialog.refresh();
            dialog.search.value = filter.search;

            setTimeout(function () {
                if (dialog.isLoading) {
                    dialog.loader.style.opacity = 1;
                    dialog.loader.style.display = '';
                }

                dialog.overlay.show();
                dialog.search.focus();
            }, dialog.options.openDelay);
        },
        close: function () {
            var dialog = MvcLookupDialog.prototype.current;
            dialog.lookup.group.classList.remove('mvc-lookup-error');

            dialog.lookup.select(dialog.selected, true);
            dialog.lookup.stopLoading();
            dialog.overlay.hide();

            if (dialog.lookup.browser) {
                dialog.lookup.browser.focus();
            }

            MvcLookupDialog.prototype.current = null;
        },
        refresh: function () {
            var dialog = this;
            dialog.isLoading = true;
            dialog.error.style.opacity = 0;
            dialog.error.style.display = '';
            dialog.loader.style.display = '';
            var loading = setTimeout(function () {
                dialog.loader.style.opacity = 1;
            }, dialog.lookup.options.loadingDelay);

            dialog.lookup.startLoading({ selected: dialog.selected, rows: dialog.lookup.filter.rows + 1 }, function (data) {
                dialog.isLoading = false;
                clearTimeout(loading);
                dialog.render(data);
            }, function () {
                dialog.isLoading = false;
                clearTimeout(loading);
                dialog.render();
            });
        },

        render: function (data) {
            var dialog = this;

            if (!dialog.lookup.filter.offset) {
                dialog.tableBody.innerHTML = '';
                dialog.tableHead.innerHTML = '';
            }

            dialog.loader.style.opacity = 0;

            setTimeout(function () {
                dialog.loader.style.display = 'none';
            }, dialog.lookup.options.loadingDelay);

            if (data) {
                dialog.error.style.display = 'none';

                if (!dialog.lookup.filter.offset) {
                    dialog.renderHeader(data.columns);
                }

                dialog.renderBody(data);

                if (data.rows.length <= dialog.lookup.filter.rows) {
                    dialog.footer.style.display = 'none';
                } else {
                    dialog.footer.style.display = '';
                }
            } else {
                dialog.error.style.opacity = 1;
            }
        },
        renderHeader: function (columns) {
            var row = document.createElement('tr');

            for (var i = 0; i < columns.length; i++) {
                if (!columns[i].hidden) {
                    row.appendChild(this.createHeaderCell(columns[i]));
                }
            }

            row.appendChild(document.createElement('th'));
            this.tableHead.appendChild(row);
        },
        renderBody: function (data) {
            var dialog = this;

            data.selected.forEach(function (selected) {
                var row = dialog.createDataRow(data.columns, selected);
                row.className = 'selected';

                dialog.tableBody.appendChild(row);
            });

            if (data.selected.length) {
                var separator = document.createElement('tr');
                var content = document.createElement('td');

                content.colSpan = data.columns.length + 1;
                separator.className = 'mvc-lookup-split';

                dialog.tableBody.appendChild(separator);
                separator.appendChild(content);
            }

            for (var i = 0; i < data.rows.length && i < dialog.lookup.filter.rows; i++) {
                dialog.tableBody.appendChild(dialog.createDataRow(data.columns, data.rows[i]));
            }

            if (!data.rows.length && !dialog.lookup.filter.offset) {
                var container = document.createElement('tr');
                var empty = document.createElement('td');

                empty.innerHTML = dialog.lookup.lang.noData;
                container.className = 'mvc-lookup-empty';
                empty.colSpan = data.columns.length + 1;

                dialog.tableBody.appendChild(container);
                container.appendChild(empty);
            }
        },

        createHeaderCell: function (column) {
            var dialog = this;
            var filter = dialog.lookup.filter;
            var header = document.createElement('th');

            if (column.cssClass) {
                header.classList.add(column.cssClass);
            }

            if (filter.sort == column.key) {
                header.classList.add('mvc-lookup-' + filter.order.toLowerCase());
            }

            header.innerText = column.header || '';
            header.addEventListener('click', function () {
                filter.order = filter.sort == column.key && filter.order == 'Asc' ? 'Desc' : 'Asc';
                filter.sort = column.key;
                filter.offset = 0;

                dialog.refresh();
            });

            return header;
        },
        createDataRow: function (columns, data) {
            var dialog = this;
            var lookup = dialog.lookup;
            var row = document.createElement('tr');

            for (var i = 0; i < columns.length; i++) {
                if (!columns[i].hidden) {
                    var cell = document.createElement('td');
                    cell.className = columns[i].cssClass || '';
                    cell.innerText = data[columns[i].key] || '';

                    row.appendChild(cell);
                }
            }

            row.appendChild(document.createElement('td'));

            row.addEventListener('click', function (e) {
                if (!window.getSelection().isCollapsed) {
                    return;
                }

                if (lookup.multi) {
                    var index = lookup.indexOf(dialog.selected, data.Id);

                    if (index >= 0) {
                        dialog.selected.splice(index, 1);

                        this.classList.remove('selected');
                    } else {
                        dialog.selected.push(data);

                        this.classList.add('selected');
                    }

                    dialog.selector.innerText = lookup.lang.select.replace('{0}', dialog.selected.length);
                } else {
                    if (e.ctrlKey && lookup.indexOf(dialog.selected, data.Id) >= 0) {
                        dialog.selected = [];
                    } else {
                        dialog.selected = [data];
                    }

                    dialog.close();
                }
            });

            return row;
        },

        limitRows: function (value) {
            value = Math.max(this.options.rows.min, Math.min(parseInt(value), this.options.rows.max));

            return isNaN(value) ? this.lookup.filter.rows : value;
        },

        bind: function () {
            var dialog = this;

            dialog.selector.addEventListener('click', dialog.close);
            dialog.footer.addEventListener('click', dialog.loadMore);
            dialog.rows.addEventListener('change', dialog.rowsChanged);
            dialog.closeButton.addEventListener('click', dialog.close);
            dialog.search.addEventListener('keyup', dialog.searchChanged);
        },
        loadMore: function () {
            var dialog = MvcLookupDialog.prototype.current;

            dialog.lookup.filter.offset += dialog.lookup.filter.rows;

            dialog.refresh();
        },
        rowsChanged: function () {
            var rows = this;
            var dialog = MvcLookupDialog.prototype.current;

            rows.value = dialog.limitRows(rows.value);

            if (dialog.lookup.filter.rows != rows.value) {
                dialog.lookup.filter.rows = parseInt(rows.value);
                dialog.lookup.filter.offset = 0;

                dialog.refresh();
            }
        },
        searchChanged: function (e) {
            var search = this;
            var dialog = MvcLookupDialog.prototype.current;

            dialog.lookup.stopLoading();
            clearTimeout(dialog.searching);
            dialog.searching = setTimeout(function () {
                if (dialog.lookup.filter.search != search.value || e.keyCode == 13) {
                    dialog.lookup.filter.search = search.value;
                    dialog.lookup.filter.offset = 0;

                    dialog.refresh();
                }
            }, dialog.lookup.options.searchDelay);
        }
    };

    return MvcLookupDialog;
}());
var MvcLookupOverlay = (function () {
    function MvcLookupOverlay(dialog) {
        this.element = this.findOverlay(dialog.element);
        this.dialog = dialog;

        this.bind();
    }

    MvcLookupOverlay.prototype = {
        findOverlay: function (element) {
            var overlay = element;

            if (!overlay) {
                throw new Error('Lookup dialog element was not found.');
            }

            while (overlay && !overlay.classList.contains('mvc-lookup-overlay')) {
                overlay = overlay.parentElement;
            }

            if (!overlay) {
                throw new Error('Lookup dialog has to be inside a mvc-lookup-overlay.');
            }

            return overlay;
        },

        show: function () {
            var body = document.body.getBoundingClientRect();
            if (body.left + body.right < window.innerWidth) {
                var scrollWidth = window.innerWidth - document.body.clientWidth;
                var paddingRight = parseFloat(getComputedStyle(document.body).paddingRight);

                document.body.style.paddingRight = paddingRight + scrollWidth + 'px';
            }

            document.body.classList.add('mvc-lookup-open');
            this.element.style.display = 'block';
        },
        hide: function () {
            document.body.classList.remove('mvc-lookup-open');
            document.body.style.paddingRight = '';
            this.element.style.display = '';
        },

        bind: function () {
            this.element.addEventListener('mousedown', this.onMouseDown);
            document.addEventListener('keydown', this.onKeyDown);
        },
        onMouseDown: function (e) {
            var targetClasses = e.target.classList;

            if (targetClasses.contains('mvc-lookup-overlay') || targetClasses.contains('mvc-lookup-wrapper')) {
                MvcLookupDialog.prototype.current.close();
            }
        },
        onKeyDown: function (e) {
            if (e.which == 27 && MvcLookupDialog.prototype.current) {
                MvcLookupDialog.prototype.current.close();
            }
        }
    };

    return MvcLookupOverlay;
}());
var MvcLookupAutocomplete = (function () {
    function MvcLookupAutocomplete(lookup) {
        var autocomplete = this;

        autocomplete.lookup = lookup;
        autocomplete.element = document.createElement('ul');
        autocomplete.element.className = 'mvc-lookup-autocomplete';
        autocomplete.options = { minLength: 1, rows: 20, sort: lookup.filter.sort, order: lookup.filter.order };
    }

    MvcLookupAutocomplete.prototype = {
        search: function (term) {
            var autocomplete = this;
            var lookup = autocomplete.lookup;

            lookup.stopLoading();
            clearTimeout(autocomplete.searching);
            autocomplete.searching = setTimeout(function () {
                if (term.length < autocomplete.options.minLength || lookup.readonly) {
                    autocomplete.hide();

                    return;
                }

                lookup.startLoading({
                    search: term,
                    selected: lookup.multi ? lookup.selected : [],
                    sort: autocomplete.options.sort,
                    order: autocomplete.options.order,
                    offset: 0,
                    rows: autocomplete.options.rows
                }, function (data) {
                    autocomplete.hide();

                    for (var i = 0; i < data.rows.length; i++) {
                        var item = document.createElement('li');
                        item.innerText = data.rows[i].Label;
                        item.dataset.id = data.rows[i].Id;

                        autocomplete.element.appendChild(item);
                        autocomplete.bind(item, [data.rows[i]]);

                        if (i == 0) {
                            autocomplete.activeItem = item;
                            item.classList.add('active');
                        }
                    }

                    if (!data.rows.length) {
                        var noData = document.createElement('li');
                        noData.className = 'mvc-lookup-autocomplete-no-data';
                        noData.innerText = lookup.lang.noData;

                        autocomplete.element.appendChild(noData);
                    }

                    autocomplete.show();
                });
            }, autocomplete.lookup.options.searchDelay);
        },
        previous: function () {
            var autocomplete = this;

            if (!autocomplete.element.parentElement || !autocomplete.activeItem) {
                autocomplete.search(autocomplete.lookup.search.value);

                return;
            }

            autocomplete.activeItem.classList.remove('active');
            autocomplete.activeItem = autocomplete.activeItem.previousElementSibling || autocomplete.element.lastElementChild;
            autocomplete.activeItem.classList.add('active');
        },
        next: function () {
            var autocomplete = this;

            if (!autocomplete.element.parentElement || !autocomplete.activeItem) {
                autocomplete.search(autocomplete.lookup.search.value);

                return;
            }

            autocomplete.activeItem.classList.remove('active');
            autocomplete.activeItem = autocomplete.activeItem.nextElementSibling || autocomplete.element.firstElementChild;
            autocomplete.activeItem.classList.add('active');
        },
        show: function () {
            var autocomplete = this;
            var search = autocomplete.lookup.search.getBoundingClientRect();

            autocomplete.element.style.left = search.left + window.pageXOffset + 'px';
            autocomplete.element.style.top = search.top + search.height + window.pageYOffset + 'px';

            document.body.appendChild(autocomplete.element);
        },
        hide: function () {
            var autocomplete = this;

            autocomplete.activeItem = null;
            autocomplete.element.innerHTML = '';

            if (autocomplete.element.parentElement) {
                document.body.removeChild(autocomplete.element);
            }
        },

        bind: function (item, data) {
            var autocomplete = this;
            var lookup = autocomplete.lookup;

            item.addEventListener('mousedown', function (e) {
                e.preventDefault();
            });

            item.addEventListener('click', function () {
                if (lookup.multi) {
                    lookup.select(lookup.selected.concat(data), true);
                } else {
                    lookup.select(data, true);
                }

                lookup.stopLoading();
                autocomplete.hide();
            });

            item.addEventListener('mouseenter', function () {
                if (autocomplete.activeItem) {
                    autocomplete.activeItem.classList.remove('active');
                }

                this.classList.add('active');
                autocomplete.activeItem = this;
            });
        }
    };

    return MvcLookupAutocomplete;
}());
var MvcLookup = (function () {
    function MvcLookup(element, options) {
        var lookup = this;
        var group = lookup.findLookup(element);
        if (group.dataset.id) {
            return lookup.instances[parseInt(group.dataset.id)].set(options || {});
        }

        lookup.items = [];
        lookup.group = group;
        lookup.selected = [];
        lookup.for = group.dataset.for;
        lookup.url = group.dataset.url;
        lookup.multi = group.dataset.multi == 'True';
        lookup.group.dataset.id = lookup.instances.length;
        lookup.readonly = group.dataset.readonly == 'True';
        lookup.options = { searchDelay: 300, loadingDelay: 300 };

        lookup.search = group.querySelector('.mvc-lookup-input');
        lookup.browser = group.querySelector('.mvc-lookup-browser');
        lookup.control = group.querySelector('.mvc-lookup-control');
        lookup.error = group.querySelector('.mvc-lookup-control-error');
        lookup.valueContainer = group.querySelector('.mvc-lookup-values');
        lookup.values = lookup.valueContainer.querySelectorAll('.mvc-lookup-value');

        lookup.instances.push(lookup);
        lookup.filter = new MvcLookupFilter(lookup);
        lookup.dialog = new MvcLookupDialog(lookup);
        lookup.autocomplete = new MvcLookupAutocomplete(lookup);

        lookup.set(options || {});
        lookup.reload(false);
        lookup.cleanUp();
        lookup.bind();
    }

    MvcLookup.prototype = {
        instances: [],
        lang: {
            more: 'More...',
            search: 'Search...',
            select: 'Select ({0})',
            noData: 'No data found',
            error: 'Error while retrieving records'
        },

        findLookup: function (element) {
            var lookup = element;

            if (!lookup) {
                throw new Error('Lookup element was not specified.');
            }

            while (lookup && !lookup.classList.contains('mvc-lookup')) {
                lookup = lookup.parentElement;
            }

            if (!lookup) {
                throw new Error('Lookup can only be created from within mvc-lookup structure.');
            }

            return lookup;
        },

        extend: function () {
            var options = {};

            for (var i = 0; i < arguments.length; i++) {
                for (var key in arguments[i]) {
                    if (Object.prototype.toString.call(options[key]) == '[object Object]') {
                        options[key] = this.extend(options[key], arguments[i][key]);
                    } else {
                        options[key] = arguments[i][key];
                    }
                }
            }

            return options;
        },
        set: function (options) {
            var lookup = this;

            lookup.options.loadingDelay = options.loadingDelay == null ? lookup.options.loadingDelay : options.loadingDelay;
            lookup.options.searchDelay = options.searchDelay == null ? lookup.options.searchDelay : options.searchDelay;
            lookup.autocomplete.options = lookup.extend(lookup.autocomplete.options, options.autocomplete);
            lookup.setReadonly(options.readonly == null ? lookup.readonly : options.readonly);
            lookup.dialog.options = lookup.extend(lookup.dialog.options, options.dialog);

            return lookup;
        },
        setReadonly: function (readonly) {
            var lookup = this;
            lookup.readonly = readonly;

            if (readonly) {
                lookup.search.tabIndex = -1;
                lookup.search.readOnly = true;
                lookup.group.classList.add('mvc-lookup-readonly');

                if (lookup.browser) {
                    lookup.browser.tabIndex = -1;
                }
            } else {
                lookup.search.removeAttribute('readonly');
                lookup.search.removeAttribute('tabindex');
                lookup.group.classList.remove('mvc-lookup-readonly');

                if (lookup.browser) {
                    lookup.browser.removeAttribute('tabindex');
                }
            }

            lookup.resize();
        },

        browse: function () {
            var lookup = this;

            if (!lookup.readonly) {
                if (lookup.browser) {
                    lookup.browser.blur();
                }

                lookup.dialog.open();
            }
        },
        reload: function (triggerChanges) {
            var lookup = this;
            var originalValue = lookup.search.value;
            var ids = [].filter.call(lookup.values, function (element) {
                return element.value;
            });

            if (ids.length) {
                lookup.startLoading({ ids: ids, offset: 0, rows: ids.length }, function (data) {
                    lookup.select(data.rows, triggerChanges);
                });
            } else {
                lookup.stopLoading();
                lookup.select([], triggerChanges);

                if (!lookup.multi && lookup.search.name) {
                    lookup.search.value = originalValue;
                }
            }
        },
        select: function (data, triggerChanges) {
            var lookup = this;
            triggerChanges = triggerChanges == null || triggerChanges;

            if (!lookup.dispatchEvent(lookup.group, 'lookupselect', { lookup: lookup, data: data, triggerChanges: triggerChanges })) {
                return;
            }

            if (triggerChanges && data.length == lookup.selected.length) {
                triggerChanges = false;
                for (var i = 0; i < data.length && !triggerChanges; i++) {
                    triggerChanges = data[i].Id != lookup.selected[i].Id;
                }
            }

            lookup.selected = data;

            if (lookup.multi) {
                lookup.search.value = '';
                lookup.valueContainer.innerHTML = '';
                lookup.items.forEach(function (item) {
                    item.parentElement.removeChild(item);
                });

                lookup.items = lookup.createSelectedItems(data);
                lookup.items.forEach(function (item) {
                    lookup.control.insertBefore(item, lookup.search);
                });

                lookup.values = lookup.createValues(data);
                lookup.values.forEach(function (value) {
                    lookup.valueContainer.appendChild(value);
                });

                lookup.resize();
            } else if (data.length) {
                lookup.values[0].value = data[0].Id;
                lookup.search.value = data[0].Label;
            } else {
                lookup.values[0].value = '';
                lookup.search.value = '';
            }

            if (triggerChanges) {
                var change = null;

                if (typeof Event === 'function') {
                    change = new Event('change');
                } else {
                    change = document.createEvent('Event');
                    change.initEvent('change', true, false);
                }

                lookup.search.dispatchEvent(change);
                [].forEach.call(lookup.values, function (value) {
                    value.dispatchEvent(change);
                });
            }
        },
        selectFirst: function (triggerChanges) {
            var lookup = this;

            lookup.startLoading({ search: '', offset: 0, rows: 1 }, function (data) {
                lookup.select(data.rows, triggerChanges);
            });
        },
        selectSingle: function (triggerChanges) {
            var lookup = this;

            lookup.startLoading({ search: '', offset: 0, rows: 2 }, function (data) {
                if (data.rows.length == 1) {
                    lookup.select(data.rows, triggerChanges);
                } else {
                    lookup.select([], triggerChanges);
                }
            });
        },

        createSelectedItems: function (data) {
            var items = [];

            for (var i = 0; i < data.length; i++) {
                var button = document.createElement('button');
                button.className = 'mvc-lookup-deselect';
                button.innerText = '×';
                button.type = 'button';

                var item = document.createElement('div');
                item.innerText = data[i].Label || '';
                item.className = 'mvc-lookup-item';
                item.appendChild(button);
                items.push(item);

                this.bindDeselect(button, data[i].Id);
            }

            return items;
        },
        createValues: function (data) {
            var inputs = [];

            for (var i = 0; i < data.length; i++) {
                var input = document.createElement('input');
                input.className = 'mvc-lookup-value';
                input.value = data[i].Id;
                input.type = 'hidden';
                input.name = this.for;

                inputs.push(input);
            }

            return inputs;
        },

        startLoading: function (search, success, error) {
            var lookup = this;

            lookup.stopLoading();
            lookup.loading = setTimeout(function () {
                lookup.autocomplete.hide();
                lookup.group.classList.add('mvc-lookup-loading');
            }, lookup.options.loadingDelay);
            lookup.group.classList.remove('mvc-lookup-error');

            lookup.request = new XMLHttpRequest();
            lookup.request.open('GET', lookup.filter.formUrl(search), true);
            lookup.request.setRequestHeader('X-Requested-With', 'XMLHttpRequest');

            lookup.request.onload = function () {
                if (200 <= lookup.request.status && lookup.request.status < 400) {
                    lookup.stopLoading();

                    success(JSON.parse(lookup.request.responseText));
                } else {
                    lookup.request.onerror();
                }
            };

            lookup.request.onerror = function () {
                lookup.group.classList.add('mvc-lookup-error');
                lookup.error.title = lookup.lang.error;
                lookup.autocomplete.hide();
                lookup.stopLoading();

                if (error) {
                    error();
                }
            };

            lookup.request.send();
        },
        stopLoading: function () {
            var lookup = this;

            if (lookup.request && lookup.request.readyState != 4) {
                lookup.request.abort();
            }

            clearTimeout(lookup.loading);
            lookup.group.classList.remove('mvc-lookup-loading');
        },

        dispatchEvent: function (element, type, detail) {
            var event;

            if (typeof Event === 'function') {
                event = new CustomEvent(type, {
                    cancelable: true,
                    detail: detail,
                    bubbles: true
                });
            } else {
                event = document.createEvent('Event');
                event.initEvent(type, true, true);
                event.detail = detail;
            }

            return element.dispatchEvent(event);
        },
        bindDeselect: function (close, id) {
            var lookup = this;

            close.addEventListener('click', function () {
                lookup.select(lookup.selected.filter(function (value) {
                    return value.Id != id;
                }), true);

                lookup.search.focus();
            });
        },
        indexOf: function (selection, id) {
            for (var i = 0; i < selection.length; i++) {
                if (selection[i].Id == id) {
                    return i;
                }
            }

            return -1;
        },
        cleanUp: function () {
            var data = this.group.dataset;

            delete data.readonly;
            delete data.filters;
            delete data.dialog;
            delete data.search;
            delete data.multi;
            delete data.order;
            delete data.title;
            delete data.rows;
            delete data.sort;
            delete data.url;
        },
        resize: function () {
            var lookup = this;

            if (lookup.items.length) {
                var style = getComputedStyle(lookup.control);
                var contentWidth = lookup.control.clientWidth;
                var lastItem = lookup.items[lookup.items.length - 1];
                contentWidth -= parseFloat(style.paddingLeft) + parseFloat(style.paddingRight);
                var widthLeft = Math.floor(contentWidth - lastItem.offsetLeft - lastItem.offsetWidth);

                if (widthLeft > contentWidth / 3) {
                    style = getComputedStyle(lookup.search);
                    widthLeft -= parseFloat(style.marginLeft) + parseFloat(style.marginRight) + 4;
                    lookup.search.style.width = widthLeft + 'px';
                } else {
                    lookup.search.style.width = '';
                }
            } else {
                lookup.search.style.width = '';
            }
        },
        bind: function () {
            var lookup = this;

            window.addEventListener('resize', function () {
                lookup.resize();
            });

            lookup.search.addEventListener('focus', function () {
                lookup.group.classList.add('mvc-lookup-focus');
            });

            lookup.search.addEventListener('blur', function () {
                lookup.stopLoading();
                lookup.autocomplete.hide();
                lookup.group.classList.remove('mvc-lookup-focus');

                var originalValue = this.value;
                if (!lookup.multi && lookup.selected.length) {
                    if (lookup.selected[0].Label != this.value) {
                        lookup.select([], true);
                    }
                } else {
                    this.value = '';
                }

                if (!lookup.multi && lookup.search.name) {
                    this.value = originalValue;
                }
            });

            lookup.search.addEventListener('keydown', function (e) {
                switch (e.which) {
                    case 8:
                        if (!this.value.length && lookup.selected.length) {
                            lookup.select(lookup.selected.slice(0, -1), true);
                        }

                        break;
                    case 9:
                        if (lookup.autocomplete.activeItem) {
                            if (lookup.browser) {
                                lookup.browser.tabIndex = -1;

                                setTimeout(function () {
                                    lookup.browser.removeAttribute('tabindex');
                                }, 100);
                            }

                            lookup.autocomplete.activeItem.click();
                        }

                        break;
                    case 13:
                        if (lookup.autocomplete.activeItem) {
                            e.preventDefault();

                            lookup.autocomplete.activeItem.click();
                        }

                        break;
                    case 38:
                        e.preventDefault();

                        lookup.autocomplete.previous();

                        break;
                    case 40:
                        e.preventDefault();

                        lookup.autocomplete.next();

                        break;
                }
            });
            lookup.search.addEventListener('input', function () {
                if (!this.value.length && !lookup.multi && lookup.selected.length) {
                    lookup.autocomplete.hide();
                    lookup.select([], true);
                }

                lookup.autocomplete.search(this.value);
            });

            if (lookup.browser) {
                lookup.browser.addEventListener('click', function () {
                    lookup.browse();
                });
            }

            for (var i = 0; i < lookup.filter.additional.length; i++) {
                var inputs = document.querySelectorAll('[name="' + lookup.filter.additional[i] + '"]');

                for (var j = 0; j < inputs.length; j++) {
                    inputs[j].addEventListener('change', function () {
                        if (!lookup.dispatchEvent(this, 'filterchange', { lookup: lookup })) {
                            return;
                        }

                        lookup.stopLoading();
                        lookup.filter.offset = 0;

                        var ids = [].filter.call(lookup.values, function (element) {
                            return element.value;
                        });

                        if (ids.length || lookup.selected.length) {
                            lookup.startLoading({ checkIds: ids, offset: 0, rows: ids.length }, function (data) {
                                lookup.select(data.rows, true);
                            }, function () {
                                lookup.select([], true);
                            });
                        }
                    });
                }
            }
        }
    };

    return MvcLookup;
}());
