namespace Capa.Entidades.ViewModel
{
    public class ProductoViewModel
    {
        public int Idproducto { get; set; }
        public string Nombre { get; set; }
        public decimal? Precio { get; set; }
        public int Provedor { get; set; }
        public int? Cantidad { get; set; }
        public virtual ProveedorViewModel ProvedorNavigation { get; set; }
    }
}
