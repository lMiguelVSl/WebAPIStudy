using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIStudy.Model
{
    public class Autor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The {0} item is required")]
        [StringLength(maximumLength: 4, ErrorMessage = "El campo {0} no debe de tener mas de {1} caracteres")]
        
        public string Nombre { get; set; }

        [Range(18, 120)] //rango numerico
        [NotMapped]
        public int Edad { get; set; }

        [NotMapped]
        [CreditCard] //formato
        public string TarjetaCredito { get; set; }

        [Url] //formato
        [NotMapped]
        public string URL { get; set; }
    }
}
