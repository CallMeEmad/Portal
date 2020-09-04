using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Portal.Response
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            ErrorModel = new ErrorModel();
        }
        public ErrorModel ErrorModel { get; set; }
        public string Data { get; set; }
    }
}
