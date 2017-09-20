var app = app || {};

(function () {
    app.MainView = Backbone.View.extend({
        el : ".app",

        initialize : function () {
            this.$header = $("#header");
            this.headerTemplate = _.template($("#header-templ").html());
        },

        render : function () {
            app.Router.addAll();
            this.$header.html(this.headerTemplate({
                first : "First Name",
                second : "Second Name",
                buttoncapt : "Add"
            }));
        }
    });
}());
