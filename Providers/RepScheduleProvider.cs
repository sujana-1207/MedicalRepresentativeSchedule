using MedicalRepresentativeSchedule.models;
using MedicalRepresentativeSchedule.repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MedicalRepresentativeSchedule.Providers
{
    public class RepScheduleProvider : IRepScheduleProvider
    {

        private readonly IRepScheduleRepository _repschedulerepository;
        public RepScheduleProvider(IRepScheduleRepository repschedulerepository)
        {
            _repschedulerepository = repschedulerepository;
        }




       
            
            //var i = medicines.Where(x => x.Target_Ailment == Treating_ailment).FirstOrDefault();
           

        public async Task<List<RepSchedule>> GetRepScheduleAsync(DateTime startdate)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("http://localhost:44394/api/MedicineStock"))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    List<MedicineStock> ItemList = JsonConvert.DeserializeObject<List<MedicineStock>>(apiResponse);
                    List<RepSchedule> dates=_repschedulerepository.

                }
            } 
        }

        
    }
}
