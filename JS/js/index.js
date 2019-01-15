/*jslint devel: true, plusplus: true, continue: true*/
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

/*
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
*/
/*
function sentenciasDeControl() {
    'use strict';
    
    var mes, dias, x = 5, y = 6, seguir, n;

    if (x > y) {
        console.log(x);
        console.log('X es el mayor');
    } else if (x < y) {
        console.log(x);
        console.log('X es el menor');
    } else {
        console.log('Son iguales');
    }
    
    mes = 4;
    
    switch (mes) {
    case 2:
        dias = 28;
        break;
    case 4:
    case 6:
    case 9:
    case 11:
        dias = 30;
        break;
    default:
        dias = 31;
    }
    
    console.log(mes, dias);

    seguir = true;
    
    while (seguir) {
        console.log('Dentro de la repetición');
        
        seguir = confirm('¿Otra vez?');
    }
    
    do {
        console.log('Dentro de la repetición');
        
        seguir = confirm('¿Otra vez?');
    } while (seguir);
    
    for (n = 1; n <= 10; n++) {
        if (n === 5) {
            continue;
        }
        
        if (n % 7 === 0) {
            break;
        }
        
        console.log(n);
    }
}

sentenciasDeControl();
*/
/*
function matricesArreglosArraysVectores() {
    'use strict';
    
    var i, prop, arr = [ 5, 7, 9 ];
    console.log('arr[0]', arr[0]);
    
    for (i = 0; i < arr.length; i++) {
        console.log(i, arr[i]);
    }
    
    arr = new Array(2);
    arr[0] = 10;
    arr[1] = 20;
    
    arr[2] = 7;
    
    arr[7] = 'Yepa';
    
    arr[10] = 20;
    
    //arr['casa'] = 'home';
    arr.casa = 'home';
    
    for (i = 0; i < arr.length; i++) {
        console.log(i, arr[i]);
    }
    
    console.log('Listado completo de propiedades');
    
    for (prop in arr) {
        if (arr.hasOwnProperty(prop)) {
            console.log(prop, arr[prop]);
        }
    }
    
    //console.log(arr['casa']);
    console.log(arr);
    
    arr = [];
    
    arr.push(5);
    arr.push(6);
    
    console.log(arr);
}

matricesArreglosArraysVectores();
*/

function funciones() {
    'use strict';
    
    //function sumar(a, b) {
    //    return a + b;
    //}
    
    var sumar, total, calcular;
    
    sumar = function (a, b) {
        return a + b;
    };
    
    calcular = sumar;
    
    total = calcular(1, 2);
    
    console.log(total);
}

funciones();

function objetos() {
    'use strict';
    var persona;
    
    persona = {
        nombre: 'Javier',
        apellido: 'Lete',
        nombreCompleto: function () {
            return this.nombre + ', ' + this.apellido;
        }
    };
    
    //persona.nombre = 'Javier';
    //persona.apellido = 'Lete';
    
    //persona.nombreCompleto = function () {
    //    return this.nombre + ' ' + //this.apellido;
    //};
    
    console.log(persona);
    console.log(persona.nombre);
    console.log(persona.apellido);
    console.log(persona.nombreCompleto());
    
    function Persona(nombre, apellido) {
        this.nombre = nombre;
        this.apellido = apellido;
    }
    
    Persona.prototype.nombreCompleto = function () {
        return '[' + this.nombre + ',' + this.apellido + ']';
    };
    
    persona = new Persona('Pepe', 'Pérez');
    
    persona.tipo = 'Ejemplo de toda la vida';
    
    console.log(persona);
    console.log(persona.nombre);
    console.log(persona.apellido);
    console.log(persona.nombreCompleto());
    
    console.log(Persona);
    console.log(Persona.prototype);
}

objetos();