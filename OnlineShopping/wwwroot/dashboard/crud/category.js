 var tableContent = tablePlugin("#categoryTable", "/Admin/Categories/GetCateogry", [
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
                url: "/Admin/Categories/Create",
                method: "GET",
                success: function (result) {
                    $("#model-content").html(result);
                    $("#categoryModel").modal("show");
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
                url: "/Admin/Categories/Edit",
                method:"GET",
                data: {
                    id:currentID
                },
                success: function (result) {
                    $("#model-content").html(result);
                    $("#categoryModel").modal("show");
                    var form = $("#InstructorForm");
                    form.removeData('validator');
                    form.removeData('unobtrusiveValidation');
                    $.validator.unobtrusive.parse(form);

                }
            });
        });
        $(document).on("click", ".btn-delete", function () {

            let currentID = $(this).attr("data-id");
            bootbox.confirm("Are you sure to delete this Instructor", function (alertData) {
                if (alertData) {
                    $.ajax({
                        url: "/Admin/Categories/Delete",
                        method: "POST",
                        data: {
                            id: currentID
                        },
                        success: function (result) {

                            categoryDeleted();

                        }
                    });
                }
            });

        });

        function categoryAdded(data) {

            $("#categoryModel").modal("hide");
            swal("successful added Category", "", "success");
            tableContent.ajax.reload();



        }
        function categoryEdited(data) {
            $("#categoryModel").modal("hide");
            swal("successful edit Category", "", "success");
            tableContent.ajax.reload();
        }
        function categoryDeleted() {

            swal("successful delete Category", "", "success");
            tableContent.ajax.reload();


        }
