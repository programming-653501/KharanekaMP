(function () {
	window.ghapi = {
		"root" : "https://api.github.com",
		load : function (command, inf, succ, err, q) {
			var request = "";
			request += ghapi.root + command;
			var item;
			var counter = 0;
			for (item in inf) {
				if (inf.hasOwnProperty(item)) {
					if (counter !== 0) {
						request += "&";
					} else {
						request += "?";
					}
					request += item + "=" + inf[item];
					counter++;
				}
			}
			
			fetch(request).then(function (response) {
				if (response.ok) {
					return q ? response.text() : response.json();
				}
				throw new Error("smth went wrong");
			}).then(function (ghobj) {
				succ(ghobj);
			}).catch(function (error) {
				err(error);
			});
		}
	}
}());