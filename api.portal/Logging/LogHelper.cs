using Api.Portal.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Portal.Logging
{
    public class LogHelper<T> : ILogHelper<T> 
    {
        public string GenerateLogContent(string title, T model, string ip, bool successful, string error = "")
        {
 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($"کاربری با شناسه ای پی [{ip}] درخواست ({title}) ارسال کرده است");
            sb.AppendLine("داده های ورودی : ");
            sb.AppendLine(model.ToString());
            if (!successful)
            {
                sb.AppendLine("وضعیت عملیات : شکست");
                sb.AppendLine($"علت : {error}");
            }
            else
            {
                sb.AppendLine("وضعیت عملیات : موفقیت");
            }

            return sb.ToString();
        }
    }
}
