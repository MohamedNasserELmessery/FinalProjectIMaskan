ShowInPopUp = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal("show");
        }
    })
}

ShowInPopUpEdit = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {//Edit 
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal("show");
        }
    })
}


EditPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,/////
            data: new FormData(form),//// 
            contentType: false,////
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                    //window.location.reload();
                    //$('#view-all').load("../posts/GetPosts");
                }
                else
                    $('#form-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}

DeletePost = (id) => {
    if (confirm("Are You Sure ? ") == true) {
        $.ajax({
            type: "POST",
            url: "Posts/Delete/" + id,
            success: function (res) {
                if (res.isValid) {
                    //alert("Are You Sure ?? ");
                    $('#view-all').html(res.html)
                    //$('#view-all').load("../posts/Index");

                } else
                    alert("Error");
            }
        })
        return false;
    }
}



ShowProfileEditPopUp = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {//Edit 
            $('#Profile-modal .modal-body').html(res);
            $('#Profile-modal .modal-title').html(title);
            $('#Profile-modal').modal("show");
        }
    })
}


EditProfile = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,/////
            data: new FormData(form),//// 
            contentType: false,////
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-profile').html(res.html)
                    $('#Profile-modal .modal-body').html('');
                    $('#Profile-modal .modal-title').html('');
                    $('#Profile-modal').modal('hide');
                    //window.location.reload();
                    //$('#view-all').load("../posts/GetPosts");
                }
                else
                    $('#Profile-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}