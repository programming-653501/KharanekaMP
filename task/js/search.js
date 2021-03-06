$(document).ready( function () { // Поиск, разметка задается при помощи ghapp.getUserElement из info.js
	$("#workspace").on("click", "#search", function () {
		var i;
		$("#users").html("");
		ghapi.load("/search/users", {
			"q" : $("#searchLine form input[type='text']").val(),
			"sort" : "followers"
		}, function (data) {
			if (data.total_count === 0) {
				$("#users").html("<h2>К сожалению, ничего не найдено</h2>");
			}
			for (i = 0; i < (data.total_count < ghapp.consts.users_shows ? data.total_count : ghapp.consts.users_shows); i++) {
				$("#users").append(ghapp.getUserElement( {
					avatar_path : data.items[i].avatar_url, 
					name : data.items[i].login,
					ref : data.items[i].html_url,
					el_id : "gituser" + i
				}));
			}
			ghapp.loadLocal();
		}, function () {
			alert("smth went wrong...");
		});
	});
});