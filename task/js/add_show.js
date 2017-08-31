$(document).ready( function () {
	$("#main #switch").click( function () {
		if (!ghapp.input) {
			ghapp.input = true;
			ghapp.newUser = new ghapp.NewUser();
			$("#main #workspace").load("markup/input.html", {});
			$("#main #switch").val("go search");
		} else {
			ghapp.input = false;
			$("#main #workspace").load("markup/search.html", function () {
				ghapp.loadLocal();
			});
			$("#main #switch").val("add user");
		}
	});
});