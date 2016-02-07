function HolySearchVm() {
   var self = this;

    var internal = {
        searchFormId: "#SearchSubmitForm",
        bodyId: "#body"
    };

    self.searchUpdate = function () {
        var $form = $(internal.searchFormId);
        var data = $form.serialize();
        var url = $form.attr("action");

        $.post(url, data, function(result) {
            $(internal.bodyId).html(result);
        });
    };

    $("#Query").on("input", function () {
        self.searchUpdate();
        return false;
    });

    $(internal.searchFormId).on("submit", function () {
        self.searchUpdate();
       
        return false;
    });
};    