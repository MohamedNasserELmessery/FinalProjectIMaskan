
showpop = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {//
            $('#form-modal1 .modal-body1').html(res);//Form
            $('#form-modal1 .modal-title1').html(title);//title
            $('#form-modal1').modal("show");
        }
    })
}

ShowInPopEdit = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {//Edit 
            $('#form-modal1 .modal-body1').html(res);
            $('#form-modal1 .modal-title1').html(title);
            $('#form-modal1').modal("show");
        }
    })
}




EditR = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,/////"../posts//action"
            data: new FormData(form),//// 
            contentType: false,////
            processData: false,
            success: function (res) {//AllData //AllPosts
                if (res.isValid) {
                    //$('#view-all2').html(res.html)//json
                    $('#form-modal1 .modal-body1').html('');
                    $('#form-modal1 .modal-title1').html('');
                    $('#form-modal1').modal('hide');
                    regionDataTable.ajax.reload();
                    categoryDatatable.ajax.reload();
                    cityDatatable.ajax.reload();
                    //window.location.reload();
                    //$('../posts/index').load("../posts/Index");
                }
                else
                    $('#form-modal1 .modal-body1').html(res.html);//one json obj
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

DeleteR = (id) => {
    $.ajax({
        type: "GET",
        url: "../Regions/Delete/" + id,
        success: function (res) {
            if (res.isValid) {
                $('#view-all2').html(res.html)
                window.location.reload();
            } else
                alert("Error");
        }
    })
}

Deletecity = (id) => {
    $.ajax({
        type: "GET",
        url: "../Cities/Delete/" + id,
        success: function (res) {
            if (res.isValid) {
                $('#view-all2').html(res.html)
                window.location.reload();
            } else
                alert("Error");
        }
    })
}


DeleteCategories = (id) => {
    $.ajax({
        type: "GET",
        url: "../Categories/Delete/" + id,
        success: function (res) {
            if (res.isValid) {
                $('#view-all2').html(res.html)
                window.location.reload();
            } else
                alert("Error");
        }
    })
}

EditRole = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,/////"../posts//action"
            data: new FormData(form),//// 
            contentType: false,////
            processData: false,
            success: function (res) {//AllData //AllPosts
                if (res.isValid) {
                    $('#view-role').html(res.html)//json
                    $('#form-modal1 .modal-body1').html('');
                    $('#form-modal1 .modal-title1').html('');
                    $('#form-modal1').modal('hide');
                    //window.location.reload();
                    //$('../posts/index').load("../posts/Index");
                }
                else
                    $('#form-modal1 .modal-body1').html(res.html);//one json obj
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
Deleterole = (id) => {
    $.ajax({
        type: "GET",
        url: "../Roles/Delete/" + id,
        success: function (res) {
            if (res.isValid) {
                $('#view-role').html(res.html)
            } else
                alert("Error");
        }
    })
}
