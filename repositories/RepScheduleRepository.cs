using MedicalRepresentativeSchedule.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRepresentativeSchedule.repositories 
{

    public class RepScheduleRepository : IRepScheduleRepository
    {
        private static List<Doctor> doctors;
        private static List<RepresentativeDetails> representatives;
        public RepScheduleRepository()
        {
            doctors = new List<Doctor>()
             {
               new Doctor { Name = "d1",Contact_Number=0987654321 , Treating_Ailment="Orthopaedics"},
               new Doctor { Name = "d2",Contact_Number=0987654321 , Treating_Ailment="General"},
               new Doctor { Name = "d3",Contact_Number=0987654321 , Treating_Ailment="Gynecology"},
               new Doctor { Name = "d4",Contact_Number=0987654321 , Treating_Ailment="Orthopaedics"},
               new Doctor { Name = "d5",Contact_Number=0987654321 , Treating_Ailment="General"},
               new Doctor { Name = "d6",Contact_Number=0987654321 , Treating_Ailment="Gynecology"},
               new Doctor { Name = "d7",Contact_Number=0987654321 , Treating_Ailment="Orthopedics"},
               new Doctor { Name = "d8",Contact_Number=0987654321 , Treating_Ailment="General"},
               new Doctor { Name = "d9",Contact_Number=0987654321 , Treating_Ailment="Gynecology"},
               new Doctor { Name = "d10",Contact_Number=0987654321 , Treating_Ailment="General"},

             };

            representatives = new List<RepresentativeDetails>()
            {
                new RepresentativeDetails{Representative_Name=new List<string>() { "r1", "r2", "r3" }},
            };


        }


        public List<RepSchedule> GetSchedule(List<MedicineStock> medicines)
        {

           
            List<RepSchedule> finalschedule;
           
            
        }
    }
        
    
}
