var app = app || {};
(function () {
    app.ItemView = Backbone.View.extend({
       
        itemTemplate : _.template($("#item-templ").html()),

        initialize : function () {

        },

        events : {
            "click .delete" : "deleteModel"
        },

        render : function () {
            this.$el.html(this.itemTemplate(this.model.toJSON()));
            return this;
        },

        deleteModel : function () {
            this.model.destroy();
        }
    });
}());