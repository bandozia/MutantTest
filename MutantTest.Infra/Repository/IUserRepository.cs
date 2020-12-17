using MutantTest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MutantTest.Infra.Repository
{
    public interface IUserRepository
    {
        Task SaveUserList(IEnumerable<UserInfo> userList);
    }
}
