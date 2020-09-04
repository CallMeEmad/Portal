using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Portal.BusinessLayer.Busienss;
using Api.Portal.BusinessLayer.Busienss.Interface;
using Api.Portal.BusinessLayer.ExceptionManagment.Exception;
using Api.Portal.BusinessLayer.Model;
using Api.Portal.Logging;
using Api.Portal.Model;
using Api.Portal.Response;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Portal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BankPortalController : Controller
    {
        private readonly ILogHelper<CreditCardDto> _logHelper = null;
        private readonly ILogger<BankPortalController> _logger = null;
        private readonly IMapper _mapper = null;
        private readonly IValidator<CreditCardDto> _validator = null;
        private IBankPortal _bankPortal = null;
 
        public BankPortalController(IBankPortal bankPortal, IMapper mapper, IValidator<CreditCardDto> validator, ILogger<BankPortalController> logger,ILogHelper<CreditCardDto> logHelper)
        {
            _bankPortal = bankPortal;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
            _logHelper = logHelper;
        }

        [HttpPost]
        public ResponseModel ReadyForTransfer([FromBody] CreditCardDto creditCard)
        {
            var validationResult = _validator.Validate(creditCard);
            ResponseModel responseModel = new ResponseModel();
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();

            /* در اینجا بصورت پیشفرض در نظر گرفته میشود که خطای وجود دارد
            *   اگر عملیات با موفقیت انجام شود مدل خطا پاک خواهد شد
            * */

            responseModel.ErrorModel.Detail = "در هنگام بررسی و صحت اطلاعات خطایی رخ داده است";
            responseModel.ErrorModel.Title = "خطا";
            responseModel.ErrorModel.Instance = "api.domain.com/api/ReadyForTransfer";
            responseModel.ErrorModel.Type = "api.domain.com/api/doc.pdf";


            if (validationResult.IsValid)
            {
                CreditCardModel model = _mapper.Map<CreditCardModel>(creditCard);

                try
                {
                    responseModel.Data = _bankPortal.ReadyForTransfer(model);
                    responseModel.ErrorModel = new ErrorModel();
                    var content =_logHelper.GenerateLogContent("عملیات بررسی صحت اطلاعات وارد شده و انتقال به مرحله نهایی", creditCard, ip, true);
                    _logger.Log(LogLevel.Information, content);

                }
                catch (InvalidCreditCardException creditCardEx)
                {
                    responseModel.ErrorModel.Errors.Add(creditCardEx.Message);
                    responseModel.ErrorModel.Status = 400;
                    var content = _logHelper.GenerateLogContent("عملیات بررسی صحت اطلاعات وارد شده و انتقال به مرحله نهایی", creditCard, ip, false, creditCardEx.Message);
                    _logger.Log(LogLevel.Error, content);
                }
                catch (InvalidAmountValueException amountValueEx)
                {
                    responseModel.ErrorModel.Errors.Add(amountValueEx.Message);
                    responseModel.ErrorModel.Status = 400;
                    var content = _logHelper.GenerateLogContent("عملیات بررسی صحت اطلاعات وارد شده و انتقال به مرحله نهایی", creditCard, ip, false, amountValueEx.Message);
                    _logger.Log(LogLevel.Error, content);
                }
                catch (InvalidYearException yearEx)
                {
                    responseModel.ErrorModel.Errors.Add(yearEx.Message);
                    responseModel.ErrorModel.Status = 400;
                    var content = _logHelper.GenerateLogContent("عملیات بررسی صحت اطلاعات وارد شده و انتقال به مرحله نهایی", creditCard, ip, false, yearEx.Message);
                    _logger.Log(LogLevel.Error, content);
                }
                catch (InvalidMonthException monthEx)
                {
                    responseModel.ErrorModel.Errors.Add(monthEx.Message);
                    responseModel.ErrorModel.Status = 400;
                    var content = _logHelper.GenerateLogContent("عملیات بررسی صحت اطلاعات وارد شده و انتقال به مرحله نهایی", creditCard, ip, false, monthEx.Message);
                    _logger.Log(LogLevel.Error, content);
                }
                catch (InvalidCVV2NumberException cvv2NumberEx)
                {
                    responseModel.ErrorModel.Errors.Add(cvv2NumberEx.Message);
                    responseModel.ErrorModel.Status = 400;
                    var content = _logHelper.GenerateLogContent("عملیات بررسی صحت اطلاعات وارد شده و انتقال به مرحله نهایی", creditCard, ip, false, cvv2NumberEx.Message);
                    _logger.Log(LogLevel.Error, content);
                }
                catch (Exception ex)
                {
                    responseModel.ErrorModel.Errors.Add(ex.Message);
                    responseModel.ErrorModel.Status = 500;
                    var content = _logHelper.GenerateLogContent("عملیات بررسی صحت اطلاعات وارد شده و انتقال به مرحله نهایی", creditCard, ip, false, ex.Message);
                    _logger.Log(LogLevel.Error, content);
                }
            }
            else
            {
                responseModel.ErrorModel.Status = 400;

                //خطا های برگردانده شده از فلونت ولیدیشن
                List<string> list = new List<string>();
                foreach (var item in validationResult.Errors)
                    responseModel.ErrorModel.Errors.Add(item.ErrorMessage);
            }
            return responseModel;
        }
        
    }
}
