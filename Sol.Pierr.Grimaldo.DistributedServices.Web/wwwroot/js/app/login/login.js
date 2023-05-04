$(document).ready(function () {
     
    $("#usuario").keyup(function (event) {
        if (event.which === 13) {
            $("#btnLogin").click();
            $('#btnLogin').focus();
        }
    });

    $("#password").keyup(function (event) {
        if (event.which === 13) {
            $("#btnLogin").click();
            $('#btnLogin').focus();
        }
    });
     
});
 
function userAuthentication() { 
    var user = document.getElementById('usuario').value;
    var password = document.getElementById('password').value;

    var userData = new FormData();
        userData.append('user', user);
        userData.append('password', password); 

    $.ajax({
        type: 'POST',
        url: '/Login/AutenticacionUsuario',
        contentType: 'application/x-www-form-urlencoded',
        async: true,
        cache: false,
        processData: false,
        contentType: false,
        data: userData,
        success: function (data) { 
            let response;
            response = JSON.parse(data); 
            console.log(response);  
            window.location = "/Home/Index";
        }, error: function (xhr, status, error) {
            return error;
        }
    });


}