//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiSwagger.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetallePedido
    {
        public int IdPedido { get; set; }
        public int IdArticulos { get; set; }
        public Nullable<int> Cantidad { get; set; }
    
        public virtual Articulo Articulo { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
