
$(document).ready(function () {

    initialListarClientes();

});


function initialListarClientes() {


    $.ajax({
        type: 'GET',
        url: '/Reporte/GetAll',
        contentType: 'application/x-www-form-urlencoded',
        async: true,
        cache: false,
        processData: false,
        contentType: false,
        /*data: object_usuario,*/
        success: function (data) {

            var response = JSON.parse(data);

            var iddatatableusers = $('#datatablereporte').DataTable({
                destroy: true,
                responsive: false,
                scrollCollapse: true,
                lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]],
                processing: true,
                searching: false,
                data: response,
                columns: [
                    { title: "ID PRESTAMO", data: "IDPRESTAMO", className: "colum_center" },
                    { title: "ID LIBRO", data: "IDLIBRO", className: "colum_center" },
                    { title: "NOMBRE LIBRO", data: "NOMBRELIBRO", className: "colum_center" },
                    { title: "FECHA PRESTAMO", data: "FECHAPRESTAMO", className: "colum_center" },
                    { title: "DNI", data: "DNI", className: "colum_center" },
                    { title: "NOMBRE USUARIO", data: "NOMBREUSUARIO", className: "colum_center" },
                    { title: "APELLIDO USUARIO", data: "APELLIDOUSUARIO", className: "colum_center" },
                    { title: "TIPO USUARIO", data: "TIPOUSUARIO", className: "colum_center" },
                    { title: "TIPO LECTURA", data: "TIPOLECTURA", className: "colum_center" },
                    { title: "FECHA DEVOLUCION", data: "FECHADEVOLUCION", className: "colum_center" },

                ],
                language: {
                    "searchPlaceholder": "",
                    "decimal": "",
                    "emptyTable": "No hay información",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                    "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                    "infoFiltered": "",
                    "infoPostFix": "",
                    "thousands": ",",
                    "lengthMenu": "",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "",
                    "zeroRecords": "Sin resultados encontrados",
                    "paginate": {
                        "first": "Primero",
                        "last": "Ultimo",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                },
            });


        }, error: function (xhr, status, error) {
        }
    });
}