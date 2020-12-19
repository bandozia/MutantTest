using Microsoft.Extensions.Logging;
using MutantTest.API.Controllers.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MutantTest.API.Service
{
    public class DataDownloadService : IDataDownloadService
    {
        private readonly HttpClient _httpClient;        

        public DataDownloadService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }

        public async Task<IEnumerable<UserInfoDTO>> DownloadUserInfo(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseStream = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<UserInfoDTO>>(responseStream);
        }
               
    }
}
