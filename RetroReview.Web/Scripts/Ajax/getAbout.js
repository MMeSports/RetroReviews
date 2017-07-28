$(document).ready(function () {

    $("#About").empty();
    $.ajax({
        type: "GET",
        url: "../../api/retro/getstaticpages",
        dataType: 'json',
        contentType: 'application/json',
        success: function (page) {
           
                $("#About").append(page["0"].Body);
           
        },
        error: function (jqXHR, status, error) {

        }

    });



});