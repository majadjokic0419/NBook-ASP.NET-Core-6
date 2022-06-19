﻿var dataTable;


$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("inprocess")) {
        loadDataTable("inprocess")
    }
    else if (url.includes("pending")) {
        loadDataTable("pending");
    }
    else if (url.includes("completed")) {
        loadDataTable("completed");
    }
    else if (url.includes("approved")) {
        loadDataTable("approved");
    }
    else { loadDataTable("all"); }

});

function loadDataTable(status) {
    dataTable = $('#orderTable').DataTable({
        "ajax": {
            "url": "/Admin/Order/GetAll?status=" + status
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "name", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "applicationUser.email", "width": "15%" },
            { "data": "orderStatus", "width": "15%" },
            { "data": "orderTotal", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 d-flex justify-content-evenly" role="group">
                        <a href="/Admin/Order/Details?orderId=${data}"
                        class="btn btn-sm btn-primary mx-2 ">Details</a>
                       </div>
					</div>
                        `
                },
                "width": "15%"
            }
        ]
    });
}

