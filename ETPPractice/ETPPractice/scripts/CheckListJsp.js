var uri = '../api/Contact/Roles';

$(document).ready(function () {
    // Send an AJAX request
    $.getJSON(uri)
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                AddRow(item);
            });
        });
});


function AddRow(item) {
    var newRowContent = "<tr><td>" + item.Role + "</td><td><input type='text'' name='name'></td>" +
        "<td><input type='text'' name='email'></td><td><input type='text'' name='org_Position'></td>";
    $('#RoleTable > tbody:last-child').append(newRowContent);
}
