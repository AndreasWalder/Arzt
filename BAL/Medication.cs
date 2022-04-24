using System;
using System.Collections.Generic;

#nullable disable

namespace Arzt.BAL
{
    public partial class Medication
    {
        public Medication()
        {
            VisitMedications = new HashSet<VisitMedication>();
        }


        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VisitMedication> VisitMedications { get; set; }
    }
}
