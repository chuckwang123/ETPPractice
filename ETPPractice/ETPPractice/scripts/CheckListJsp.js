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
    var newRowContent = "<tr id=" + item.Id + "><td>" + item.Role + "</td><td><input type='text'' name='name'></td>" +
        "<td><input type='text'' name='email'></td><td><input type='text'' name='org_position'></td>";
    $('#RoleTable > tbody:last-child').append(newRowContent);
}

$('#submit').click(function() {
    $('#RoleTable > tbody  > tr').each(function() {
        if ($(this).find('[name="name"]').val() === '') {
            return ;
        }
        var contactInfo = {
            checkList_id: 1,
            role_ID: $(this).attr('Id'),
            Name: $(this).find('[name="name"]').val() === '' ? ' ' : $(this).find('[name="name"]').val(),
            Email: $(this).find('[name="email"]').val() === '' ? ' ' : $(this).find('[name="email"]').val(),
            org_position: $(this).find('[name="org_position"]').val() === '' ? ' ' : $(this).find('[name="org_position"]').val()
        };
        $.ajax({
            url: '/api/Contact',
            type: 'post',
            dataType: 'json',
            error: function (xhr) {
                $('#Info').text(xhr.responseText);
            },
            success: function () {
                $('#Info').text('It is done!!');
            },
            
            data: contactInfo
        });
    });  
})