$(document).ready(function () {
    var tabla = new DataTable('#tblPublicaciones');
    GetAllPublicaciones();
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