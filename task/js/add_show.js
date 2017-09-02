$(document).ready( function () { // Переключение между поиском и добавлением.
	$("#main #switch").click( function () {
		if (!ghapp.input) {
			ghapp.input = true;
			ghapp.newUser = new ghapp.NewUser();
			$("#workspace").load("markup/input.html", {});
			$("#switch").val("go search");
		} else {
			ghapp.input = false;
			$("#workspace").load("markup/search.html", function () {
				ghapp.loadLocal();
			});
			$("#switch").val("add user");
		}
	});
});