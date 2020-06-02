//function loadHallByCenter() {
//    $('#centerList').change(function () {
//      //  var url = '@Url.Content("~/")' + "Select/GetHallbyCenterId";
//        var url = "Select/GetHallbyCenterId?";
//        $.getJSON(url, { centerId: $("#centerList").val() }, function (data) {
//            console.log(url);
//            console.log(centerId);
//            var items = '';
//            $("#hallList").empty();
//            $.each(data, function (i, section) {
//                items += "<option value='" + section.value + "'>" + section.text + "</option>";
//            });
//            $('#hallList').html(items);
//        });
//    });
//};