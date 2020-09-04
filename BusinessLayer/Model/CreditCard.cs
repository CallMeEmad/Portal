using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Portal.BusinessLayer.Model
{
    public class CreditCardModel
    {
        [Description("شماره کارت مبدا")]
        public decimal CardNumber { get; set; }
        [Description("شماره کارت مقصد")]
        public decimal DestinationCardNumber { get; set; }
        [Description("کد اعتبارسنجی")]
        public int CVV2 { get; set; }
        [Description("ماه انقضا کارت")]
        public int ExpireMonth { get; set; }
        [Description("سال انقضا کارت")]
        public int ExpireYear { get; set; }
        [Description("مقدار مبلع برای انتقال")]
        public string Amount { get; set; }

    }
}
