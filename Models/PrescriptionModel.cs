using System;
using System.ComponentModel.DataAnnotations;

namespace PrescriptionApp.Models
{
    public class PrescriptionModel
    {
        [Key]
        public int PrescriptionId { get; set; }

        [Required(ErrorMessage = "Please enter a medication name.")]
        public string MedicationName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a fill status.")]
        public string FillStatus { get; set; } = "New";

        [Required(ErrorMessage = "Please enter a cost.")]
        [Range(0.01, 10000, ErrorMessage = "Cost must be greater than 0.")]
        public double Cost { get; set; }

        [Required]
        public DateTime RequestTime { get; set; }
              public string Slug { get; set; } = string.Empty;   // will be saved in DB

// optional helper – call it in controller so you never forget
        public void GenerateSlug() =>
            Slug = string.IsNullOrWhiteSpace(MedicationName)
                ? string.Empty
                : MedicationName.ToLower().Replace(" ", "-");
        }

}
