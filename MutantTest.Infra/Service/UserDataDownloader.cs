using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MutantTest.Infra.Service
{
    public class UserDataDownloader : IUserDataDownloader
    {
        public async Task DownloadUserData()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:1234"))
                {
                    string responseText = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseText);
                }
            }
        }
    }
}
