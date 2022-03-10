using System.ComponentModel.DataAnnotations;

namespace Capa.Entidades.ViewModel
{
    public class EmpleadoViewModel
    {
        public int Idempleado { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Sexo { get; set; }
    }
}
