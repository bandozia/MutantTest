using MutantTest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MutantTest.Infra.Repository
{
    public class UserRepository : BaseRepository<UserInfo>, IUserRepository
    {
        public UserRepository(AppContext context) : base(context)
        {
        }

        public Task SaveUserList(IEnumerable<UserInfo> userList)
        {
            
            throw new NotImplementedException();
        }
    }
}
