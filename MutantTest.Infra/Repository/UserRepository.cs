using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MutantTest.Domain.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MutantTest.Infra.Repository
{
    public class UserRepository : BaseRepository<UserInfo>, IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(CoreContext context, ILogger<UserRepository> logger) : base(context)
        {
            _logger = logger;
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
                        _logger.LogInformation($"Novo usuario inserido: {user.Email}");
                    }
                    catch (DbUpdateException ex) when ((ex.InnerException as MySqlException).Number == 1062)
                    {   
                        _logger.LogWarning($"Tentativa de inserir duplicata: {user.Email}");
                        continue;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Erro ao inserir nova entrada: {ex.InnerException.Message}");
                        continue;
                    }                    
                }

                try
                {  
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Falha na transacao: {ex.Message}");
                }                             
            }

            return successList;
        }
    }
}
