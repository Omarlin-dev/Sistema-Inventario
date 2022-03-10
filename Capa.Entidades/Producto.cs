using System;
using System.Collections.Generic;

#nullable disable

namespace Capa.Entidades
{
    public partial class Producto
    {
        public int Idproducto { get; set; }
        public string Nombre { get; set; }
        public decimal? Precio { get; set; }
        public int Provedor { get; set; }
        public int? Cantidad { get; set; }

        public virtual Provedor ProvedorNavigation { get; set; }
    }
}
