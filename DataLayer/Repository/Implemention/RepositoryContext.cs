using Api.Portal.DataLayer.Repository.Entity;
using Api.Portal.DataLayer.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Portal.DataLayer.Repository.Implemention
{
    public class BankPortalRepository : IBankPortalRepository
    {
        public string ReadyForTransfer(CreditCardEntity entity)
        {
            return "داتیس آرین قشم";
        }
    }
}
