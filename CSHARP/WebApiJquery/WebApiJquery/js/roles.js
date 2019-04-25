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