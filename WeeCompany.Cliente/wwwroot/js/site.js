$(document).ready(function () {

});
function ModalDeMensajes() {
    $.ajax({
        url: "Compania/MostrarModal",
        data: {
            NombreCompania: $("#NombreCompania").val(),
            NombrePersonaContacto: $("#NombreContacto").val(),
            CorreoElectronico: $("#CorreoEle").val(),
            Telefono: $("#Telefono").val(),
        }, type: "post"
    })
        .done(function (result) {
            if (result != null) {
               
                $("#ventanaModal").modal('show');
            }
        })
        .fail(function (xhr, status, error) {
           
            $("#ventanaModal").modal('show');

        })
        .always(function () {

        });
};
function DatosCorrecto() {
    $("#IdDivErrVacios").hide();
    $("#IdDivScc").show();
    $("#IdSuccCompa").text($("#NombreCompania").val());
    $("#IdSuccNom").text($("#NombreContacto").val());
    $("#IdSuccCorreo").text($("#CorreoEle").val());
    $("#IdSuccNum").text($("#Telefono").val());
}
function soloLetras(e) {
    var key = e.keyCode || e.which,
        tecla = String.fromCharCode(key).toLowerCase(),
        letras = " áéíóúabcdefghijklmnñopqrstuvwxyz",
        especiales = [8, 37, 39, 46],
        tecla_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}
function soloNumeros(e) {
    var key = e.keyCode || e.which,
        tecla = String.fromCharCode(key).toLowerCase(),
        letras = "123456789",
        especiales = [8, 37, 39, 46],
        tecla_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}
$("#SubmitBtn").prop("disabled", true);
function doalert(checkboxElem) {
    $("#IdDivScc").hide();
    if (checkboxElem.checked) {
        if (validarfor()) {
            $("#SubmitBtn").prop("disabled", false);
        }
        else {
            $("#SubmitBtn").prop("disabled", true);
            $("#Aceptar").prop("checked", false);
        }
    } else {
        $("#SubmitBtn").prop("disabled", true);
    }
}


$("#AltaCompania").submit(function (e) {
    e.preventDefault();
    $.ajax({
        url: "/Compania/Post",
        data: {
            NombreCompania: $("#NombreCompania").val(),
            NombrePersonaContacto: $("#NombreContacto").val(),
            CorreoElectronico: $("#CorreoEle").val(),
            Telefono: $("#Telefono").val(),
        }, type: "post"
    })
        .done(function (result) {
            if (result != null) {
                $("#ExitoAlert").show("slow").delay(2000).hide("slow");
                $("#ListaDeCompanias").html(result);
                $("#ListaDeCompanias .row").first().hide();
                $("#ListaDeCompanias .row").first().slideToggle("fast");
                DatosCorrecto();
                ModalDeMensajes();
                NombreCompania: $("#NombreCompania").val("");
                NombrePersonaContacto: $("#NombreContacto").val("");
                CorreoElectronico: $("#CorreoEle").val("");
                Telefono: $("#Telefono").val("");
                $("#NuevaCompania").hide();
                $("#AjaxLoader").hide("slow");
                
            }
            else {
                //ModalDeMensajes();
                $("#ErrorAlert").show("slow").delay(2000).hide("slow");
                $("#AjaxLoader").hide("slow");
                $("#SubmitBtn").prop("disabled", false);
                
            }
        })
        .fail(function (xhr, status, error) {
            //ModalDeMensajes();
             $("#ErrorAlert").show("slow").delay(2000).hide("slow");
             $("#AjaxLoader").hide("slow");
            $("#SubmitBtn").prop("disabled", false);

        })
});
function validaVacio(valor) {
    valor = valor.replace("&nbsp;", "");
    valor = valor == undefined ? "" : valor;
    if (!valor || 0 === valor.trim().length) {
        return true;
    }
    else {
        return false;
    }
}

function validarfor() {

    var NombreCompania= $("#NombreCompania").val();
    var NombrePersonaContacto= $("#NombreContacto").val();
    var CorreoElectronico= $("#CorreoEle").val();
    var Telefono= $("#Telefono").val();

    var expr = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    if (validaVacio(NombreCompania) || validaVacio(NombrePersonaContacto) || validaVacio(CorreoElectronico) || validaVacio(Telefono)) {
        ModalDeMensajes();
        return false;
    }
    if (!expr.test(CorreoElectronico)) {   
        $("#IdErrVacios").text("Error: La dirección de correo " + CorreoElectronico + " es incorrecta.");
        ModalDeMensajes();
        return false;
    }
    return true;
}