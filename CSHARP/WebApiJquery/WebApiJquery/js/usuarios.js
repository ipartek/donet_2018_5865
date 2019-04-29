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

    rellenarRolesFormularioUsuario(usuario.RolId);
}