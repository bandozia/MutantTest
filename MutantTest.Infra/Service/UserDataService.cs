using MutantTest.Domain.Model;
using MutantTest.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MutantTest.Infra.Service
{
    public class UserDataService : IUserDataService
    {
        private readonly IUserRepository _userRepository;

        public UserDataService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task SaveUserData(IEnumerable<UserInfo> userInfoList)
        {
            await _userRepository.InsertUserList(userInfoList);
        }
    }
}
