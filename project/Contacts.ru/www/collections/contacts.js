var app = app || {};
(function () {
    app.Contacts = Backbone.Collection.extend({
        model : app.Contact,
        
        nextID : function () {
            if (!this.length) {
                return 1;
            }
            return this.last().get('order') + 1;
        },
    
        localStorage : new Backbone.LocalStorage("contacts-local"),
        
        comparator : 'order'
    
    });
}())