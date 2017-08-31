ghapp.getUserElement = function (avatar_path, name, ref, el_id) {
	var $el;
	$el = $("<div></div>")
	.attr("class", "users")
	.attr("id", el_id)
	.append($("<img></img>")
	.attr("src", avatar_path))
	.append($("<p>")
	.html(name));
	return "<a href='" + ref + "' target='_blank'>" + $el[0].outerHTML + "</a>";
}
ghapp.getLocalUserElement = function (local) {
	var $el;
	var user = JSON.parse(localStorage["user" + local]);
	$el = $("<div>")
	.attr("class", "local")
	.attr("id", local)
	.append("<div id='assign'>local</div>")
	var $imgBox = $("<div>").attr("class", "imgBox");
	$imgBox.append($("<img>").attr("src", user.avatar.value));
	$imgBox.append($("<p>")
	.html(user.userName.value));
	$el.append($imgBox);
	var $div = $("<div id='info'>");
	var $t = $("<table>");
	for (var prop in user) {
		if (user.hasOwnProperty(prop) && prop != "tech" && prop != "avatar" && prop != "userName") {
			$t.append("<tr><td>" + user[prop].name + "</td><td>" + user[prop].value + "</td></tr>");
		}
	};
	$t.append("<tr><td colspan=2 id='skillsblock" + local + "'></td></tr>");
	for (var skill in user.tech.value) {
		$t.find("td").last().append("<div class='techTag'>&nbsp" + skill + "&nbsp</div>")
	}
	$div.append($t);
	$el.append($div);
	return $el[0].outerHTML;
}
