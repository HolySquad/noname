(function ($) {
    var bootstrapDialog = BootstrapDialog;

    $.confirm = function(title, message, callback) {
        var popup = bootstrapDialog.show({
            message: message,
            title: title,
            type: bootstrapDialog.TYPE_WARNING,
            data: {
                callback: callback
            },
            buttons: [
                {
                    label: "Yes",
                    cssClass: 'btn-primary',
                    action : function(dialog) {
                        dialog.close();
                        typeof dialog.getData('callback') === 'function' && dialog.getData('callback')(true);   
                    }
                },
                {
                    label: 'No',
                    action: function (dialog) {
                        dialog.close();
                        typeof dialog.getData('callback') === 'function' && dialog.getData('callback')(false);
                    }
                }
            ],
            draggable: false
        });
        return popup;
    };
});
