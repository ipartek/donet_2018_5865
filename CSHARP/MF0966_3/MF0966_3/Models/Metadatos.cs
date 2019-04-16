using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MF0966_3.Models
{
    public class CursoMetadata
    {
        [Display(Name = "Fecha de Inicio")]
        public DateTime? FechaInicio;
        [Display(Name = "Fecha de Fin")]
        public DateTime? FechaFin;
        [Display(Name = "Número de Horas")]
        public int NumeroHoras;
    }

    [MetadataType(typeof(CursoMetadata))]
    public partial class Curso
    {

    }

    public class AlumnoMetadata
    {
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaNacimiento;
        [Display(Name = "Dirección")]
        public string Direccion;
        [Display(Name = "Población")]
        public string Poblacion;
        [Display(Name = "Teléfono")]
        public string Telefono;
        [Display(Name = "Número de Hermanos")]
        public int NumeroHermanos;
    }

    [MetadataType(typeof(AlumnoMetadata))]
    public partial class Alumno
    {

    }

    public class ProfesorMetadata
    {
        [Display(Name = "NSS")]
        public string NumeroSeguridadSocial;
        [Display(Name = "Fecha de Nacimiento")]
        public Nullable<System.DateTime> FechaNacimiento;
        [Display(Name = "DNI")]
        public string Dni;
        [Display(Name = "Dirección")]
        public string Direccion;
        [Display(Name = "Población")]
        public string Poblacion;
        [Display(Name = "CP")]
        public string CodigoPostal;
        [Display(Name = "Teléfono")]
        public string Telefono;
    }

    [MetadataType(typeof(ProfesorMetadata))]
    public partial class Profesor
    {

    }

    public class ClienteMetadata
    {
        [Display(Name = "Teléfono")]
        public string Telefono;
        [Display(Name = "Dirección")]
        public string Direccion;
        [Display(Name = "Población")]
        public string Poblacion;
        [Display(Name = "CP")]
        public string CodigoPostal;
    }

    [MetadataType(typeof(ClienteMetadata))]
    public partial class Cliente
    {

    }

    public class ImparticionMetadata
    {
        [Display(Name = "Curso")]
        public int IdCurso;
        [Display(Name = "Alumno")]
        public int IdAlumno;
        [Display(Name = "Fecha de Matriculación")]
        public DateTime FechaMatriculacion;
    }

    [MetadataType(typeof(ImparticionMetadata))]
    public partial class Imparticion
    {

    }
}