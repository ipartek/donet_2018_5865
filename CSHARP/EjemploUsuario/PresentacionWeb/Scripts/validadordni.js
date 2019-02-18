function validarDni(validador, args) {
    'use strict';
    var numero, letra, letras, dni;

    dni = args.Value;

    if (!/^[\dXYZ]\d{7}[A-Z]$/.test(dni)) {
        args.IsValid = false;
        validador.errormessage = "El DNI debe ser del formato A1234567A o 12345678A";
        return;
    }

    letras = 'TRWAGMYFPDXBNJZSQVHLCKE';

    numero = dni.substring(0, dni.length - 1);

    letra = dni[8];

    numero = numero.replace('X', '0').replace('Y', '1').replace('Z', '2');

    args.IsValid = letra === letras[numero % 23];

    if (!args.IsValid) {
        validador.errormessage = "El cálculo de la letra de DNI no concuerda";
    }
}
