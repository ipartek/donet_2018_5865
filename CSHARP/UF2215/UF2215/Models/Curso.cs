//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UF2215.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Curso()
        {
            this.Imparticiones = new HashSet<Imparticion>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IdProfesor { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Identificador { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public int NumeroHoras { get; set; }
        public string Temario { get; set; }
        public bool Activo { get; set; }
        public decimal Precio { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Profesor Profesor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imparticion> Imparticiones { get; set; }
    }
}
