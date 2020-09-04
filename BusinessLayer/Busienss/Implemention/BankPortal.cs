using Api.Portal.BusinessLayer.Busienss.Interface;
using Api.Portal.BusinessLayer.ExceptionManagment.ExceptionManager;
using Api.Portal.BusinessLayer.Model;
using Api.Portal.DataLayer.Repository.Entity;
using Api.Portal.DataLayer.Repository.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Api.Portal.BusinessLayer.Busienss.Implemention
{
    public class BankPortal : IBankPortal
    {

        IBankPortalRepository _portalRepository = null;
        private readonly IMapper _mapper;
        public BankPortal(IBankPortalRepository bankPortalRepository , IMapper mapper)
        {
            _portalRepository = bankPortalRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// این متد عملیات انقال وجه را آماده سازی میکند و اطلاعات حساب مقصد  (نام حساب) را بر میگرداند
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string ReadyForTransfer(CreditCardModel model)
        {
            var creditCardEntity = _mapper.Map<CreditCardEntity>(model);
            List<string> responseText = new List<string>();

            if (!model.CardNumber.ToString().Substring(6, 1).Equals("3"))
            {
                throw ExManager.CreditCardException();
            }
            if (!model.DestinationCardNumber.ToString().Substring(6, 1).Equals("3"))
            {
                throw ExManager.CreditCardException();
            }
            if (!(model.CVV2.ToString().Trim().Length>=3 && model.CVV2.ToString().Trim().Length <= 4))
            {
                throw ExManager.CVV2Exception();
            }
            if (model.ExpireYear < CurrentDate ||  model.ExpireYear.ToString().Trim().Length != 2)
            {
                throw ExManager.YearException();
            }
            if (!(model.ExpireMonth > 0 && model.ExpireMonth <= 12) || model.ExpireMonth.ToString().Trim().Length!=2)
            {
                throw ExManager.MonthException();
            }
            if (!(Convert.ToInt64(model.Amount) >= 10000 && Convert.ToInt64(model.Amount) <= 3000000))
            {
                throw ExManager.AmountException();
            }

            return _portalRepository.ReadyForTransfer(creditCardEntity);
        }

        private int CurrentDate
        {
            get
            {
                PersianCalendar pc = new PersianCalendar();
                DateTime dt = DateTime.Now;
                int currentDate = System.Convert.ToInt32(pc.GetYear(dt).ToString().Substring(2, 2));
                return currentDate;
            }
        }
    }
}
