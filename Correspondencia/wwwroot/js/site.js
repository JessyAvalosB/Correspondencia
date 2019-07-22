// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
var datos = [];
// Write your JavaScript code.
$(document).ready(function () {
    $(".detail").on("click", function (e) {
        id = $(this).data("id");
        //console.log(id);
        //alert(id);

        $.ajax({
            url: '../../Home/Details?id=' + id,
            success: function (respuesta) {
               console.log("Respuesta: " + respuesta);
                datos = JSON.parse(respuesta);
               // console.log("Datos: " + datos);
                $.each(datos, function (index, item) {
                    //console.log("Folio: " + item.FOLIO);
                    $("#FOLIO").val(item.FOLIO);
                    $("#FECHA").val(item.FECHA_CAPTURA);
                    $("#ESTADO").val(item.ESTADO);
                    $("#NOMBRE").val(item.NOMBRE);
                    $("#CORREO").val(item.CORREO);
                    $("#DIRECCION").val(item.DIRECCION);
                    $("#ORIGEN").val(item.ORIGEN);
                    $("#TIPO").val(item.TIPO);
                    $("#TELEFONO").val(item.TELEFONO);
                    $("#COPIA").val(item.COPIA_FISICA);
                    $("#RESUMEN").text(item.RESUMEN);
                    $("#RESPUESTA").text(item.RESPUESTA);
                    $("#CARGO").val(item.CARGO);
                    $("#IMAGEN").attr("src",item.IMAGEN);
                });

                //$('#FOLIO').text(respuesta)
                //location.href = "../../Home/Home";
            },
            error: function () {
                console.log("No se ha podido obtener la información");
            }
        });
    });
});