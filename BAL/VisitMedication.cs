using System;
using System.Collections.Generic;

#nullable disable

namespace Arzt.BAL
{
    public partial class VisitMedication
    {
        public int Id { get; set; }
        public int VisitId { get; set; }
        public int MedicationId { get; set; }

        public virtual Medication Medication { get; set; }
        public virtual Visit Visit { get; set; }
    }
}
