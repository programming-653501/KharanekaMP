var app = app || {};
(function() {
    app.mainView = new app.MainView();
    app.contacts = new app.Contacts();
    var Router = Backbone.Router.extend({

        initialize : function () {
            this.$main = $("#main");
            this.$header = $("#header");


            app.contacts.fetch({reset : true});

            location.href = "#";
        },
        routes : {
            "" : "index",
            "contacts" : "index",
            "contacts/add" : "addContact",
            "contacts/:id" : "showContact",
            "contacts/:id/edit" : "editContact",
        },
        index : function () {
            app.mainView.render();
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
