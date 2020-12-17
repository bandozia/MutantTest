using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MutantTest.Infra.Service
{
    public class UserDataDownloader : IUserDataDownloader
    {
        public async Task<string> DownloadUserData(string endpoint)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(endpoint))
                {
                    string responseText = await response.Content.ReadAsStringAsync();
                    return responseText;
                }
            }
        }
    }
}
