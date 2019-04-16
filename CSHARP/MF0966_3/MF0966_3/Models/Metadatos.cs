using System;
using System.ComponentModel.DataAnnotations;

namespace MF0966_3.Models
{
    public class CursoMetadata
    {
        [Display(Name = "Fecha de Inicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaInicio;
        [Display(Name = "Fecha de Fin")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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
        [Required]
        public string Nombre;
        [Required]
        public string Apellidos;
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaNacimiento;
        [Display(Name = "Dirección")]
        public string Direccion;
        [Display(Name = "Población")]
        public string Poblacion;
        [Display(Name = "CP")]
        [RegularExpression("\\d{5}", ErrorMessage = "Sólo se admiten números de cinco dígitos para el código postal")]
        public string CodigoPostal;
        [Display(Name = "Teléfono")]
        [Required]
        [RegularExpression("\\d{9}", ErrorMessage = "Sólo se admiten números de teléfono de 9 dígitos")]
        public string Telefono;
        [Display(Name = "Número de Hermanos")]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Sólo se admite un número positivo de hermanos")]
        public int NumeroHermanos;
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email;
        [Display(Name = "DNI")]
        [Required]
        [RegularExpression("[XYZ\\d]\\d{7}[A-Z]", ErrorMessage = "Formato de DNI incorrecto")]
        public string Dni;
        [Required]
        public bool Activo;
    }

    [MetadataType(typeof(AlumnoMetadata))]
    public partial class Alumno
    {

    }

    public class ProfesorMetadata
    {
        [Display(Name = "NSS")]
        public string NumeroSeguridadSocial;
        [Required]
        public string Nombre;
        [Required]
        public string Apellidos;
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FechaNacimiento;
        [Display(Name = "DNI")]
        [Required]
        [RegularExpression("[XYZ\\d]\\d{7}[A-Z]", ErrorMessage = "Formato de DNI incorrecto")]
        public string Dni;
        [Display(Name = "Dirección")]
        public string Direccion;
        [Display(Name = "Población")]
        public string Poblacion;
        [Display(Name = "CP")]
        [RegularExpression("\\d{5}", ErrorMessage = "Sólo se admiten números de cinco dígitos para el código postal")]
        public string CodigoPostal;
        [Display(Name = "Teléfono")]
        [Required]
        [RegularExpression("\\d{9}", ErrorMessage = "Sólo se admiten números de teléfono de 9 dígitos")]
        public string Telefono;
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email;
        [Required]
        public bool Activo;

    }

    [MetadataType(typeof(ProfesorMetadata))]
    public partial class Profesor
    {

    }

    public class ClienteMetadata
    {
        [Display(Name = "Teléfono")]
        [Required]
        [RegularExpression("\\d{9}", ErrorMessage = "Sólo se admiten números de teléfono de 9 dígitos")]
        public string Telefono;
        [Display(Name = "Dirección")]
        public string Direccion;
        [Display(Name = "Población")]
        public string Poblacion;
        [Display(Name = "CP")]
        [RegularExpression("\\d{5}", ErrorMessage = "Sólo se admiten números de cinco dígitos para el código postal")]
        public string CodigoPostal;
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email;
        [Required]
        public string Identificador;

    }

    [MetadataType(typeof(ClienteMetadata))]
    public partial class Cliente
    {

    }

    public class ImparticionMetadata
    {
        //No cambia el aspecto
        //[Display(Name = "Curso")]
        //public int IdCurso { get; set; }
        //[Display(Name = "Alumno")]
        //public int IdAlumno { get; set; }
        [Display(Name = "Fecha de Matriculación")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaMatriculacion;
    }

    [MetadataType(typeof(ImparticionMetadata))]
    public partial class Imparticion
    {

    }
}