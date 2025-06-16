$(document).ready(function () {
    //var tabla = new DataTable('#tblPublicaciones');
    $('#tblPublicaciones').dataTable({
        processing: true,
        destroy: true,
        paging: true,
        searching: true,
        columns: [
            { "data": "id" },
            { "data": "titulo" },
            { "data": "autor" }, 
            {
                data: "id", render: function (data, a, b, c) {
                    return '<a href="/Publicaciones/Crud/' + data + '" class="btn btn-success">Editar</a>';
                }
            }
        ]


    });
    GetAllPublicaciones();

    $('#tblAutomovil').dataTable({
        processing: true,
        destroy: true,
        paging: true,
        searching: true,
        columns: [
            { "data": "id" },
            { "data": "marca" },
            { "data": "modelo" },
            { "data": "anio" },
            { "data": "color" },
            { "data": "precio" },
            { "data": "condicion" },
            { "data": "tCombustible" },
            {
                data: "id", render: function (data, a, b, c) {
                    return '<a href="/Automovil/Crud/' + data + '" class="btn btn-success">Editar</a>';
                }
            }
        ]
    });
    GetAllAutomovil();
});
function GetAllPublicaciones() {
    GetMVC('/Home/GetAllPublicacionces', function (response) {
        console.log(response);
        if (response.Result.Success) {
            MapingPropertiesDataTable('tblPublicaciones', response.Response);
        }
        else {
            alert(response.Result.ErrorMessage);
        }
    });
}
function GetAllAutomovil() {
    GetMVC('/Home/GetAllAutomovil', function (response) {
        console.log(response);
        if (response.Result.Success) {
            MapingPropertiesDataTable('tblAutomovil', response.Response);
        }
        else {
            alert(response.Result.ErrorMessage);
        }
    });
}