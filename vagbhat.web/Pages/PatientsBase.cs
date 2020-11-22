using Contracts.ResponseModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebClient;

namespace vagbhat.web.Pages
{
    public class PatientsBase : ComponentBase
    {
        [Inject]
        public IPatientClient PatientClient { get; set; }
        protected IEnumerable<PatientResponse> Patients { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Patients = await PatientClient.GetPatients();           
        }
    }
}
