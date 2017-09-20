var app = app || {};
(function () {
    app.EditView = Backbone.View.extend({
        editTempl : _.template($("#edit-templ").html()),

        initialize : function (args) {
            this.sender = args.sender;
        },

        render : function () {
            this.$el.html(this.editTempl(this.model.toJSON()));
            return this;
        },

        events : {
            "click .save" : "saveCont",
            "click .close" : "close"
        },

        saveCont : function () {
            var input = {
                name : $("#nameEdit").val(),
                surname : $("#surnameEdit").val(),
                email : $("#emailEdit").val(),
                number : $("#numberEdit").val()
            }
            this.model.set(input);
            if (!this.model.isValid()){
                this.invalid(this.model.validationError);
                return;
            }
            this.model.save();
            location.href = "#";
        },

        close : function () {
            if (this.sender === "add"){
                app.contacts.remove(this.model);
            }
            location.href = "#";
        },

        invalid : function (message) {
            $("#editCont input").css("border", "1px solid #DDDDDD");
            switch (message) {
                case "name": 
                    $("#nameEdit").css("border-color", "red");
                    break;
                case "surname":
                    $("#surnameEdit").css("border-color", "red");
                    break;
                case "email":
                    $("#emailEdit").css("border-color", "red");
                    break;
                case "number":
                    $("#numberEdit").css("border-color", "red");
                    break;
            }
        }
    });
}());
