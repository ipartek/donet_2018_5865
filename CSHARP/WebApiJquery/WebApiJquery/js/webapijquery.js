var URL = 'api/';

$(function () {

    $('body section').hide();

    $('form').hide();

    $('nav a').click(function (e) {
        e.preventDefault();

        var capa = this.id.substring(2);

        refrescarTabla(capa);

        $('body section').hide();
        $('#' + capa).show();
    });

    $('.insert').click(function (e) {
        e.preventDefault();

        var capa = idCapaPadre(this);
        var $capa = $('#' + capa);

        $capa.find('form')[0].reset();

        $capa.find('form').show();
    });

    $('form').submit(function (e) {
        e.preventDefault();

        var capa = idCapaPadre(this);

        var objeto = obtenerObjeto(capa, this);// { Nombre: $capa.find('.nombre').val(), Descripcion: $capa.find('.descripcion').val() };

        var id = this.id.value;

        if (id) {
            objeto.Id = +id;

            llamadaREST('PUT', URL + capa + '/' + id, objeto)
                .done(function () {
                    refrescarTabla(capa);
                });
        } else {
            llamadaREST('POST', URL + capa, objeto)
                .done(function () {
                    refrescarTabla(capa);
                });
        }

        $('form').hide();
    });
});

function obtenerCamposTabla(capa, objeto) {
    switch (capa) {
        case 'roles': return rolesObtenerCamposTabla(objeto);
        case 'usuarios': return usuariosObtenerCamposTabla(objeto);
        default: throw "No se reconoce ese tipo de capa";
    }
}

function rellenarFormulario(capa, objeto) {
    var form = $(`#${capa} form`)[0];

    switch (capa) {
        case 'roles': return rolesRellenarFormulario(form, objeto);
        case 'usuarios': return usuariosRellenarFormulario(form, objeto);
        default: throw "No se reconoce ese tipo de capa";
    }
}

function obtenerObjeto(capa, form) {
    switch (capa) {
        case 'roles': return rolesObtenerObjeto(form);
        case 'usuarios': return usuariosObtenerObjeto(form);
        default: throw "No se reconoce ese tipo de capa";
    }
    //return eval(capa + 'ObtenerObjeto(' + JSON.stringify(form) + ')');
}

function idCapaPadre(that) {
    return $(that).closest('section').attr('id');
}

function refrescarTabla(capa) {
    $.getJSON(URL + capa, function (objetos) {
        console.log(objetos);

        var $capa = $('#' + capa);
        
        $capa.find('tbody').empty();

        $(objetos).each(function () {
            var fila = `
                <tr>
                    <th>${this.Id}</th>
                    ${obtenerCamposTabla(capa, this)}
                    <td>
                        <a class="update" data-id="${this.Id}" href="#">Editar</a>
                        <a class="delete" data-id="${this.Id}" href="#">Borrar</a>
                    </td>
                </tr>`;
            $(fila).appendTo($capa.find('tbody'));
        });

        console.log($capa.find('.update'));

        $capa.find('.update').click(function (e) {
            e.preventDefault();

            llamadaREST('GET', URL + capa + '/' + this.dataset.id).done(function (objeto) {
                rellenarFormulario(capa, objeto);
                $(`#${capa} form`).show();
            });
        });

        console.log($capa.find('.delete'));

        $capa.find('.delete').click(function (e) {
            e.preventDefault();

            if (confirm(`¿Estás seguro de que quieres borrar el registro ${this.dataset.id}?`)) {
                llamadaREST('DELETE', URL + capa + '/' + this.dataset.id)
                    .done(function () {
                        refrescarTabla(capa);
                    });
            }
        });
    });
}

function llamadaREST(metodo, url, datos) {
    return $.ajax({
        method: metodo,
        url: url,
        data: JSON.stringify(datos),
        dataType: 'json',
        contentType: 'application/json'
    }).done(function (data, textStatus, jqXHR) {
        console.log(data, textStatus);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.log(textStatus, errorThrown);
        alert('Error: ' + textStatus + ", " + jqXHR.state());
    }).always(function (dataOjqXHR, textStatus, jqXHROerrorThrown) {
        console.log('SIEMPRE');
        //console.log(dataOjqXHR, textStatus, jqXHROerrorThrown);
    });
}
