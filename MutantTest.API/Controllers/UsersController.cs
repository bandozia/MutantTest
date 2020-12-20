using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MutantTest.Infra.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MutantTest.API.Controllers.Dto;
using Microsoft.AspNetCore.Http;
using MutantTest.API.Service;

namespace MutantTest.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserDataService _userDataService;
        private readonly IDataDownloadService _dataDownload;

        public UsersController(ILogger<UsersController> logger, IUserDataService userDataService, IDataDownloadService dataDownload)
        {
            _logger = logger;            
            _userDataService = userDataService;
            _dataDownload = dataDownload;
        }

        /// <summary>
        /// Irá recuperar todos os dados em https://jsonplaceholder.typicode.com/users
        /// </summary>        
        [HttpGet("download")]
        public async Task<ActionResult<IEnumerable<UserInfoDTO>>> GetUsers()
        {
            try
            {   
                var userList = await _dataDownload.DownloadUserInfo("https://jsonplaceholder.typicode.com/users");
                _logger.LogInformation("Lista usuarios recuperada com sucesso.");

                return Ok(userList);
            }
            catch (Exception err)
            {
                _logger.LogError(err.Message);
                return Problem(err.Message);
            }
            
        }

        /// <summary>
        /// Insere todos os dados válidos que ainda não estão presentes no banco.
        /// </summary>
        /// <response code="201">Lista com os items que foram inseridos.</response>
        /// <response code="409">Nenhum dos items foi inserido. Possivelmente todos duplicados.</response>
        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<IEnumerable<UserInfoDTO>>> SaveUsers()
        {
            try
            {                
                var userFormList = await _dataDownload.DownloadUserInfo("https://jsonplaceholder.typicode.com/users");
                var successList = await _userDataService.SaveUserData(userFormList.Select(u => u.ToUserInfo()));
                                
                if (successList.Count() > 0)
                    return Created(string.Empty, successList.Select(u => new UserInfoDTO(u)));
                else
                    return Conflict("Nenhum item adcionado");
                
            }
            catch(Exception err)
            {                
                _logger.LogError(err.Message);
                return Problem(err.Message);
            }
        }

    }
}
