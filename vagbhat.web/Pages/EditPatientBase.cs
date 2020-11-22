using AutoMapper;
using Contracts.RequestModels;
using Contracts.ResponseModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClient;

namespace vagbhat.web.Pages
{
    public class EditPatientBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        public IPatientClient PatientClient { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }
        public CreatePatientRequest Patient { get; set; } = new CreatePatientRequest();
        public PatientResponse GetPatient { get; set; } = new PatientResponse();

        protected override async Task OnInitializedAsync()
        {
            GetPatient = await PatientClient.GetPatient(Id);
            Mapper.Map(GetPatient, Patient);
        }
        protected async Task SubmitForm()
        {
            await PatientClient.CreatePatient(Patient);
        }
    }
}
