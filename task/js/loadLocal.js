ghapp.loadLocal = function () {
	var regexp = /user[0-9]+/;
	for (var user in localStorage) {
		if(regexp.test(user)) {
			var num = user.match(/[0-9]+$/)
			$("#users").append(ghapp.getLocalUserElement(num));
		}
	}
}

$(document).ready(function () {
	ghapp.loadLocal();
});