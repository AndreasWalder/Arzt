using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Arzt.BAL
{
    public partial class Patient
    {
        public Patient()
        {
            Visits = new HashSet<Visit>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Firstname is required and must not be empty.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Surename is required and must not be empty.")]
        public string Surename { get; set; }

        [Required(ErrorMessage = "DateTime is required and must not be empty.")]
        public DateTime? Birthday { get; set; } = null;

        [Required(ErrorMessage = "Gender is required and must not be empty.")]
        public bool Gender { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Gender is required and must not be empty.")]
        public string selectedGender { get; set; }

        [Required(ErrorMessage = "Address is required and must not be empty.")]
        public string Address { get; set; }

        [Range(1000, 99999, ErrorMessage = "Zip invalid range (1000-99999).")]
        public int Zip { get; set; }

        [Required(ErrorMessage = "City is required and must not be empty.")]
        public string City { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }
    }
}
