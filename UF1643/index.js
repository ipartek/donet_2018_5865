var piloto;

var api = 'http://192.168.0.77:8000/api/'; //'https://swapi.co/api/';

var naves = [];

$(function () {
    guardarNaves(api + 'starships').then(function () {
        console.log(naves);
    }).then(function () {
        $(naves[4].films).each(function () {
            obtenerPelicula(this).then(function (pelicula) {
                console.log('Película', pelicula.title, pelicula.episode_id);
            });
        });
        $(naves[4].pilots).each(function () {
            //obtenerPiloto().then(obtenerPlaneta).then(obtenerEspecie).then(
            obtenerPiloto(this).then(function (pilot) {
                return $.when(obtenerPlaneta(pilot), obtenerEspecie(pilot)).fail(function () {
                    piloto = pilot.piloto;
                    console.error('Piloto sin especie o planeta', piloto);
                });
            }).then(
                function (pilot) {
                    piloto = pilot.piloto;
                    console.log('Piloto', piloto);
                    return pilot;
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
    if(!pilot.homeworld) {
        console.warn(`El piloto ${pilot.name} no tiene planeta`);
        return pilot;
    }
    
    var promesa = $.getJSON(pilot.homeworld).then(function (planeta) {
        pilot.piloto.planeta = planeta.name;
        return pilot;
    }).fail(function () {
        console.error(`El piloto ${pilot.name} no tiene planeta`);
    });

    return promesa;
}

function obtenerEspecie(pilot) {
    if(!pilot.species[0]){
        console.warn(`El piloto ${pilot.name} no tiene especie`);
        return pilot;
    }

    var promesa = $.getJSON(pilot.species[0]).then(function (especie) {
        pilot.piloto.especie = especie.name;
        return pilot;
    }).fail(function () {
        console.error(`El piloto ${pilot.name} no tiene especie`);
    });

    return promesa;
}