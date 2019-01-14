/*jslint devel: true*/
/*eslint-env browser*/
/*eslint no-console: off*/

function saludar() {
    'use strict';

    var nombre, respuesta, num;
    
    nombre = prompt('Dime tu nombre');

    alert('Hola desde cabecera ' + nombre);

    respuesta = confirm('¿Estás seguro?');
    console.log(respuesta);

    respuesta = 5;
    console.log(respuesta);
    respuesta = 'Pepe';
    console.log(respuesta);
    respuesta = new Date();
    console.log(respuesta);
    
    respuesta = prompt('Dime un número');
    
    num = parseInt(respuesta, 10);
    
    if (isNaN(num)) {
        alert('Un número la próxima vez');
    } else {
        alert(num);
    }
}

saludar();
