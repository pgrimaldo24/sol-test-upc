 
function grabar() { 
    var nombres = document.getElementById('txtnombres').value;
    var apellidos = document.getElementById('txtapellidos').value;
    var numdoc = document.getElementById('txtnumerodocumento').value;
    var telefono = document.getElementById('txttelefono').value;
    var email = document.getElementById('txtemail').value;
    var direccion = document.getElementById('txtdireccion').value;
    var dpdTipoAlumno = document.getElementById("dpdTipoAlumno").value;
    var dpdTipoLectura = document.getElementById("dpdTipoLectura").value;
    var txtFechaDevolucion = document.getElementById("txtFechaDevolucion").value;

    var entity = new FormData();
        entity.append('nombres', nombres);
        entity.append('apellidos', apellidos); 
        entity.append('numdoc', numdoc); 
        entity.append('telefono', telefono); 
        entity.append('email', email); 
        entity.append('direccion', direccion); 
        entity.append('dpdTipoAlumno', dpdTipoAlumno); 
        entity.append('dpdTipoLectura', dpdTipoLectura); 
        entity.append('txtFechaDevolucion', txtFechaDevolucion); 
    $.ajax({
        type: 'POST',
        url: '/Solicitud/RegisterLoanApplication',
        contentType: 'application/x-www-form-urlencoded',
        async: true,
        cache: false,
        processData: false,
        contentType: false,
        data: entity,
        success: function (data) { 
            let response; 
            response = JSON.parse(data); 
            console.log(response); 
            if (response.Status == 200) {
                alert("La solicitud se registró correctamente.");
                window.location = "/Home/Index";
            }   
        }, error: function (xhr, status, error) {
            return error;
        }
    });


}