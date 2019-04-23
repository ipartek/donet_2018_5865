var url = 'api/roles/';

$(function () {

    $('form').hide();

    refrescarTabla();

    $('.insert').click(function (e) {
        e.preventDefault();

        $('form').show();
    });

    $('form').submit(function (e) {
        e.preventDefault();

        var rol = { Nombre: $('#nombre').val(), Descripcion: $('#descripcion').val() };

        $.post(url, rol).done(function (res) {
            console.log(res);

            refrescarTabla();
        });
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
    });
}