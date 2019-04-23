var url = 'api/roles/';

$(function () {
    $.getJSON(url, function (roles) {
        console.log(roles);

        $(roles).each(function () {
            var fila = `<tr><th>${this.Id}</th><td>${this.Nombre}</td></tr>`;
            $(fila).appendTo('tbody');
        });
    });
});
