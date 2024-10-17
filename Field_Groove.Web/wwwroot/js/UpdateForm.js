function UpdateForm() {
    var $form = $('#UpdateFormID');

    $.ajax({
        url: '/Home/Edit',
        type: 'POST',
        data:
        {
            Id =  $('#modelID', $form).val(),
            ProjectName =  $('#modelProjectName', $form).val(),
            Status =  $('#modelStatus', $form).val(),
            Added =  $('#modelAdded', $form).val(),
            Contact =  $('#modelContact', $form).val(),
            Action =  $('#modelAction', $form).val(),
            Assignee =  $('#modelAssignee', $form).val(),
            BidDate =  $('#modelBidDate', $form).val(),
        },
        success: function (response) {
            if (response.success == true) { 
                window.location.href = "Home/Leads";
            }
            else {
                alert("Error in Update");
            }
        },
        error: function () {
            alert('Some Internal Error Occurs');
            window.location.href = "/Home/Leads"
        }
    });
    return false;
}