var piloto;

var api = 'https://swapi.co/api/';

var naves = [];

$(function () {
    guardarNaves(api + 'starships').then(function () {
        console.log(naves);
    }).then(function() {
        $(naves[3].films).each(function() {
            obtenerPelicula(this).then(function(pelicula) {
                console.log('Película', pelicula.title, pelicula.episode_id);
            });
        });
        $(naves[3].pilots).each(function () {
            //obtenerPiloto().then(obtenerPlaneta).then(obtenerEspecie).then(
            obtenerPiloto(this).then(function (pilot) {
                return $.when(obtenerPlaneta(pilot), obtenerEspecie(pilot));
            }).then(
                function (pilot) {
                    piloto = pilot.piloto;
                    console.log('Piloto', piloto);
                });
        });
    
    });


});


function obtenerPelicula(url) {
    var promesa = $.getJSON(url);
    
    return promesa;
}
function guardarNaves(url) {
    var promesa = $.getJSON(url).then(function (datos) {
        if (datos.results) {
            naves.push(...datos.results);

            if (datos.next) {
                return guardarNaves(datos.next);
            }
        }
    });

    return promesa;
}

function obtenerPiloto(pilotoUrl) {
    var promesa = $.getJSON(pilotoUrl).then(function (pilot) {
        pilot.piloto = {};
        pilot.piloto.nombre = pilot.name;
        return pilot;
    });

    return promesa;
}

function obtenerPlaneta(pilot) {
    var promesa = $.getJSON(pilot.homeworld).then(function (planeta) {
        pilot.piloto.planeta = planeta.name;
        return pilot;
    });

    return promesa;
}

function obtenerEspecie(pilot) {
    var promesa = $.getJSON(pilot.species[0]).then(function (especie) {
        pilot.piloto.especie = especie.name;
        return pilot;
    });

    return promesa;
}