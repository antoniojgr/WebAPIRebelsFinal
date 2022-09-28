using System.ComponentModel.DataAnnotations;

namespace WebAPIRebels.Domain.Entities
{
    public class RebelEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string RebelName { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string PlanetName { get; set; }

        public DateTime Created { get; set; }
    }
}
