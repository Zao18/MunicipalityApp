using System;
using System.ComponentModel.DataAnnotations;

namespace MunicipalityApp.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string? Description { get; set; }
        public string? ImagePath { get; set; }
    }
}


