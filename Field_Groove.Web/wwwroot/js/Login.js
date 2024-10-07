function ValidateLogin() {
    var $form = $('#LoginForm');
    var Email = $('#Email', $form).val();
    var Password = $('#Password', $form).val();

    $.ajax({
        url: '/Account/Login',
        type: 'POST',
        data:
        {
            Email: Email,
            Password: Password
        },
        success: function (response) {
            $('#ValidationSummary').append(<li>response</li>);
            console.log(response);

        },
        error: function (response) {
            console.log("Failed")
        }
    });

    return false;
}