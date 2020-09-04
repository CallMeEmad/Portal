using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Portal.Logging
{
    public interface ILogHelper<T>
    {
        public string GenerateLogContent(string title, T model,string ip, bool successful, string error = "");
    }
}
