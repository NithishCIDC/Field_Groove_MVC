function ValidateLogin() {
    var $form = $('#LoginForm');

    $.ajax({
        url: '/Account/Login',
        type: 'POST',
        data:
        {
            Email: $('#Email', $form).val(),
            Password: $('#Password', $form).val()
        },
        success: function (response) {
            if (response.length == 0) {
                window.location.href = "/Account/Dashboard";
            }
            else {
                $Validation = $('#ValidationSummary')
                $($Validation).empty();
                response.forEach(function (res) {
                    $($Validation).append(`<li>${res}</li>`);
                });
            }
        },
        error: function (response) {
            alert('Some Internal Error Occurs');
        }
    });
}