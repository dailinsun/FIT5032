let map;

var xmlHttp = new XMLHttpRequest();
xmlHttp.open("GET", "Campus/Getcampuses", false);
xmlHttp.send();
var Campuses = JSON.parse(xmlHttp.responseText);

function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: -37.816531, lng: 144.960943 },
        zoom: 8,
    });
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(
            (position) => {
                const pos = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude,
                };
                map.setCenter(pos);
            },
            () => {
                handleLocationError(true, infoWindow, map.getCenter());
            }
        );
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());
    }

    var geocoder = new google.maps.Geocoder();
    for (var i = 0; i < Campuses.length; i++) {
        console.log(Campuses[i]);
        geodocAddress(geocoder, map, Campuses[i])
    }

    const input = document.getElementById("start");
    autoComplete(input, map);

    const directionsService = new google.maps.DirectionsService();
    const directionsRenderer = new google.maps.DirectionsRenderer();
    directionsRenderer.setMap(map);
    var getDirection = document.getElementById("get-direction");
    getDirection.addEventListener("click", function () {
        calculateAndDisplayRoute(directionsService, directionsRenderer);
    });
    const onChangeHandler = function () {
        calculateAndDisplayRoute(directionsService, directionsRenderer);
    };
}


function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(
        browserHasGeolocation
            ? "Error: The Geolocation service failed."
            : "Error: Your browser doesn't support geolocation."
    );
    infoWindow.open(map);
}
function geodocAddress(geocoder, map, Campus) {
    var content = "<h1>" + Campus.Name + "</h1><p>" + Campus.address + "</p>"

    var infowindow = new google.maps.InfoWindow({ content: content });

    geocoder.geocode({ address: Campus.address }, function (result, status) {
        if (status === "OK") {
            let marker = new google.maps.Marker({
                map: map,
                position: result[0].geometry.location
            });
            marker.addListener("click", function () {
                infowindow.open(map, marker);
            })
        }
    })

}


function calculateAndDisplayRoute(directionsService, directionsRenderer) {
    directionsService.route(
        {
            origin: {
                query: document.getElementById("start").value,
            },
            destination: {
                query: document.getElementById("end").value,
            },
            travelMode: google.maps.TravelMode.DRIVING,
        },
        (response, status) => {
            if (status === "OK") {
                directionsRenderer.setDirections(response);
            } else {
                window.alert("Directions request failed due to " + status);
            }
        }
    );
}



function autoComplete(input, map) {
    const autocomplete = new google.maps.places.Autocomplete(input);
    autocomplete.bindTo("bounds", map);
    autocomplete.setTypes(["address"]);
}
