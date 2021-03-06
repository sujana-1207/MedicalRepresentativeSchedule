﻿using MedicalRepresentativeSchedule.models;
using MedicalRepresentativeSchedule.repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MedicalRepresentativeSchedule.Providers
{
    public class RepScheduleProvider : IRepScheduleProvider
    {
        List<MedicineStock> stockData=new List<MedicineStock>();
        List<DateTime> Dates = new List<DateTime>();
        List<Doctor> docNames = new List<Doctor>();
        List<RepresentativeDetails> repNames = new List<RepresentativeDetails>();
        List<MedicineStock> stock = new List<MedicineStock>();
        List<RepSchedule> repSchedule = new List<RepSchedule>() { };
        private readonly IRepScheduleRepository _repschedulerepository;
        public RepScheduleProvider(IRepScheduleRepository repschedulerepository)
        {
            _repschedulerepository = repschedulerepository;
        }

        public List<Doctor> GetDocters()
        {
            return _repschedulerepository.GetDoctorDetails();
        }
        public List<RepresentativeDetails> GetRepresentatives()
        {
            return _repschedulerepository.GetRepresentativesDetails();
        }

       
            
            //var i = medicines.Where(x => x.Target_Ailment == Treating_ailment).FirstOrDefault();
           

        public async Task<List<MedicineStock>> GetMedicineStock()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:44394/api/MedicineStock"))
                {

                    string stringData = response.Content.ReadAsStringAsync().Result;
                    stockData = JsonConvert.DeserializeObject<List<MedicineStock>>(stringData);

                }
                return stockData;
            } 
        }

        public async Task<List<RepSchedule>> GetRepScheduleAsync(DateTime startDate)
        {
            Dates.Clear();
            DateTime start = startDate;

            DateTime end = start.AddDays(6);
            int workDays = 0;
            while (start != end)
            {
                if (start.DayOfWeek != DayOfWeek.Sunday)
                {
                    Dates.Add(start);
                    workDays++;
                }

                start = start.AddDays(1);

                if (workDays == 6)
                {
           
                    break;
                }
            }
            repNames = GetRepresentatives();
            stock = await GetMedicineStock();
            docNames = GetDocters();
            for(int i=0;i<Dates.Count;i++)
            {
                RepSchedule rep = new RepSchedule();
                rep.Rep_Name =repNames[(i % repNames.Count)].Representative_Name;
                rep.Doctor_Name = docNames[i].Name;
                rep.Treating_Ailment = docNames[i].Treating_Ailment;
                rep.Meeting_Slot = "1pm-2pm";
                rep.Date_Of_Meeting = Dates[i];
                List<string> meds = (from s in stock where s.Target_Ailment.Contains(docNames[i].Treating_Ailment) select s.Name).ToList();
                rep.Medicine = string.Join(",", meds);
                rep.Doctor_Contact_Number = docNames[i].Contact_Number;
                repSchedule.Add(rep);
            }

            return repSchedule;
        }
    }
}
