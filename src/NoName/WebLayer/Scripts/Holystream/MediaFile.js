function MediaFileCall() {
    var self = this;

    var internal = {
        addFileForm: "#addFileForm",
        fileUploadDialogId: "filesUploadForm"
    };
    self.addFileUrl = "";
    self.detailsFileUrl = "";
    self.deleteFilesUrl = "";

    self.uploadFile = function () {
        $(internal.fileUploadDialogId).load(self.addFileUrl).dialog('open');
    };
   
    internal.upload = function() {

    };
};