var url = 'api/roles/';

$(function () {
    $.getJSON(url, function (roles) {
        console.log(roles);

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
});
