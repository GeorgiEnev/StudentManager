using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManager.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Subject Name is required")]
        public string Name { get; set; }

        // Foreign key
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }

        // Navigation property
        [ValidateNever]
        public Teacher Teacher { get; set; }
    }
}
