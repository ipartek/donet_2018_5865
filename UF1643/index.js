var naves = [];

$(function () {
    guardarNaves('https://swapi.co/api/starships/').then(function () {
        console.log(naves);
    });
});

function guardarNaves(url) {
    var promesa = $.getJSON(url).then(function(datos) {
        if (datos.results) {
            naves.push(...datos.results);

            if (datos.next) {
                return guardarNaves(datos.next);
            }
        }
    });

    return promesa;
}
