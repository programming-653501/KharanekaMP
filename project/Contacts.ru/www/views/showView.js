var app = app || {};
(function (){
    app.ShowView = Backbone.View.extend({
        showTempl : _.template($("#show-templ").html()),

        render : function () {
            this.$el.html(this.showTempl(this.model.toJSON()));
            return this;
        }
    });
}());