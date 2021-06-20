// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#myInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#myTable tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});

$(function () {
    //Assign Click event to Button.
    $("#btnGet").click(function () {
        var message = new Array();

        //Loop through all checked CheckBoxes in GridView.
        $("#myTable input[type=checkbox]:checked").each(function () {
            var row = $(this).closest("tr")[0];
            message.push(row.cells[1].innerText);
        });

        //$.ajax({
        //    type: "POST",
        //    url: "/payments/add",
        //    data: message.Serialize(), // serializes the form's elements.
        //    success: function (data) {
        //        alert(data); // show response from the php script.
        //    }
        //});
        //Display selected Row data in Alert Box.
        alert(message);
        return false;
    });
});