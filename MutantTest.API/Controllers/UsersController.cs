using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MutantTest.Infra.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MutantTest.Domain.Model;
using MutantTest.API.Controllers.Form;
using Microsoft.AspNetCore.Http;

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
            
            _logger.LogInformation("Lista usuarios recuperada com sucesso.");
            return Content(result, "application/json");
        }

        /// <summary>
        /// Insere todos os dados válidos que ainda não estão presentes no banco.
        /// </summary>
        /// <response code="201">Lista com os items que foram inseridos</response>
        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<IEnumerable<UserInfo>>> SaveUsers()
        {
            string result = await _userDataDownloader.DownloadUserData("https://jsonplaceholder.typicode.com/users");
            var userInfoList = JsonConvert.DeserializeObject<List<UserForm>>(result);
            

            return Created(string.Empty, userInfoList.Select(u => u.ToUserInfo()));
        }

    }
}
