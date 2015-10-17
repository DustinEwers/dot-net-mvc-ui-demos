using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vNextUIDemos.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
