using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MutantTest.Infra.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MutantTest.Domain.Model;

namespace MutantTest.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserDataDownloader _userDataDownloader;

        public UsersController(ILogger<UsersController> logger, IUserDataDownloader userDataDownloader)
        {
            _logger = logger;
            _userDataDownloader = userDataDownloader;
        }

        /// <summary>
        /// Irá Baixar todos os dados em https://jsonplaceholder.typicode.com/users sem nenhum parsing.
        /// </summary>        
        [HttpGet("download")]
        public async Task<IActionResult> GetUsers()
        {
            string result = await _userDataDownloader.DownloadUserData("https://jsonplaceholder.typicode.com/users");
            var userInfoList = JsonConvert.DeserializeObject<List<UserInfo>>(result);            
            return Content(result, "application/json");
        }
    }
}
