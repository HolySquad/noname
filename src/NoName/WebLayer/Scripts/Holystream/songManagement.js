function SongManagementVm() {
    var self = this;

    self.deleteSongUrl = "";
    self.deleteSongUrlPartial = "";

    var internal = {
        contentType: 'application/json; charset=utf-8',
    };

    self.delete = function (item) {
        var title = 'Are you sure to delete this?';
        $.confirm(title,
            "Delete this song?",
            function(confirmed) {
                if (confirmed) {
                    $.ajax({
                        type: 'POST',
                        url: self.deleteSongUrl,
                        contentType: internal,
                        data: item,
                        success: function(result) {
                            window.location.reload();
                        }
                });
                }
            });
    };

};