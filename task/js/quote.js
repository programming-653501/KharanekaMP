$(document).ready( function () {
	$("#quoteBlock #show-quote").click( function () { 
		ghapi.load("/zen", {}, function (data) {
			$("#quoteBlock #quote").html(data).fadeIn(ghapp.consts.quote_fading_time);
			setTimeout(function () {
				$("#quoteBlock #quote").fadeOut(ghapp.consts.quote_fading_time);
			}, ghapp.consts.quote_show_time);
		}, function (data) {
			console.log(data);
		}, true);
	});
});