using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManager.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        // Navigation property — 1 teacher can teach many subjects
        public List<Subject> Subjects { get; set; }
    }
}
