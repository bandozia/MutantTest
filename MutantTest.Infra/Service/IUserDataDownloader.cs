using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MutantTest.Infra.Service
{
    public interface IUserDataDownloader
    {
        Task DownloadUserData();
    }
}
