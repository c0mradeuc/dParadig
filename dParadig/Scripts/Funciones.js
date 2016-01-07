function VerHome() {
    location.href = "/Home/Home";
}

function VerJefesArea() {
    alert("buscar");
    $.ajax({
        url: "/JefesArea/Index",
        type: 'GET',
        success: function (respuesta) {
            $("#contenido").empty().append(respuesta);
        }
    });
}

function VerHorarios() {
    $.ajax({
        url: "/Horarios/Index",
        type: 'Get',
        success: function (data) {
            $("#contenido").empty().append(data);
        },
        error: function () {
            alert("Hubo un error");
        }
    });
}

function VerReuniones() {
    $.ajax({
        url: "/Reuniones/Index",
        type: 'Get',
        success: function (data) {
            $("#contenido").empty().append(data);
        },
        error: function () {
            alert("Hubo un error");
        }
    });
}

function VerResultados() {
    $.ajax({
        url: "/Resultados/Index",
        type: 'Get',
        success: function (data) {
            $("#contenido").empty().append(data);
        },
        error: function () {
            alert("Hubo un error");
        }
    });
}

function ObtenerResultados() {
    $.ajax({
        url: "/Resultados/ObtenerResultado/",
        type: 'Get',
        data: { "semanaResultado": $("#selSemanas").val() },
        success: function (data) {
            $("#divResultados").empty().append(data);
        },
        error: function () {
            alert("Hubo un error");
        }
    });
}

function AbrirFormularioCrearJefe() {
    $.ajax({
        url: "/JefesArea/FormCrear",
        type: 'GET',
        success: function (data) {
            $("#contenido").empty().append(data);
        }
    });
}

function AbrirFormularioEditarJefe(idJefe) {
    $.ajax({
        url: "/JefesArea/FormEditar",
        type: 'GET',
        data: { "fIdJefe": idJefe },
        success: function (data) {
            $("#contenido").empty().append(data);
        }
    });
}

function CrearJefeArea() {
    var objeto = {
        "fNombre": $("#fNombre").val(),
        "fApellido": $("#fApellido").val()
    };

    $.ajax({
        url: "/JefesArea/Crear/",
        type: 'POST',
        data: objeto,
        async: true,
        cache: false,
        success: function (respuesta) {
            if (respuesta == "Correcto") {
                alert("Jefe de Área creado exitosamente!");
                VerJefesArea();
            }
            else {
                alert(respuesta);
            }
        },
        error: function (respuesta) {
            alert(objToString(respuesta));
        }
    });
}

function objToString(obj) {
    var str = '';
    for (var p in obj) {
        if (obj.hasOwnProperty(p)) {
            str += p + '::' + obj[p] + '\n';
        }
    }
    return str;
}

function ActualizarJefeArea() {
    $.ajax({
        url: "/JefesArea/Editar/",
        type: 'PUT',
        data: { "fIdJefe" : $("#fIdJefe").val(), "fNombre": $("#fNombre").val(), "fApellido": $("#fApellido").val() },
        success: function (respuesta) {
            if (respuesta == "Correcto") {
                alert("Jefe de Área editado exitosamente!");
                VerJefesArea();
            }
            else {
                alert(respuesta);
            }
        }
    });
}

function EliminarJefe(idJefe) {
    if (confirm("¿Esta seguro que desea eliminar este registro?")) {
        $.ajax({
            url: "/JefesArea/Eliminar/",
            type: 'DELETE',
            data: { "fIdJefe": idJefe },
            success: function (respuesta) {
                if (respuesta == "Correcto") {
                    alert("Jefe de Área eliminado correctamente!");
                    VerJefesArea();
                }
                else {
                    alert(respuesta);
                }
            }
        });
    }
}