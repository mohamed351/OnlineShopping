var tableContent = tablePlugin("#categoryTable", "/Admin/Companies/GetCompanies", [
            { data: "name" },
            {data:"arabicName"},
            {
                data: "id", render: function (result) {
                    return `
                                                <button class="btn btn-primary btn-edit" data-id="${result}"> Edit </button>
                                                <button class="btn btn-danger btn-delete" data-id="${result}">Delete </button>
                                            `
                }
            }
      ]);
        console.log(tableContent);
        $("#createInstructor").on("click", function () {
            $.ajax({
                url: "/Admin/Companies/Create",
                method: "GET",
                success: function (result) {
                    $("#model-content").html(result);
                    $("#companyModel").modal("show");
                    var form = $("#InstructorForm");
                    form.removeData('validator');
                    form.removeData('unobtrusiveValidation');
                    $.validator.unobtrusive.parse(form);


                }
            });

        });
        $(document).on("click", ".btn-edit", function () {
            let currentID = $(this).attr("data-id");
            $.ajax({
                url: "/Admin/Companies/Edit",
                method:"GET",
                data: {
                    id:currentID
                },
                success: function (result) {
                    $("#model-content").html(result);
                    $("#companyModel").modal("show");
                    var form = $("#InstructorForm");
                    form.removeData('validator');
                    form.removeData('unobtrusiveValidation');
                    $.validator.unobtrusive.parse(form);

                }
            });
        });
        $(document).on("click", ".btn-delete", function () {

            let currentID = $(this).attr("data-id");
            bootbox.confirm("Are you sure to delete this Company ", function (alertData) {
                if (alertData) {
                    $.ajax({
                        url: "/Admin/Companies/Delete",
                        method: "POST",
                        data: {
                            id: currentID
                        },
                        success: function (result) {

                            Deleted();

                        }
                    });
                }
            });

        });

        function Added(data) {

            $("#companyModel").modal("hide");
            swal("successful added Quantity Type", "", "success");
            tableContent.ajax.reload();



        }
        function Edited(data) {
            $("#companyModel").modal("hide");
            swal("successful edit Company", "", "success");
            tableContent.ajax.reload();
        }
        function Deleted() {

            swal("successful delete Company", "", "success");
            tableContent.ajax.reload();


        }
