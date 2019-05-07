var naves = [];

$(function () {
    guardarDatos('https://swapi.co/api/starships/').then(function () {
        console.log(naves);
    });
});

function guardarDatos(url) {
    var promesa = $.getJSON(url).then(function(datos) {
        if (datos.results) {
            naves.push(...datos.results);

            if (datos.next) {
                return guardarDatos(datos.next);
            }
        }
    });

    return promesa;
}
