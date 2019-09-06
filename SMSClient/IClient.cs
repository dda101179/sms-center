using BL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SMSClient
{
    public interface IClient
    {
        Task<string> SendPackageAsync();
    }
}
