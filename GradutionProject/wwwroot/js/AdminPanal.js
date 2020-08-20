//Posts Table
var SelectedPostId = 0;
datatable = $('#Alaa').DataTable({
    responsive: true,
    select: true,
    pageLength: 3,
        ajax: {
            url: '/Admin/GetAllPosts',
            dataSrc: ''
        },
        columns: [
            {
                title: "Post ID",
                data: "post_Id",
                visible: false


            },
            {
                title: "Post Title",
                data: "post_Title",
                width: "40%",

            },
            {
                title: 'Date Of Post',
                data: 'post_Create_Date',
                width: "20%",

            },
                
            { title: 'Price ', data: 'price', width: "10%", },

            {
                data: "post_Id", title: "Delete", width: "10%", render: function (data) {
                    return '<button class="btn btn-danger" onclick="DeletePost(' + data + ')">Delete</button>'
                }
            },
            {
                data: "post_Id", title: "Details", width: "10%", render: function (data) {
                    return '<button class="btn btn-success" onclick="Details(' + data + ')">Details</button>'

                }
            },

        ]
    });
//End Of Posts Table

function DeletePost(id) {
    if (confirm("Are You Sure ? ") == true) {
        $.get("/Admin/DeletePosts", { id: id }, function (res) {
            if (res) {
                datatable.ajax.reload();
            }
        });
    }
}


function Details(id) {

    window.open("/Posts/Details?id=" + id);
}

//Messages Table
messagesDataTable = $('#mess').DataTable({
    responsive: true,
    pageLength: 3,
    //"bDestroy": true,
    ajax: {
        url: '/Admin/GetAllMessages',
        dataSrc: ''
    },
    columns: [
        {
            title: "Message ID",
            data: "messageId",
            visible: false
        },
        {
            title: "User Message",
            data: "message",
            width: "60%",

        },
        {
            title: 'User Name',
            data: 'userName',
            width: "20%",

        },

        {
            title: 'Email ',
            data: 'email',
            width: "20%",
        },

        {
            data: "messageId",
            title: "Delete",
            width: "10%", render: function (data) {
                return `<button class="btn btn-danger" onclick="DeleteMessage(${data})">Delete</button>`
            }
        },
       
    ]
});
//End Of Posts Table

function DeleteMessage(id) {
    if (confirm("Are You Sure ? ") == true) {
        $.get("/Admin/DeleteMessage", { id: id }, function (res) {
            if (res) {
                messagesDataTable.ajax.reload();
            }
        });
    }
}


regionDataTable = $('#region').DataTable({
    responsive: true,
    pageLength: 3,
    //"bDestroy": true,
    ajax: {
        url: '/Admin/GetAllRegions',
        dataSrc: ''
    },
    columns: [
        {
            title: "Region ID",
            data: "regionId",
            visible: false
        },
        {
            title: "Region Name",
            data: "regionName",
            width: "30%",
        },
        {
            title: "Posts in Region",
            data: "count",
            width: "30%",
        },
        {
            data: "city_name",
            title: "City Name",
            width: "10%",
            //render: function (data) {
            //    return `<img src="../images/${data}" width="100" height="50" />`
            //}
        },
        {
            data: "imgPath",
            title: "Image",
            width: "10%",
            render: function (data) {
                return `<img src="../images/${data}" width="100" height="50" />`
            }
        },
        {
            data: "regionId",
            title: "Edit",
            width: "10%", render: function (data) {
                return `<button class="btn btn-success" onclick="ShowInPopEdit('https://localhost:44360/Regions/Edit/${data}','Edit Region')">Edit</button>`
            }
        },

        {
            data: "regionId",
            title: "Delete",
            width: "10%", render: function (data) {
                return `<button class="btn btn-danger" onclick="DeleteRegion(${data})">Delete</button>`
            }
        },
        //{
        //    data: "regionId",
        //    title: "Delete Posts",
        //    width: "20%", render: function (data) {
        //        return `<button class="btn btn-danger" onclick="DeleteRegionPosts(${data})">Delete Posts</button>`
        //    }
        //},
        

    ]
});
//confirm("By deleting this region you will delete all related posts to this region ?") == true
function DeleteRegion(id) {
    swal("By Deleting this region you will delete all related posts to this region", {
        buttons: {
            cancel: "Cancel",
            ok: true,
        },
    }).then((value) => {
        switch (value) {
            case "ok":
                $.get("/Admin/DeleteRegionAndPosts", { id: id }, function (res) {
                    if (res == true) {
                        swal({
                            title: "Region Deleted successfully",
                            text: "",
                            icon: "success",
                        });
                        regionDataTable.ajax.reload();
                        swal("Region Deleted successfully!", "", "success");
                    }
                    //else {
                    //    swal({
                    //        title: "Can't Delete this Region becuase it's contain posts",
                    //        text: "",
                    //        icon: "error",
                    //    });
                    //}
                });
                break;
        }
    })

}

function DeleteRegionPosts(id) {
    if (confirm("Are You Sure ? ") == true) {
        $.get("/Admin/DeleteRegionPosts", { id: id }, function (res) {
            if (res == true) {
                swal({
                    title: "Region Deleted successfully",
                    text: "",
                    icon: "success",
                });
                regionDataTable.ajax.reload();

            }
        });
    }
}



//Region Table 

var datatable1;
//$(Document).ready(function () {
cityDatatable = $('#city').DataTable({
         responsive: true,
        pageLength: 3,
        ajax: {
            url: '/Admin/GetAllCities',
            dataSrc: ''
        },
        columns: [
            {
                title: "City ID",
                data: "city_id",
                width: "15%", 
                visible: false

            },
            {
                title: "City Name",
                data: "city_name",
                width: "40%", 
            },
            {
                title: " Regions",
                data: "count",
                width: "10%", 
            },
            {
                data: "city_id",
                title: "Edit",
                width: "10%", render: function (data) {
                    return `<button class="btn btn-success" onclick="ShowInPopEdit('https://localhost:44360/Cities/Edit/${data}','Edit Region')">Edit</button>`
                }
            },
            {
                data: "city_id",
                title: "Delete",
                width: "10%",
                render: function (data) {
                    return `<button class="btn btn-danger" onclick="DeleteCity(${data})">Delete</button>`
                }
            },
        ]
    });
//});
//if (confirm("By deleting this city you will delete all related posts to this city ? ") == true) {
//confirm("By deleting this city you will delete all related posts to this city ? ") == true
function DeleteCity(id) {
    
    swal("By Deleting this city you will delete all related posts to this region", {
        buttons: {
            cancel: "Cancel",
            ok: true,
        },
    }).then((value) => {
        switch (value) {
            case "ok":
                $.get("/Admin/DeleteCity", { id: id }, function (res) {
                    if (res == true) {
                        swal({
                            title: "City Deleted successfully",
                            text: "",
                            icon: "success",
                        });
                        cityDatatable.ajax.reload();
                    }
                });
                break;
        }
    })
}
//End OF Region Table



//Comments Table
var datatable2;
datatable2 = $('#Alaa2').DataTable({
    responsive: true,
    pageLength: 3,
    ajax: {
        url: '/Admin/GetAllComments',
        dataSrc: '',
        data: {
            "id": function () { return SelectedPostId },
        }
    },

    columns: [
        {
            title: "ID",
            data: "commentId",
            width: "10%", 
            visible: false
        },
        {
            title: "body",
            data: "commentBody",
            width: "70%", 

        },
        {
            title: "Date",
            data: "commentDate",
            width: "10%", 
        },
        {
            data: "commentId", title: "Delete", width: "10%", render: function (data) {
                return '<button class="btn btn-danger" onclick="DeleteComment(' + data + ')">Delete</button>'
            }
        },
    ]
});
//End Of Comment Table


function DeleteComment(id) {
    if (confirm("Are You Sure ? ") == true) {
        $.get("/Admin/DeleteComment", { id: id }, function (res) {
            if (res) {
                swal({
                    title: "Comment Deleted successfully",
                    text: "",
                    icon: "success",
                });
                datatable2.ajax.reload();
            }
        });
    }
}


//Categories Table
//var datatable3;
categoryDatatable = $('#category').DataTable({
    responsive: true,
    pageLength: 3,
    ajax: {
        url: '/Admin/GetAllCategories',
        dataSrc: ''
    },
    columns: [
        {
            title: "ID",
            data: "categoryId",
            width: "10%", 
            visible: false


        },
        {
            title: "Cateroy Name",
            data: "categoryName",
            width: "50%", 

        },
        {
            title: " Posts",
            data: "count",
            width: "10%", 

        },
        {
            data: "categoryId",
            title: "Edit",
            width: "10%", render: function (data) {
                return `<button class="btn btn-success" onclick="ShowInPopEdit('https://localhost:44360/Categories/Edit/${data}','Edit Category')">Edit</button>`
            }
        },
        {
            data: "categoryId",
            title: "Delete",
            width: "10%", render: function (data) {
                return `<button class="btn btn-danger" onclick="DeleteCategory(${data})">Delete</button>`
            }
        },
        
    ]
});
//End Of Categories Table


function DeleteCategory(id) {
    swal("By Deleting this category you will delete all related posts to this region", {
        buttons: {
            cancel: "Cancel",
            ok: true,
        },
    }).then((value) => {
        switch (value) {
            case "ok":
                $.get("/Admin/DeleteCategory", { id: id }, function (res) {
                    if (res) {
                        categoryDatatable.ajax.reload();
                        swal({
                            title: "Category Deleted successfully",
                            text: "",
                            icon: "success",
                        });
                    }
                });
                break;
        }
    })
}


//AllUsers
var userDatatable;
userDatatable = $('#AllUsers').DataTable({
    responsive: true,
    pageLength: 3,
    ajax: {
        url: '/Admin/GetAllUsers',
        dataSrc: ''
    },
    columns: [
        {
            title: "Ashraf Id ",
            data: "id",
            width: "5%",
            visible: false

        },
        {
            title: "User Name",
            data: "userName",
            width: "10%"


        },
        {
            title: "User Email ",
            data: "email",
            width: "10%"


        },
        {
            title: "User Posts ",
            data: "count",
            width: "5%"


        },
        {
            title: "User Role ",
            data: "roleName",
            width: "5%"
        },
        {
            title: "Another Role ",
            data: "anotherRole",
            width: "5%"
        },
        //{
        //    data: "id", title: " Profile Image", width: "10%", render: function (data) {

        //        return '<img src="images/imgPath" width="50" height="30" " alt="...">'
        //    }
        //},

        {
            data: "id", title: "Delete User", width: "10%", render: function (data) {

                return `<button class="btn btn-danger" onclick="DeleteUser('${data}')"> Delete </button>`
            }
        },
        {
            data: "id", title: "Details", width: "10%", render: function (data) {
                return `<button class="btn btn-success" onclick="UserRoles('${data}')">User Roles</button>`

            }
        },
    ]
});

function DeleteUser(id) {
    if (confirm("Are You Sure ? ") == true) {
        $.get("/Admin/DeleteUser", { id: id }, function (res) {
            if (res == true) {
                swal({
                    title: "User Deleted successfully",
                    text: "",
                    icon: "success",
                });
                userDatatable.ajax.reload();
            }
            else {
                swal({
                    title: "Can't Delete this user",
                    text: "",
                    icon: "error",
                });
            }
        });
    }
}
function UserRoles(id) {

    window.location.assign("/Admin/ManageUserRole?id=" + id);
}

function getSelectedPostId () {
    return SelectedPostId;
}