using Api.Portal.Model;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Portal.Validator
{
    public class CreditCardValidator : AbstractValidator<CreditCardDto>
    {
        public CreditCardValidator()
        {
            RuleFor(x => x.CVV2)
                .NotEmpty().WithMessage("کد اعتبار سنجی را وارد کنید")
                .NotNull().WithMessage("کد اعتبار سنجی را وارد کنید");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("مبلع انتقال را وارد کنید")
                .NotNull().WithMessage("مبلع انتقال را وارد کنید");

            RuleFor(x => x.CardNumber)
               .Must(x=> CardNumberValidate(x)).WithMessage("شماره کارت مبدا باید 16 رقم باشد");

            RuleFor(x => x.DestinationCardNumber)
                .Must(x => CardNumberValidate(x)).WithMessage("شماره کارت  مقصد باید 16 رقم باشد");

            RuleFor(x => x.ExpireYear)
                .NotEmpty().WithMessage("سال انقضا را وارد کنید")
                .NotNull().WithMessage("سال انقضا را وارد کنید");

            RuleFor(x => x.ExpireMonth)
                .NotEmpty().WithMessage("ماه انقضا را وارد کنید")
                .NotNull().WithMessage("ماه انقضا را وارد کنید");
        }

        private bool CardNumberValidate(decimal number)
        {
           return number.ToString().Length == 16;
        }
    }
}
