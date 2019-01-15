/*jslint devel: true*/
/*eslint-env browser*/
/*eslint no-console: off*/

/*
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
*/

function operadores() {
    'use strict';
    // +, -, *, /
    console.log(5 % 2); //Resto de la división entera de 5 / 2
    
    // console.log(5 ** 2);
    // 5 elevado a 2
    // ECMAScript 2016 (7)

    // >, <, >=, <=
    var x, y;
    x = 5;
    y = 7;

    console.log(x, y);

    if (x === y) {
        console.log('X es igual que Y');
    } else {
        console.log('No son iguales');
    }
    
    // ==, ===, !=, !==
    // === ESTRICTAMENTE IGUAL (incluyendo tipos)
    // !== ESTRICTAMENTE DESIGUAL (incluyendo tipos)
    
    // && (AND), || (OR), ! (NOT)
    
    // &, |, ^, ~ a nivel de bits
    
    // +=, -=, *=, /= ...
    x = x + 2;
    x += 2;
    
    // ++, --
    console.log(x);
    //console.log(x++); //POSTincremento
    console.log(x);
    
    console.log(y);
    //console.log(++y); //PREincremento
    console.log(y);
    
    console.log(x > y ? x : y);
    
    
}

operadores();
