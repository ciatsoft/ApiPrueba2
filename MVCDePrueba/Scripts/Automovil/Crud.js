$(document).ready(function () {
    // Agregar regla para campos con clase 'requerido' y que no se repitan
    $.validator.addClassRules("requerido", {
        required: true
    });

    $("#Marca, #Modelo, #Condicion, #Color, #TCombustible").addClass("requerido");

    // Método para decimales positivos
    $.validator.addMethod("positiveDecimal", function (value, element) {
        return this.optional(element) || /^\d+(\.\d+)?$/.test(value);
    }, "Por favor ingresa un precio válido (e.g. 12.34)");

    ValidadorDeDatos();
});

function ValidadorDeDatos() {
    $("#frmAutomovilCrud").validate({
        rules: {
            "Anio": {
                required: true,
                digits: true
            },
            "Precio": {
                required: true,
                positiveDecimal: true
            }
        },
        messages: {
            Precio: {
                required: "Por favor ingresa un precio",
                positiveDecimal: "Por favor ingresa un valor positivo decimal"
            }
            Anio: {
                required: "Por favor ingresa un año",
                digits: "Por favor ingresa un número"
            }
        }
    });
}