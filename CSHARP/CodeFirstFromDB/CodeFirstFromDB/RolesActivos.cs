namespace CodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RolesActivos
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string Rol { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Borrado { get; set; }
    }
}
