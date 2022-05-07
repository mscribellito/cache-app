using System.ComponentModel.DataAnnotations;

namespace CacheApp.Models
{

    public class BaseEntity
    {

        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }

    }

}