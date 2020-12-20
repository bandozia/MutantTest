using MutantTest.Domain.Model;
using MutantTest.Infra.Repository;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<UserInfo>> SaveUserData(IEnumerable<UserInfo> userInfoList)
        {            
            return await _userRepository.InsertUserList(userInfoList.Where(u => u.Address.IsSuite));
        }
    }
}
