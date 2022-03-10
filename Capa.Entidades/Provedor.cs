using System;
using System.Collections.Generic;

#nullable disable

namespace Capa.Entidades
{
    public partial class Provedor
    {
        public Provedor()
        {
            Productos = new HashSet<Producto>();
        }

        public int Idprovedor { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
