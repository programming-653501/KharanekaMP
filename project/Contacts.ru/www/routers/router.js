var app = app || {};
(function() {
    app.mainView = new app.MainView();
    app.contacts = new app.Contacts();
    var Router = Backbone.Router.extend({

        initialize : function () {
            this.$main = $("#main");
            this.$header = $("#header");
            this.listenTo(app.contacts, "addNew", this.addContact);
            this.listenTo(app.contacts, "reset", this.addAll);
            this.listenTo(app.contacts, "show", this.showContact);
            this.listenTo(app.contacts, "edit", this.editContact);


            app.contacts.fetch({reset : true});

            location.href = "#";
        },
        routes : {
            "" : "index",
            "contacts" : "index",
            "contacts/add" : "add",
            "contacts/:id" : "show",
            "contacts/:id/edit" : "edit",
        },
        index : function () {
            app.mainView.render();
        },
        show : function (id) {
            app.contacts.trigger("show", id);
        },
        edit : function (id) {
            app.contacts.trigger("edit", id);
        },
        add : function () {
            app.contacts.trigger("addNew");
        },
        addOne : function (contact) {
            var view = new app.ItemView({model : contact});
            this.$main.append(view.render().el);
        },

        addAll : function () {
            this.$main.html("");
            app.contacts.each(this.addOne, this);
        },


        showContact : function (order) {
            var view = new app.ShowView({model : app.contacts.findWhere({order : parseInt(order)})});
            this.$main.append(view.render().$el);
        },

        editContact : function (order) {
            var view = new app.EditView({model : app.contacts.findWhere({order : parseInt(order)})});
            this.$main.append(view.render().$el);
        },

        addContact : function () {
            app.contacts.add({});
            var view = new app.EditView({
                model : app.contacts.last(),
                sender : "add"
            });
            this.$main.append(view.render().$el);
        }
    });

    app.Router = new Router();
    Backbone.history.start();
}());
