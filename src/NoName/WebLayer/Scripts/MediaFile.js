$(function() {
    //////////////For Evbd///////////////////
    var fullUrl;


    //////////////Creating Form///////////////////
    var createDialog = $("#createS");
    createDialog.dialog({
        autoOpen: false,
        width: 800,
        buttons: [
            {
                text: "Exit",
                click: function() {
                    createDialog.dialog("close");
                }
            }
        ]
    });

    function createSubmit() {
        if ($(this).valid()) {
            var form = $("#create-content form");
            var data = form.serialize();
            $.post(fullUrl, data, function(result, status, xhr) {
                if (xhr.status == 200) {
                    $("#table-container").html(result);
                    $("#create-btn").click(createSong);
                    //$(".edit").click(editCompany);
                    $(".details").click(detailsSong);
                    $(".delete").click(deleteSong);
                    createDialog.dialog("close");
                } else {
                    createDialog.dialog.title("option", "title", "Could not create company. Incomplete or incorrect information.");
                }
            });
        };
    }



    $("#create-btn").click(createSong);

    function createSong(e) {
        e.preventDefault();
        fullUrl = "/Holy/MediaFile/AddFiles";
        $("#create-content").load(fullUrl, function () {
            $("#create-content form").submit(createSubmit);
            $.validator.unobtrusive.parse("#create-content");
            createDialog.dialog("open");
        });
    };



////////////////Editing Form///////////////////
//    var dialogEdit = $("#edit-company");
//    dialogEdit.dialog({
//        autoOpen: false,
//        show: { effect: "clip", duration: 800 },
//        hide: { effect: "clip", duration: 400 },
//        width: 800,
//        buttons: [
//            {
//                text: "Save",
//                click: function() {
//                    var form = $("#edit-content form");
//                    var data = form.serialize();
//                    $.post(fullUrl, data, function(result, status, xhr) {
//                        if (xhr.status == 200) {
//                            $("#table-container").html(result);
//                            $("#create-company-btn").click(createCompany);
//                            $(".edit").click(editCompany);
//                            $(".details").click(detailsCompany);
//                            $(".delete").click(deleteCompany);
//                            dialogEdit.dialog("close");
//                        } else {
//                            dialogEdit.dialog.title("option", "title", "Could not edit company. Incomplete or incorrect information.");
//                        }
//                    });
//                }
//            },
//            {
//                text: "Cancel",
//                click: function() {
//                    dialogEdit.dialog("close");
//                }
//            }
//        ]
//    });


//    $(".edit").click(editCompany);
    
//    function editCompany(e) {
//        e.preventDefault();
//        var id = $(this).attr("id");
//        fullUrl = "/WEB/Companies/Edit/" + id;
//        $("#edit-content").load(fullUrl, function() {
//            $.validator.unobtrusive.parse("#edit-content");
//            dialogEdit.dialog("open");
//        });
//    };

 


    //////////////Details Form///////////////////
    var dialogDetails = $("#detailsS");
    dialogDetails.dialog({
        autoOpen: false,
        width: 800,
        buttons: [
            {
                text: "Thanks",
                click: function () {
                    dialogDetails.dialog("close");
                }
            }

        ]
    });

    $(".details").click(detailsSong);

    function detailsSong(e) {
        e.preventDefault();
        var id = $(this).attr("id");
        fullUrl = "/Holy/MediaFile/Details/" + id;
        $("#details-content").load(fullUrl, function() {
            dialogDetails.dialog("open");
        });
    };


    //////////////Delete Form///////////////////
    var dialogDelete = $("#deleteS");
    dialogDelete.dialog({
        autoOpen: false,
        width: 800,
        buttons: [
            {
                text: "Delete",
                click: function() {
                    $.post(fullUrl, function(result, status, xhr) {
                        if (xhr.status === 200) {
                            $("#table-container").html(result);
                            $("#create-company-btn").click(createSong);
                            //$(".edit").click(editCompany);
                            $(".details").click(detailsSong);
                            $(".delete").click(deleteSong);
                            dialogDelete.dialog("close");
                        } else {
                            alert("Error");
                        }
                    });
                }
            },
            {
                text: "Cancel",
                click: function() {
                    dialogDelete.dialog("close");
                }
            }
        ]
    });

    $(".delete").click(deleteSong);


    function deleteSong(e) {
        e.preventDefault();
        var id = $(this).attr("id");
        fullUrl = "/Holy/MediaFile/Delete/" + id;
        $("#delete-content").load(fullUrl, function() {
            dialogDelete.dialog("open");
        });
    };
});