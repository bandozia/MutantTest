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
        private readonly IUserDataService _userDataService;

        public UsersController(ILogger<UsersController> logger, IUserDataDownloader userDataDownloader, IUserDataService userDataService)
        {
            _logger = logger;
            _userDataDownloader = userDataDownloader;
            _userDataService = userDataService;
        }

        /// <summary>
        /// Irá Baixar todos os dados em https://jsonplaceholder.typicode.com/users sem nenhum parsing.
        /// </summary>        
        [HttpGet("download")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                string result = await _userDataDownloader.DownloadUserData("https://jsonplaceholder.typicode.com/users");

                _logger.LogInformation("Lista usuarios recuperada com sucesso.");
                return Content(result, "application/json");
            }
            catch(Exception err)
            {
                _logger.LogError(err.Message);
                return Problem(err.Message);
            }
            
        }

        /// <summary>
        /// Insere todos os dados válidos que ainda não estão presentes no banco.
        /// </summary>
        /// <response code="201">Lista com os items que foram inseridos</response>
        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<IEnumerable<UserInfo>>> SaveUsers()
        {
            try
            {
                string result = await _userDataDownloader.DownloadUserData("https://jsonplaceholder.typicode.com/users");                
                var userFormList = JsonConvert.DeserializeObject<List<UserForm>>(result);

                await _userDataService.SaveUserData(userFormList.Select(u => u.ToUserInfo()));
                //TODO: resolver dependencia ciclica no json
                return Created(string.Empty, userFormList.Select(u => u.ToUserInfo()));
            }
            catch(Exception err)
            {
                _logger.LogError(err.Message);
                return Problem(err.Message);
            }

            
        }

    }
}
