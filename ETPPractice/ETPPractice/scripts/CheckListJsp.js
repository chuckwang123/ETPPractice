var uri = '../api';

$(document).ready(function () {
    // load role table
    $.getJSON(uri + '/Contact/Roles')
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                AddRow(item);
            });
        });

    //load access table
    $.getJSON(uri + '/Service/Category')
        .done(function (data) {
            $.each(data, function (key, item) {
                AddAccessRow(item);
            });
        });

    //load LTTM Dictionary Table
    $.getJSON(uri + '/migration/dictionary')
        .done(function (data) {
            $.each(data, function (key, item) {
                AddDictionaryRow(item);
            });
        });

    //load Documentation Table
    $.getJSON(uri + '/Documentation/Category')
        .done(function (data) {
            $.each(data, function (key, item) {
                AddDocumentationRow(item);
            });
        });
});

function AddRow(item) {
    var newRowContent = "<tr id=" + item.Id + "><td>" + item.Role + "</td><td><input type='text'' name='name'></td>" +
        "<td><input type='text'' name='email'></td><td><input type='text'' name='org_position'></td>";
    $("#RoleTable > tbody:last-child").append(newRowContent);
}

function AddAccessRow(item) {
    var newRowContent = "<tr id=" + item.Id + "><td>" + item.Service_Name + "</td><td><input type='text'' name='Validate_By'></td>" +
        "<td><input type='text'' name='Access_Date'></td><td><input type='text'' name='Notes'></td>";
    $("#AccessTable > tbody:last-child").append(newRowContent);
}

function AddDictionaryRow(item) {
    var newRowContent = "<tr id=" + item.Id + "><td>" + item.Dictionary + "</td><td><input type='text'' name='IsSendFile'></td>" +
        "<td><input type='text'' name='Reason'></td><td><input type='text'' name='reviewed_migration'></td><td><input type='text'' name='export_info'></td>";
    $("#migrationTable > tbody:last-child").append(newRowContent);
}

function AddDocumentationRow(item) {
    var newRowContent = "<tr id=" + item.Id + "><td>" + item.documentation_name + "</td><td><input type='text'' name='Reviewed_By'></td>" +
        "<td>" + item.media_format + "</td><td><input type='text'' name='Access_Date'></td>";
    $("#documentationTable > tbody:last-child").append(newRowContent);
}

$("#submit").click(function () {
    var date = new Date();
    var checklist = {
        CRMOpportunityId: uuid.v4(),
        OrganizationName: "Test",
        WebinarDateTime: date.toJSON(),
        AdditionalContactInfo: "",
        LTTMMarkAllYes: "false",
        ContactInfos: [],
        Documentations: [],
        Serviceses: [],
        Files: []
    };

    $("#RoleTable > tbody  > tr").each(function() {
        if ($(this).find('[name="name"]').val() === '') {
            return;
        }
        var contactInfo = {
            role_ID: $(this).attr('Id'),
            Name: $(this).find('[name="name"]').val() === '' ? ' ' : $(this).find('[name="name"]').val(),
            Email: $(this).find('[name="email"]').val() === '' ? ' ' : $(this).find('[name="email"]').val(),
            org_position: $(this).find('[name="org_position"]').val() === '' ? ' ' : $(this).find('[name="org_position"]').val()
        };

        checklist.ContactInfos.push(contactInfo);
    });

    $("#AccessTable > tbody  > tr").each(function () {
        if ($(this).find('[name="Validate_By"]').val() === '') {
            return;
        }
        var accessInfo = {
            service_id: $(this).attr('Id'),
            validate_by: $(this).find('[name="Validate_By"]').val() === '' ? ' ' : $(this).find('[name="Validate_By"]').val(),
            access_date: $(this).find('[name="Access_Date"]').val() === "" ? " " : $(this).find('[name="Access_Date"]').val(),
            notes: $(this).find('[name="Notes"]').val() === '' ? ' ' : $(this).find('[name="Notes"]').val()
        };
        checklist.Serviceses.push(accessInfo);
    });

    $("#migrationTable > tbody  > tr").each(function () {
        if ($(this).find('[name="IsSendFile"]').val() === '') {
            return;
        }
        var migrationInfo = {
            dictionary_Id: $(this).attr('Id'),
            IsSendFile: $(this).find('[name="IsSendFile"]').val() === '' ? ' ' : $(this).find('[name="IsSendFile"]').val(),
            Reason: $(this).find('[name="Reason"]').val() === "" ? " " : $(this).find('[name="Reason"]').val(),
            reviewed_migration: $(this).find('[name="reviewed_migration"]').val() === '' ? ' ' : $(this).find('[name="reviewed_migration"]').val(),
            export_info: $(this).find('[name="export_info"]').val() === '' ? ' ' : $(this).find('[name="export_info"]').val()
        };
        checklist.Files.push(migrationInfo);
    });

    $('#documentationTable > tbody  > tr').each(function () {
        if ($(this).find('[name="Reviewed_By"]').val() === '') {
            return;
        }
        var documentationInfo = {
            documentation_id: $(this).attr('Id'),
            reviewed_by: $(this).find('[name="Reviewed_By"]').val() === '' ? ' ' : $(this).find('[name="Reviewed_By"]').val(),
            access_date: $(this).find('[name="Access_Date"]').val() === "" ? " " : $(this).find('[name="Access_Date"]').val()
        };
        checklist.Documentations.push(documentationInfo);
    });

    $.ajax({
        url: '/api/CheckList',
        type: 'post',
        dataType: 'json',
        error: function (xhr) {
            $('#Info').text(xhr.responseText);
        },
        success: function () {
            $('#Info').text('It is done!!');
        },
        data: checklist
    });
})