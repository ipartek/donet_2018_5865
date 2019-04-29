function rolesObtenerObjeto(form) {
    return {
        Nombre: form.nombre.value,
        Descripcion: form.descripcion.value
    };
}

function rolesObtenerCamposTabla(rol) {
    return `<td>${rol.Nombre}</td><td>${rol.Descripcion}</td>`;
}

function rolesRellenarFormulario(form, rol) {
    form.id.value = rol.Id;
    form.nombre.value = rol.Nombre;
    form.descripcion.value = rol.Descripcion;
}

function rellenarRolesFormularioUsuario(rolid) {
    llamadaREST('GET', URL + 'roles').done(function (roles) {
        console.log('usuariosRellenarFormulario', roles);

        var form = $('#usuarios form')[0];

        form.rol.innerHTML = '';

        form.rol.add(new Option('SIN ROL', 0, false, false));

        $(roles).each(function () {
            form.rol.add(new Option(this.Descripcion, this.Id, false, rolid === this.Id));
        });
    });
}