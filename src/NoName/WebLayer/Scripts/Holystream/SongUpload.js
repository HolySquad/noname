function FileUpload() {

    var self = this;

    var internal = {
        uploadInputId: "#uploadForm"
    };

    self.uploadFileUrl = "";
    self.uploadFileUrlPartial = "";


    $('.uploadBtn').on('click', function() {
        $("#uploadForm").dialog({
            autoOpen: true,
          
            width: 1000,
            resizable: false,
            title: 'Upload File',
            modal: true,
            open: function() {
                $(this).load(self.uploadFileUrlPartial);
            },
            buttons: {
                "OK": function () {
                    $(this).dialog("close");
                }
             
            }
        });
    });


   
};
