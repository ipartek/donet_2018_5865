function usuariosObtenerObjeto(form) {
    var idrol = parseInt(form.rol.value);

    return {
        Email: form.email.value,
        Password: form.password.value,
        IdRol: idrol === 0 ? null : idrol
    };
}

function usuariosObtenerCamposTabla(usuario) {
    return `<td>${usuario.Email}</td><td>${usuario.Rol ? usuario.Rol : 'SIN ROL'}</td>`;
}

function usuariosRellenarFormulario(form, usuario) {
    form.id.value = usuario.Id;
    form.email.value = usuario.Email;
    form.password.value = ''; //usuario.Password;
    form.rol.value = usuario.RolDescripcion ? usuario.RolDescripcion : 'SIN ROL';

    llamadaREST('GET', URL + 'roles').done(function (roles) {
        console.log('usuariosRellenarFormulario', roles);

        form.rol.innerHTML = '';

        form.rol.add(new Option('SIN ROL', 0, false, false));

        $(roles).each(function () {
            form.rol.add(new Option(this.Descripcion, this.Id, false, usuario.RolId === this.Id));
        });
    });
}