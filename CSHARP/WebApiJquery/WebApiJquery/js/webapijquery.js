var url = 'api/roles/';

$(function () {

    $('form').hide();

    refrescarTabla();

    $('.insert').click(function (e) {
        e.preventDefault();

        $('form')[0].reset();

        $('form').show();
    });

    $('form').submit(function (e) {
        e.preventDefault();

        var rol = { Nombre: $('#nombre').val(), Descripcion: $('#descripcion').val() };

        var id = $('#id').val();

        if (id) {
            rol.Id = +id;

            llamadaREST('PUT', url + id, rol);
        } else {
            llamadaREST('POST', url, rol);
        }

        $('form').hide();
    });
});

function refrescarTabla() {
    $.getJSON(url, function (roles) {
        console.log(roles);

        $('tbody').empty();

        $(roles).each(function () {
            var fila = `
                <tr>
                    <th>${this.Id}</th>
                    <td>${this.Nombre}</td>
                    <td>
                        <a class="update" data-id="${this.Id}" href="#">Editar</a>
                        <a class="delete" data-id="${this.Id}" href="#">Borrar</a>
                    </td>
                </tr>`;
            $(fila).appendTo('tbody');
        });

        console.log($('.update'));

        $('.update').click(function (e) {
            e.preventDefault();

            llamadaREST('GET', url + this.dataset.id).done(function (rol) {
                $('#id').val(rol.Id);
                $('#nombre').val(rol.Nombre);
                $('#descripcion').val(rol.Descripcion);

                $('form').show();
            });
        });

        console.log($('.delete'));

        $('.delete').click(function (e) {
            e.preventDefault();

            if (confirm(`¿Estás seguro de que quieres borrar el registro ${this.dataset.id}?`)) {
                llamadaREST('DELETE', url + this.dataset.id);
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
        refrescarTabla();
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.log(textStatus, errorThrown);
        alert('Error: ' + textStatus + ", " + jqXHR.state());
    }).always(function (dataOjqXHR, textStatus, jqXHROerrorThrown) {
        console.log('SIEMPRE');
        //console.log(dataOjqXHR, textStatus, jqXHROerrorThrown);
    });
}
