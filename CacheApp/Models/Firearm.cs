using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CacheApp.Models
{

    public class Firearm
    {

        public Guid Id { get; set; }

        public Guid CaliberId { get; set; }

        [Required]
        [Display(Name = "Manufacturer/Importer")]
        public string ManufacturerImporter { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Serial Number")]
        public string? SerialNumber { get; set; }

        [Required]
        [Display(Name = "Type")]
        public Type Type { get; set; }

        [Display(Name = "Caliber")]
        public Caliber? Caliber { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [DataType(DataType.Currency)]
        [Display(Name = "Cost")]
        public decimal? Cost { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Acquired")]
        public DateTime? DateAcquired { get; set; }

        [Display(Name = "Purchase Location")]
        public string? PurchaseLocation { get; set; }

        [Display(Name = "Status")]
        public Status? Status { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Sold")]
        public DateTime? DateSold { get; set; }

        [Display(Name = "Sold/Transferred To")]
        public string? SoldTransferredTo { get; set; }

        [Display(Name = "Notes")]
        public string? Notes { get; set; }

    }

}