var app = app || {};
(function() {
    app.contacts = new app.Contacts();
    var Router = Backbone.Router.extend({
        routes : {
            "" : "index",
            "contacts" : "index",
            "contacts/add" : "add",
            "contacts/:id" : "show",
            "contacts/:id/edit" : "edit",
        },
        index : function () {
            app.contacts.trigger("index");
        },
        show : function (id) {
            app.contacts.trigger("show", id);
        },
        edit : function (id) {
            app.contacts.trigger("edit", id);
        },
        add : function () {
            app.contacts.trigger("addNew");
        }
    });

    app.Router = new Router();
    Backbone.history.start();
}());