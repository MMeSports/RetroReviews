$(document).ready(function () {
    $("#myCarousel").carousel();
    setInterval(function () {

        $("#myCarousel").carousel("next");
    }, 5000);
});