/*global $*/
/*jslint devel: true, plusplus: true, continue: true*/
/*eslint-env browser*/
/*eslint no-console: off*/

function extraerCamposUrl(url) {
    'use strict';

    var datos = [];

    $(url.split('?')[1].split('&')).each(function () {
        var datoValor = this.split('=');
        datos[datoValor[0]] = datoValor[1];
    });

    return datos;
}

function limpiarFormulario() {
    'use strict';

    //var form = document.forms[0];

    //$('#nombre').val('');
    //form.apellidos.value = '';

    //$('input:not([type=hidden])').val('');
    $('input').val('');
    $('select').val('0');

    //form.reset();
}

function filaTablaAFormulario(id) {
    'use strict';

    //btn.parentNode.parentNode.columns[0].innerText   //$btn.parents('tr').find('td')[0]
    var datos, form;

    datos = $('#id' + id)[0].dataset;
    form = $('#formulario')[0];
    //$('#nombre').val($tr.data('nombre'));
    //TODO: Verificar que el id se recoge correctamente en otros navegadores
    form.id.value = id;
    form.nombre.value = datos.nombre;
    form.apellidos.value = datos.apellidos;
    form.email.value = datos.email;
    form.dni.value = datos.dni;
    form['fecha-de-nacimiento'].value = datos.fechaDeNacimiento;
    form.nacionalidad.value = datos.nacionalidad;


    //$tr.data('nombre');
    //$('#id' + id).data('apellidos');
}

function borrarFilaTabla(id) {
    'use strict';
    $('#id' + id).remove();
}

function modificarBoton(texto, tipo) {
    'use strict';

    $('#btn-enviar')[0].className = 'btn btn-' + tipo;
    $('#btn-enviar').text(texto);
}

function anadir() {
    'use strict';

    limpiarFormulario();

    modificarBoton('Añadir', 'primary');
}

function editar(id) {
    'use strict';

    filaTablaAFormulario(id);

    modificarBoton('Editar', 'primary');
}

function borrar(id) {
    'use strict';

    filaTablaAFormulario(id);

    modificarBoton('Borrar', 'danger');
}

$(function () {
    'use strict';

    $('#detalle').hide();

    $('a[href*=opcion]').click(function (e) {
        e.preventDefault();

        var href = extraerCamposUrl(this.href);

        console.log(href.opcion, href.id);

        $('#btn-enviar').val(href.opcion);

        switch (href.opcion) {
        case 'anadir':
            anadir();
            break;
        case 'editar':
            editar(href.id);
            break;
        case 'borrar':
            borrar(href.id);
            break;
        }

        $('#detalle').show();
    });

    $('#formulario').submit(function (e) {
        e.preventDefault();
        
        var opcion, id;
        
        opcion = $('#btn-enviar').val();
        id = document.forms[0].id.value;
        
        switch (opcion) {
        case 'anadir':
            crearUnaFila(id);
            formularioAFilaTabla(id);
            
            break;
        case 'editar':
            formularioAFilaTabla(id);
                
            break;
        case 'borrar':
            borrarFilaTabla(id);
                
            break;
        default:
            console.error('opcion', opcion);
        }
        
        $('#detalle').hide();
    });
});
