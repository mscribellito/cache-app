using System.ComponentModel.DataAnnotations;

namespace CacheApp.Models
{

    public class Caliber
    {

        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Caliber")]
        public string Name { get; set; }
        
    }

}