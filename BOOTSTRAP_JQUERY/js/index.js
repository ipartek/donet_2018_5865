/*global $*/
/*jslint devel: true, plusplus: true, continue: true*/
/*eslint-env browser*/
/*eslint no-console: off*/

function esValidoZip(zip) {
    'use strict';
    
    return zip % 2 === 0;
}

$(function () {
    'use strict';
    
    var
        $form = $('form'),
        $zip = $('#zip'),
        $zipError = $('#zip-error');
    
    $zipError.data('error-original', $('#zip-error').text());
    
    $form.submit(function (e) {
        var errorCustom, clave, tipoError, mensajeError;
        
        if (!esValidoZip($zip.val())) {
            errorCustom = 'El ZIP no es válido (no es divisible entre 2)';
        } else {
            errorCustom = '';
        }
        
        $zip[0].setCustomValidity(errorCustom);
        
        if (!$form[0].checkValidity()) {
            
            e.preventDefault();
            e.stopPropagation();

            for (clave in $zip[0].validity) {
                if ($zip[0].validity[clave]) {
                    tipoError = clave;
                    break;
                }
            }
            
            switch (tipoError) {
            case 'patternMismatch':
                mensajeError = 'Tiene que tener exactamente cinco dígitos';
                break;
            case 'customError':
                mensajeError = errorCustom;
                break;
            default:
                mensajeError = $zipError.data('error-original');
            }
            
            $zipError.text(mensajeError);
        }
        
        $form.addClass('was-validated');
    });
});
