using Contracts.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Contracts;

namespace WebClient
{
    public interface IPatientClient
    {
        Task<IEnumerable<PatientResponse>> GetPatients();
    }
    public class PatientClient : IPatientClient
    {       
        public IHttpClientFactory HttpClientFactory { get; set; }
        public PatientClient(IHttpClientFactory HttpClientFactory)
        {
            this.HttpClientFactory = HttpClientFactory;
        }
        public async Task< IEnumerable<PatientResponse>> GetPatients()
        {
            var client = HttpClientFactory.CreateClient("webapi");
            var result = await client.GetJsonAsync<PatientResponse[]>(ApiRoutes.Patients.Get);            
            return result;
        }
    }
}
