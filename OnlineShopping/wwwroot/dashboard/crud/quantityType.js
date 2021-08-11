var tableContent = tablePlugin("#categoryTable", "/Admin/QuantityType/GetQuantityTypes", [
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
                url: "/Admin/QuantityType/Create",
                method: "GET",
                success: function (result) {
                    $("#model-content").html(result);
                    $("#quantityTypeModel").modal("show");
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
                url: "/Admin/QuantityType/Edit",
                method:"GET",
                data: {
                    id:currentID
                },
                success: function (result) {
                    $("#model-content").html(result);
                    $("#quantityTypeModel").modal("show");
                    var form = $("#InstructorForm");
                    form.removeData('validator');
                    form.removeData('unobtrusiveValidation');
                    $.validator.unobtrusive.parse(form);

                }
            });
        });
        $(document).on("click", ".btn-delete", function () {

            let currentID = $(this).attr("data-id");
            bootbox.confirm("Are you sure to delete this Quantity Type", function (alertData) {
                if (alertData) {
                    $.ajax({
                        url: "/Admin/QuantityType/Delete",
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

            $("#quantityTypeModel").modal("hide");
            swal("successful added Quantity Type", "", "success");
            tableContent.ajax.reload();



        }
        function Edited(data) {
            $("#quantityTypeModel").modal("hide");
            swal("successful edit Quantity Type", "", "success");
            tableContent.ajax.reload();
        }
        function Deleted() {

            swal("successful delete Quantity Type", "", "success");
            tableContent.ajax.reload();


        }
