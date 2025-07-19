using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StudentManager.Models
{
    public class Exam
    {
        public int Id { get; set; }

        [Display(Name = "Exam Date")]
        [DataType(DataType.DateTime)]
        public DateTime ExamDate { get; set; }

        public string Location { get; set; }

        // Foreign key
        public int SubjectId { get; set; }

        // Prevent MVC from validating/binding this navigation prop
        [ValidateNever]
        public Subject Subject { get; set; }
    }
}
