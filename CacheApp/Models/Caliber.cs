using System.ComponentModel.DataAnnotations;

namespace CacheApp.Models
{

    public class Caliber : BaseEntity, IOwnable
    {

        public Guid Id { get; set; }

        public string? UserId { get; set; }

        [Required]
        [Display(Name = "Caliber")]
        public string Name { get; set; }

    }

}