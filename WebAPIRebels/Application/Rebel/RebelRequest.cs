using System.ComponentModel.DataAnnotations;

namespace WebAPIRebels.Application.Rebel
{
    public class RebelRequest
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} no debe tener más de {1} carácteres")]
        public string RebelName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo {0} no debe tener más de {1} carácteres")]
        public string PlanetName { get; set; }
    }
}
