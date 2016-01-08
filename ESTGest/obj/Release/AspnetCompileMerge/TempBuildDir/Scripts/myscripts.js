$(document).ready(function () {

    initialize();

});

function initialize() {
    var latlng = new google.maps.LatLng(38.522082, -8.838784);
    var options = {
        zoom: 18, center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById
        ("map_canvas"), options);
}