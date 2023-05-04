
$(document).ready(function () {
 
    initialListarClientes();
     
});


function initialListarClientes() { 
 
     
    $.ajax({
        type: 'GET',
        url: '/Libros/GetLibros',
        contentType: 'application/x-www-form-urlencoded',
        async: true,
        cache: false,
        processData: false,
        contentType: false,
        /*data: object_usuario,*/
        success: function (data) {

            var response = JSON.parse(data);

            var iddatatableusers = $('#datatablelibros').DataTable({
                destroy: true,
                responsive: false,
                scrollCollapse: true,
                lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]],
                processing: true,
                searching: false,
                data: response,
                columns: [
                    { title: "TITULO", data: "TITULO", className: "colum_center" },
                    { title: "AUTOR", data: "AUTOR", className: "colum_center" },
                    { title: "EDITORIAL", data: "EDITORIAL", className: "colum_center" },
                    { title: "PRECIO", data: "PRECIO", className: "colum_center" },
                    { title: "CANTIDAD", data: "CANTIDAD", className: "colum_center" }, 
                    
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