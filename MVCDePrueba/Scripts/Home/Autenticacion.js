
$(document).ready(function () {

    $("#btnAutenticar").on("click", function () {
        var parameters = {
            UserName: $("#txtUserName").val(),
            Pass: $("#txtPass").val()
        };

        $.ajax({
            url: '/Home/AutenticacionDeUsuario',
            cache: false,
            type: 'POST',
            dataType: 'json',
            data: parameters,
            success: function (r) {
                if (r.Result.Success) {
                    location.href = "/Home/Index";
                }
                else {
                    alert(r.Result.ErrorMessage);
                }

                console.log(r);
                
            },
            error: function (e) {
                console.log(e);
            }
        });
    });

});