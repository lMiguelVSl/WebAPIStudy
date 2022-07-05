using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIStudy.Model
{
    public class Autor : IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The {0} item is required")]
        [StringLength(maximumLength: 7, ErrorMessage = "El campo {0} no debe de tener mas de {1} caracteres")]
        public string Nombre { get; set; }
        [NotMapped]
        public int Menor { get; set; }
        [NotMapped]
        public int Mayor { get; set; }
        //[Range(18, 120)] //rango numerico
        //[NotMapped]
        //public int Edad { get; set; }

        //[NotMapped]
        //[CreditCard] //formato
        //public string TarjetaCredito { get; set; }

        //[Url] //formato
        //[NotMapped]
        //public string URL { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre)) //si no esta null o vacio 
            {
                var primeraLetra = Nombre[0].ToString(); //asignamos la primera letra del valor

                if (primeraLetra != primeraLetra.ToUpper()) //comparamos el valor guardado con el mismo valor en Upper 
                {
                    yield return new ValidationResult("The first letter may be in Upper case",
                        new string[] { nameof(Nombre) }); //si no esta en upper retornamos un valor de error 
                }
            }
            if (Menor > Mayor) //comparo los campos 
            {
                yield return new ValidationResult("This value cannot be over the bigger value",
                    new string[] {nameof(Menor)}); //retorno si es mayor el menor que el mayor 
            }
        }
    }
}
