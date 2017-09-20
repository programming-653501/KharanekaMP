var app = app || {};
(function () {
    app.Contact = Backbone.Model.extend({
        defaults : {
            "name" : "",
            "surname" : "",
            "email" : "",
            "number" : "",
            "order" : 0
        },
        validate : function () {
            var emailRegexp = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            var numberRegexp = /\+?[0-9]+/;
            if (this.get("name") === "") {
                return "name";
            }
            if (this.get("surname") === "") {
                return "surname";
            }
            if (!emailRegexp.test(this.get("email"))) {
                return "email";
            }
            if (!numberRegexp.test(this.get("number"))){
                return "number";
            }
        },
        initialize : function () {
            if (!this.get("order")) {
                this.set("order", app.contacts.nextID());
            } 
        }
    });
}());
