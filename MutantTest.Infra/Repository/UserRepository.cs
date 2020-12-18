using MutantTest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MutantTest.Infra.Repository
{
    public class UserRepository : BaseRepository<UserInfo>, IUserRepository
    {
        public UserRepository(CoreContext context) : base(context)
        {
        }

        public async Task InsertUserList(IEnumerable<UserInfo> userList)
        {
            dbSet.AddRange(userList);
            await context.SaveChangesAsync();
        }
    }
}
