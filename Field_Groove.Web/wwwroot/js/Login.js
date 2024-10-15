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
            if (response.success == true) {
                sessionStorage.setItem("token", response.message);
                window.location.href = "Home/Dashboard";
            }
            else {
                $Validation = $('#ValidationSummary')
                $($Validation).empty();
                response.message.forEach(function (res) {
                    $($Validation).append(`<li>${res}</li>`);
                });
            }
        },
        error: function () {
            alert('Some Internal Error Occurs');
            window.location.href="/Account/Login"
        }
    });
    return false;
}