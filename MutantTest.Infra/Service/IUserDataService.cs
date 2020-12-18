using MutantTest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MutantTest.Infra.Service
{
    public interface IUserDataService
    {
        Task SaveUserData(IEnumerable<UserInfo> userInfoList);
    }
}
