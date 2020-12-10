using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRepresentativeSchedule.models
{
    public class RepSchedule
    {
        public string Name{get; set;}
        public string Doctor_Name { get; set; }
        public string Meeting_Slot { get; set; }
        public DateTime Date_Of_Meeting { get; set; }
        public int Doctor_Contact_Number { get; set; }
        public string Treating_Ailment { get; set; }

    }
}
