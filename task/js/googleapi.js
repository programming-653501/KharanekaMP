$(document).ready( function () {
	ghapp.autocomplete = new google.maps.places.Autocomplete(document.getElementById("city"));
	google.maps.event.addListener(ghapp.autocomplete, "place_changed", function () {
		ghapp.newUser.city.value = $("#city").val();
	});
});