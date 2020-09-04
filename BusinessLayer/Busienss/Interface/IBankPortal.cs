using Api.Portal.BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Portal.BusinessLayer.Busienss.Interface
{
    public interface IBankPortal
    {
        string ReadyForTransfer(CreditCardModel model);
    }
}
