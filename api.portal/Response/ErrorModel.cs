using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Portal.Response
{
    public class ErrorModel
    {
        public ErrorModel()
        {
            Errors = new List<string>();
        }
        public string Detail { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string Instance { get; set; }
        public List<string> Errors { get; set; }
    }
}
