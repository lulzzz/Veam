///// <reference path="../../../../persentation/veam.webapphost/wwwroot/adminlte/components/jquery/dist/jquery.min.js" />

var entity = 'Asset';
var apiurl = '/api/' + entity;
var BillItems = [];
var items = [];
//$(document).ready(function () {

   
//});


function loadAssetGrid() {
    $("#grid-selection").bootgrid({
        ajax: true,
        url: apiurl,
        navigation: 0,
        selection: true,
        multiSelect: true,
        formatters: {
            "link": function (column, row) {
                return "<a href=\"#\">" + column.id + ": " + row.id + "</a>";
            }
        }
    }).on("selected.rs.jquery.bootgrid", function (e, rows) {

        for (var i = 0; i < rows.length; i++) {
            items.push(rows[i].assetId);
        }
        BillItems = [];
        for (var i = 0; i < items.length; i++) {
            BillItems.push({ assetId: items[i] });
        }

    }).on("deselected.rs.jquery.bootgrid", function (e, rows) {

        for (var i = 0; i < rows.length; i++) {
            var removeItem = rows[i].assetId;
            items = jQuery.grep(items, function (value) { return value !== removeItem });
        }
        BillItems = [];
        for (var i = 0; i < items.length; i++) {
            BillItems.push({ assetId: items[i] });
        }
    });
}

//Save button click function
$('#submit').click(function () {
    //validation of order
    var isAllValid = true;
    if (BillItems.length == 0) {
        alert("Please selected atleast one item");
        isAllValid = false;
    }

    //Save if valid
    if (isAllValid) {
        var data = {
            billNo: $('#BillNo').val(),
            billDate: $('#BillDateDate').val(),
            notes: $('#Notes').val(),
            Assets: BillItems
        }

        $(this).val('Please wait...');

        $.ajax({
            url: '/AssetPurchase/Create',
            type: "POST",
            data: JSON.stringify(data),
            // dataType: "JSON",
            contentType: "application/json",
            success: function (d) {
                //check is successfully save to database
                if (d.status == true) {
                    //will send status from server side
                    alert('Successfully done.');
                    //clear form
                    BillItems = [];
                    $('#BillNo').val('');
                    $('#BillDate').val('');
                    $('#BillItems').empty();
                }
                else {
                    alert('Failed');
                }
                $('#submit').val('Save');
            },
            error: function () {
                alert('Error. Please try again.');
                $('#submit').val('Save');
            }
        });
    }

});