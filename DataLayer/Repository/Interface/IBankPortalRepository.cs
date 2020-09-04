using Api.Portal.DataLayer.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Portal.DataLayer.Repository.Interface
{
    public interface IBankPortalRepository
    {
        string ReadyForTransfer(CreditCardEntity entity);
    }
}
