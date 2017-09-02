(function () { // Объект локального юзера.
ghapp.NewUser = function () {
	this.userName = {
		"done" : false,
		"name" : "Имя",
		"value" : null
	},
	this.company = {
		"done" : false,
		"name" : "Компания",
		"value" : null
	},
	this.blog = {
		"done" : false,
		"name" : "Блог",
		"value" : null
	},
	this.avatar = {
		"done" : false,
		"value" : null
	},
	this.email = {
		"validate" : function (str) {
			var emailReg = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
			return emailReg.test(str);
		},
		"done" : false,
		"name" : "Email",
		"value" : null
	},
	this.city = {
		"done" : false,
		"name" : "Город",
		"value" : null
	},
	this.level = {
		"done" : false,
		"name" : "Уровень",
		"value" : null
	},
	this.exp = {
		"done" : false,
		"validate" : function (str) {
			var regex = /[0-9]+/;
			if (!regex.test(str)) {
				return false;
			}
			if (parseFloat(str) < 0 || parseFloat(str) > 65) {
				return false;
			};
			return true;
		},
		"name" : "Опыт",
		"value" : null
	},
	this.tech = {
		"done" : false,
		"validate" : function () {
			for (var prop in this.value) {
				if (this.value.hasOwnProperty(prop)) {
					this.done = true;
					return;
				}
			};
			this.done = false;
		},
		"value" : null
	}
};

ghapp.NewUser.prototype = {
	done : function (){
		for (var field in this) {
			if (this.hasOwnProperty(field)) {
				if (!this[field].done) {
					return false;
				}
			}
		};
		return true;
	}
};
}());