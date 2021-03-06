﻿using MutantTest.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MutantTest.Infra.Service
{
    public interface IUserDataService
    {
        Task<IEnumerable<UserInfo>> SaveUserData(IEnumerable<UserInfo> userInfoList);
    }
}
