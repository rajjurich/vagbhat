using Contracts.ResponseModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace vagbhat.web.Pages
{
    public class PatientsBase : ComponentBase
    {
        [Inject]
        public IHttpClientFactory HttpClientFactory { get; set; }
        protected IEnumerable<PatientResponse> Patients { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var client = HttpClientFactory.CreateClient("webapi");
            var result = await client.GetAsync($"api/patient");
            var str = await result.Content.ReadAsStringAsync();
            //Patients = JSON.DeserializeObject<List<PatientResponse>>(str);
            await Task.Run(GetPatients);            
        }

        private void GetPatients()
        {
            System.Threading.Thread.Sleep(5000);
            PatientResponse patient1 = new PatientResponse
            {
                Id = "1",
                MobileNumber = "99999",
                PatientName = "aaaa"
            };

            Patients = new List<PatientResponse> { patient1 };
        }
    }
}
