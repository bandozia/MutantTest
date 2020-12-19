using Microsoft.EntityFrameworkCore;
using MutantTest.Domain.Model;
using MySql.Data.MySqlClient;
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

        public async Task<IEnumerable<UserInfo>> InsertUserList(IEnumerable<UserInfo> userList)
        {
            List<UserInfo> successList = new List<UserInfo>();            
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                foreach (var user in userList)
                {
                    try
                    {
                        dbSet.Add(user);
                        context.SaveChanges();
                        successList.Add(user);
                    }
                    catch
                    {
                        continue;
                    }
                }

                try
                {  
                    await transaction.CommitAsync();
                }
                catch
                {
                    Console.WriteLine("deu merda");
                }                             
            }

            return successList;
        }
    }
}
