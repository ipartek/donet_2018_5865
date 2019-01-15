/*jslint devel: true, plusplus: true, continue: true*/
/*eslint-env browser*/
/*eslint no-console: off*/

window.onload = function () {
    'use strict';
    
    var h1, form, password, checkboxPassword, errorEmail;
    
    h1 = document.getElementsByTagName('h1')[0];

    h1.onclick = function () {
        console.log(h1);
        h1.innerHTML = 'Cambiado desde JS';
    };
    
    password = document.getElementById('password');
    checkboxPassword = document.getElementById('checkbox-password');
    
    checkboxPassword.onchange = function () {
        //password.type = checkboxPassword.checked ? 'text' : 'password';
        
        if (checkboxPassword.checked) {
            password.type = 'text';
        } else {
            password.type = 'password';
        }
    };
    
    form = document.forms[0];
    
    form.onsubmit = function (e) {
        e.preventDefault();
        
        //alert('Envío de formulario');
        
        var valido, email;
        
        valido = true;
        
        email = document.getElementById('email');
        
        if (email.value.indexOf('hotmail') !== -1) {
            errorEmail = document.createElement('span');
            errorEmail.innerHTML = 'No aceptamos emails públicos';
            errorEmail.style = 'color: red; font-weight: bold';
            
            console.trace(errorEmail);
            
            email.parentNode.appendChild(errorEmail);
            
            //alert('No aceptamos emails públicos');
            email.style = 'border: 1px solid red';
            email.value = '';
            email.focus();
            valido = false;
        }
        
        if (valido && confirm('¿Estás seguro de enviar los datos?')) {
            this.submit();
        }
    };
    
    //document.write('<h2>Yepa</h2>');
};

