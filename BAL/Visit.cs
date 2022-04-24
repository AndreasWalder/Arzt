using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Arzt.BAL
{
    public partial class Visit
    {
        public Visit()
        {
            VisitMedications = new HashSet<VisitMedication>();
        }


        public int Id { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Patient is required and must not be empty.")]
        public int? selectedPatientId { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Medication is required and must not be empty.")]
        public int? selectedMedicationId { get; set; }

        public int PatientId { get; set; }

        [Required(ErrorMessage = "DateOfVisit is required and must not be empty.")]
        public DateTime? DateOfVisit { get; set; } = null;

        [Required(ErrorMessage = "Diagnostic Report is required and must not be empty.")]
        public string DiagnosticReport { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual ICollection<VisitMedication> VisitMedications { get; set; }
    }
}
