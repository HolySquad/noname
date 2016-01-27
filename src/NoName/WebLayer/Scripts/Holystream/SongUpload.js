function FileUpload() {

    var self = this;

    var internal = {
        uploadInputId: "#uploadForm"
    };

    self.uploadFileUrl = "";
    self.uploadFileUrlPartial = "";


    $('.uploadBtn').on('click', function () {
        $("#uploadForm").load(self.uploadFileUrlPartial);
    });
};
