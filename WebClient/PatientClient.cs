using Contracts.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Contracts;
using Contracts.RequestModels;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WebClient
{
    public interface IPatientClient
    {
        Task<IEnumerable<PatientResponse>> GetPatients();
        Task<PatientResponse> CreatePatient(CreatePatientRequest newPatient);
        Task<PatientResponse> GetPatient(string Id);
    }
    public class PatientClient : IPatientClient
    {
        public IHttpClientFactory HttpClientFactory { get; set; }
        public HttpClient Client { get; set; }
        readonly string route;
        public PatientClient(IHttpClientFactory HttpClientFactory)
        {
            this.HttpClientFactory = HttpClientFactory;
            Client = HttpClientFactory.CreateClient("webapi");
            Client.AddTokenToHeader("token");
            route = ApiRoutes.Patients.Sub;
        }
        public async Task<IEnumerable<PatientResponse>> GetPatients()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                route);
            var result = await Client.SendAsync(httpRequestMessage);
            var contents = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                IEnumerable<PatientResponse> patients = JsonConvert
                    .DeserializeObject<IEnumerable<PatientResponse>>(contents);
                return patients;
            }
            return null;
        }

        public async Task<PatientResponse> CreatePatient(CreatePatientRequest newPatient)
        {
            HttpRequestMessage httpRequestMessage;
            if (newPatient.PatientId != null)
            {
                httpRequestMessage = new HttpRequestMessage(HttpMethod.Put,
                    route + "/" + newPatient.PatientId);
            }
            else
            {
                httpRequestMessage = new HttpRequestMessage(HttpMethod.Post,
                    ApiRoutes.Patients.Sub);
            }

            string serializedPatient = JsonConvert.SerializeObject(newPatient);
            httpRequestMessage.Content = new StringContent(serializedPatient);

            httpRequestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var result = await Client.SendAsync(httpRequestMessage);
            var contents = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                PatientResponse patient = JsonConvert.DeserializeObject<PatientResponse>(contents);
                return patient;
            }
            return null;
        }

        public async Task<PatientResponse> GetPatient(string Id)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                route + "/" + Id);
            var result = await Client.SendAsync(httpRequestMessage);
            var contents = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                PatientResponse patient = JsonConvert
                    .DeserializeObject<PatientResponse>(contents);
                return patient;
            }
            return null;
        }
    }
}
