using System;
using System.ComponentModel.DataAnnotations;

namespace MunicipalityApp.Models
{
    public class Issue
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        public string? Description { get; set; }

        public string? FilePath { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Submitted";

        [StringLength(500)]
        public string? Response { get; set; }

        [StringLength(20)]
        public string ReferenceNumber { get; set; } = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
    }
}





