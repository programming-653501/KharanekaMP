(function () {
	window.ghapi = {
		"root" : "https://api.github.com",
		"timeout" : 5000,
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
			var xhr = new XMLHttpRequest();
			xhr.timeout = ghapi.timeout;
			xhr.ontimeout = function () {
				throw("Request timed out.");
			}
			xhr.open("GET", request, true);
			xhr.setRequestHeader('Accept', 'application/json');
			xhr.responseType = "text";
			xhr.onreadystatechange = function () {
				if (this.readyState === 4) {
					if (this.status === 200) {
						if (typeof succ == "function") {
							succ(q ? this.response : JSON.parse(this.response));
						} else {
							throw("request gave result, but succ is not a function");
						}
					} else if (this.status === 403) {
						if (typeof succ == "function") {
							succ("forbidden");
						} else {
							throw("request gave result, but succ is not a function");
						}
					} else {
						if (typeof err == "function") {
							err(q ? this.response : JSON.parse(this.response));
						} else {
							throw("request gave not OK, and err is not a function");
						}
					}
				}
			}
			xhr.send();
		}
	}
}());