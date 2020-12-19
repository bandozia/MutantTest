using MutantTest.API.Controllers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MutantTest.API.Service
{
    public interface IDataDownloadService
    {
        Task<IEnumerable<UserInfoDTO>> DownloadUserInfo(string url);
    }
}
