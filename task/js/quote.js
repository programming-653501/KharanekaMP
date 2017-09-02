$(document).ready( function () { // Показ цитаты + анимация.
	$("#show-quote").click( function () { 
		ghapi.load("/zen", {}, function (data) {
			$("#quote").html(data).fadeIn(ghapp.consts.quote_fading_time);
			setTimeout(function () {
				$("#quote").fadeOut(ghapp.consts.quote_fading_time);
			}, ghapp.consts.quote_show_time);
		}, function (data) {
			console.log(data);
		}, true);
	});
});