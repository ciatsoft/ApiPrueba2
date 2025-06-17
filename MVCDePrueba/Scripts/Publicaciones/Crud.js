$(document).ready(function () {
    ValidadorDeDatos();
});

function ValidadorDeDatos() {
    $("#frmPublicacionesCrud").validate({
        rules: {
            "Titulo": {
                required: true
            },
            "Autor": {
                required: true,
                maxlength: 5
            }
        },
        messages: {
            Titulo: "El campo titulo es requerido",
            "Autor": {
                required: "El campo es requerido",
                maxlength: "No puedes ingresar más de 5 caracteres"
            }
        }
    });
}