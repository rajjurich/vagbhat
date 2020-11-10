using Contracts.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace WebClient
{
    public interface IPatientClient
    {
        Task<IEnumerable<PatientResponse>> GetPatients();
    }
    public class PatientClient : IPatientClient
    {
        [Inject]
        public IHttpClientFactory HttpClientFactory { get; set; }
        public async Task< IEnumerable<PatientResponse>> GetPatients()
        {
            var client = HttpClientFactory.CreateClient("webapi");
            var result = await client.GetAsync($"api/patient");            
            return await result.Content.ReadAsJsonAsync<List<PatientResponse>>();
        }
    }
}
