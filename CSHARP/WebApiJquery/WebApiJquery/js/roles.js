function rolesObtenerObjeto(form) {
    return {
        Nombre: form.nombre.value,
        Descripcion: form.descripcion.value
    };
}

function rolesObtenerCamposTabla(rol) {
    return `<td>${rol.Nombre}</td><td>${rol.Descripcion}</td>`;
}
