$(document).ready( function () {
	$("#workspace").on("change", "#avatar", function (evt) {
		var avatar = $("#avatar");
		if (!avatar.val()) {
			ghapp.newUser["avatar"].done = false;
			ghapp.newUser["avatar"].value = null;
			return;
		}
		ghapp.newUser["avatar"].done = true;
		var file = evt.target.files[0];
		var reader = new FileReader();
		reader.onload = function (e) {
			ghapp.newUser["avatar"].value = e.target.result;
			if (ghapp.newUser.done()) {
			$("#add").attr("disabled", false);
			} else {
			$("#add").attr("disabled", true);
			}	
		};
		reader.readAsDataURL(file);
	});
	
	$("#workspace").on("focus", ".userData:not(#tech, #avatar)", function () {
		var $infocus = $(".userData:focus");
		if ($infocus.val() === "" || !ghapp.newUser[$infocus.attr("id")].done) {
			$infocus.css("background-color", "#ffd0d0");
		};
	});
	
	$("#workspace").on("change", "#level", function () {
		var $infocus = $("#level");
		if ($infocus.val() !== "") {
			$infocus.css("background-color", "#fff");
			ghapp.newUser["level"].done = true;
			ghapp.newUser["level"].value = $infocus.val();
		}
		if (ghapp.newUser.done()) {
		$("#add").attr("disabled", false);
		} else {
			$("#add").attr("disabled", true);
		}
	});
	
	$("#workspace").on("keyup", ".userData:not(#tech, #avatar)", function () {
		var $infocus = $(".userData:focus");
		var objInfocus = ghapp.newUser[$infocus.attr("id")];
		if ($infocus.val() === "") {
			$infocus.css("background-color", "#ffd0d0");
			objInfocus.done = false;
		} else if ( typeof ghapp.newUser[$infocus.attr("id")].validate == "function") {
			if (objInfocus.validate($infocus.val())) {
				$infocus.css("background-color", "#fff");
				objInfocus.done = true;
				objInfocus.value = $infocus.val();
			} else {
				$infocus.css("background-color", "#ffd0d0");
				objInfocus.done = false;
			}
		} else {
			$infocus.css("background-color", "#fff");
			objInfocus.done = true;
			objInfocus.value = $infocus.val();
		}
		if (ghapp.newUser.done()) {
			$("#add").attr("disabled", false);
		} else {
			$("#add").attr("disabled", true);
		}
	}); 
	
	$("#workspace").on("click", ".crossSpace", function (ev) {
		delete ghapp.newUser.tech.value[$(ev.target).parent().next().html()];
		$(ev.target).parent().detach();
		ghapp.newUser.tech.validate();
		if (!ghapp.newUser.done()) {
			$("#add").attr("disabled", true);
		}
	});
	
	$("#workspace").on("keyup", "#tech", function (ev) {
		var reg = /\S+/g;
		if (ev.keyCode === 32) {
			if (reg.test($("#tech").val())) {
				$("#skillsblock").append("<div class='techTag'>" + $("#tech").val() + "&nbsp&nbsp<div class='crossSpace'>X</div></div>");
				$("#skillsblock").append($("<p class='back'>" + $("#tech").val().trim() + "</p>").css("display", "none"));
				if (!ghapp.newUser["tech"].value) {
					ghapp.newUser["tech"].value = {};
				};
				ghapp.newUser["tech"].value[$("#tech").val().trim()] = null;
				ghapp.newUser.tech.validate();
			};
			$("#tech").val("");
			if (ghapp.newUser.done()) {
			$("#add").attr("disabled", false);
			} else {
			$("#add").attr("disabled", true);
			}
		}
	});
	
	$("#workspace").on("click", "#add", function () {
		var num;
		if (localStorage.hasOwnProperty("usersNum")) {
			num = localStorage.usersNum++;
		} else {
			localStorage.setItem("usersNum", 0);
			num = 0;
		}
		var canvas = document.createElement("canvas");
		canvas.width = 120;
		canvas.height = 120;
		var ctx = canvas.getContext("2d");
		var img = new Image();
		img.onload = function() {
			ctx.drawImage(img, 0, 0, 120, 120);
			ghapp.newUser.avatar.value = canvas.toDataURL("image/jpeg", 0.8);
			localStorage.setItem("user" + num, JSON.stringify(ghapp.newUser));
			$(".userData").val('');
			$("#level").val(' ');
			$("#skillsblock").html("");
			
			ghapp.newUser = new ghapp.NewUser();
		}
		img.src = ghapp.newUser.avatar.value;
	});
});