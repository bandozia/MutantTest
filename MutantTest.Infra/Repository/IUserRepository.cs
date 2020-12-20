using MutantTest.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MutantTest.Infra.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserInfo>> InsertUserList(IEnumerable<UserInfo> userList);
    }
}
