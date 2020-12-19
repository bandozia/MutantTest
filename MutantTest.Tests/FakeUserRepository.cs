using MutantTest.Domain.Model;
using MutantTest.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MutantTest.Tests
{
    internal class FakeUserRepository : BaseRepository<UserInfo>, IUserRepository
    {
        public FakeUserRepository(CoreContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserInfo>> InsertUserList(IEnumerable<UserInfo> userList)
        {
            List<UserInfo> successList = new List<UserInfo>();
            foreach (var user in userList)
            {
                try
                {
                    dbSet.Add(user);
                    await context.SaveChangesAsync();
                    successList.Add(user);                    
                }
                catch
                {                    
                    continue;
                }                
            }

            return successList;

        }
    }
}
