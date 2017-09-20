var app = app || {};

(function () {
    app.MainView = Backbone.View.extend({
        el : ".app",

        headerTemplate : _.template($("#header-templ").html()),
        
        initialize : function () {
            this.$main = $("#main");
            this.$header = $("#header");
            this.listenTo(app.contacts, "addNew", this.addContact);
            this.listenTo(app.contacts, "reset", this.addAll);
            this.listenTo(app.contacts, "index", _.debounce(this.render, true));
            this.listenTo(app.contacts, "show", this.showContact);
            this.listenTo(app.contacts, "edit", this.editContact);
            this.listenTo(app.contacts, "destroy", _.debounce(this.render, true));


            app.contacts.fetch({reset : true});

            this.render();
            
        },

        render : function () {
            this.addAll();
            this.$header.html(this.headerTemplate({
                first : "First Name",
                second : "Second Name",
                buttoncapt : "Add"
            }));
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
}());