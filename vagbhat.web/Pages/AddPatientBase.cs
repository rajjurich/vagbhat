using Contracts.RequestModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClient;

namespace vagbhat.web.Pages
{
    public class AddPatientBase : ComponentBase
    {
        [Inject]
        public IPatientClient PatientClient { get; set; }
        public CreatePatientRequest Patient { get; set; } = new CreatePatientRequest();
        protected async Task SubmitForm()
        {            
            await PatientClient.CreatePatient(Patient);
        }
    }
}
