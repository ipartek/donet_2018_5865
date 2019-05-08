var piloto;

var api = 'https://swapi.co/api/';

var naves = [];

$(function () {
    guardarNaves(api + 'starships').then(function () {
        console.log(naves);
    });

    obtenerPiloto().then(obtenerPlaneta).then(obtenerEspecie).then(
        function(pilot){
            piloto = pilot.piloto;
            console.log(piloto);
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

function obtenerPiloto()
{
    var promesa = $.getJSON(api + 'people/14').then(function (pilot) {
        pilot.piloto = {};
        pilot.piloto.nombre = pilot.name;
        return pilot;
    });

    return promesa;
}

function obtenerPlaneta(pilot)
{
    var promesa = $.getJSON(pilot.homeworld).then(function(planeta) {
        pilot.piloto.planeta = planeta.name;
        return pilot;
    });

    return promesa;
}

function obtenerEspecie(pilot)
{
    var promesa = $.getJSON(pilot.species[0]).then(function(especie) {
        pilot.piloto.especie = especie.name;
        return pilot;
    });
    
    return promesa;
}