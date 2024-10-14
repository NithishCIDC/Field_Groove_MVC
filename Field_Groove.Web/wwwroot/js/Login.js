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

                $.ajax({
                    url: '/Home/Dashboard',
                    type: 'GET',
                    headers: {
                        "Authorization": "Bearer " + sessionStorage.getItem("token")
                    },
                    success: function (response) {
                        $('body').html(response);
                        window.history.pushState({},'','/Home/Dashboard');
                    },
                    error: function () {
                        alert("Error While Accessing Dashboard");
                    }
                });
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