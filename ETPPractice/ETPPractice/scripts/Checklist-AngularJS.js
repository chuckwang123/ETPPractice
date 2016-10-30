var app = angular.module('myApp', []);
app.controller('RoleCtrl', function ($scope, $http) {
    $http.get("http://localhost:50022/api/Contact/Roles")
    .then(function (response) { $scope.roles = response.data; });
});

app.controller('AccessCtrl', function ($scope, $http) {
    $http.get("http://localhost:50022/api/Service/Category")
    .then(function (response) { $scope.accesses = response.data; });
});

app.controller('MigrationCtrl', function ($scope, $http) {
    $http.get("http://localhost:50022/api/migration/dictionary")
    .then(function (response) { $scope.migrations = response.data; });
});

app.controller('DocumentationCtrl', function ($scope, $http) {
    $http.get("http://localhost:50022/api/Documentation/Category")
    .then(function (response) { $scope.documentations = response.data; });
});

$("#submit")
    .click(function () {
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

        $("#RoleTable > tbody  > tr")
            .each(function () {
                if ($(this).find('[name="name"]').val() === '') {
                    return;
                }
                var contactInfo = {
                    role_ID: $(this).attr('Id'),
                    Name: $(this).find('[name="name"]').val() === '' ? ' ' : $(this).find('[name="name"]').val(),
                    Email: $(this).find('[name="email"]').val() === '' ? ' ' : $(this).find('[name="email"]').val(),
                    org_position: $(this).find('[name="org_position"]').val() === ''
                        ? ' '
                        : $(this).find('[name="org_position"]').val()
                };

                checklist.ContactInfos.push(contactInfo);
            });

        $("#AccessTable > tbody  > tr")
            .each(function () {
                if ($(this).find('[name="Validate_By"]').val() === '') {
                    return;
                }
                var accessInfo = {
                    service_id: $(this).attr('Id'),
                    validate_by: $(this).find('[name="Validate_By"]').val() === ''
                        ? ' '
                        : $(this).find('[name="Validate_By"]').val(),
                    access_date: $(this).find('[name="Access_Date"]').val() === ""
                        ? " "
                        : $(this).find('[name="Access_Date"]').val(),
                    notes: $(this).find('[name="Notes"]').val() === '' ? ' ' : $(this).find('[name="Notes"]').val()
                };
                checklist.Serviceses.push(accessInfo);
            });

        $("#migrationTable > tbody  > tr")
            .each(function () {
                if ($(this).find('[name="IsSendFile"]').val() === '') {
                    return;
                }
                var migrationInfo = {
                    dictionary_Id: $(this).attr('Id'),
                    IsSendFile: $(this).find('[name="IsSendFile"]').val() === ''
                        ? ' '
                        : $(this).find('[name="IsSendFile"]').val(),
                    Reason: $(this).find('[name="Reason"]').val() === "" ? " " : $(this).find('[name="Reason"]').val(),
                    reviewed_migration: $(this).find('[name="reviewed_migration"]').val() === ''
                        ? ' '
                        : $(this).find('[name="reviewed_migration"]').val(),
                    export_info: $(this).find('[name="export_info"]').val() === ''
                        ? ' '
                        : $(this).find('[name="export_info"]').val()
                };
                checklist.Files.push(migrationInfo);
            });

        $('#documentationTable > tbody  > tr')
            .each(function () {
                if ($(this).find('[name="Reviewed_By"]').val() === '') {
                    return;
                }
                var documentationInfo = {
                    documentation_id: $(this).attr('Id'),
                    reviewed_by: $(this).find('[name="Reviewed_By"]').val() === ''
                        ? ' '
                        : $(this).find('[name="Reviewed_By"]').val(),
                    access_date: $(this).find('[name="Access_Date"]').val() === ""
                        ? " "
                        : $(this).find('[name="Access_Date"]').val()
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
    });