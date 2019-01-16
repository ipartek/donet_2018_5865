/*global $*/
/*jslint devel: true, plusplus: true, continue: true*/
/*eslint-env browser*/
/*eslint no-console: off*/

$(function () {
    'use strict';
    
    $('h1,h2').click(function () {
        $(this).text('Cambiado desde jQuery');
    });
    
    //$('input[type=checkbox]')
    $('#checkbox-password').change(function () {
        $('#password').prop('type', this.checked ? 'text' : 'password');
        
        /*
        if ($(this).prop('checked')) {
            $('#password').prop('type', 'text');
        } else {
            $('#password').prop('type', 'password');
        }
        */
    });
    
    $('form').submit(function (e) {
        var valido = true, $email;
        
        e.preventDefault();
        
        $email = $('#email');
        //email = $email[0];
        
        if ($email.val().indexOf('hotmail') !== -1) {
            valido = false;
            $email.focus().val('');
            
            //$('<span>').addClass('error').text('No aceptamos emails públicos').insertAfter('#email');
            
            if (!$email.hasClass('error')) {
                $email.after($('<span class="error">No aceptamos emails públicos</span>')).addClass('error');
            }
        }
        
        if (valido && confirm('¿Estás seguro de enviar los datos?')) {
            this.submit();
        }
    });
});