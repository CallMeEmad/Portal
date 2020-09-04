using Api.Portal.BusinessLayer.ExceptionManagment.Exception;

namespace Api.Portal.BusinessLayer.ExceptionManagment.ExceptionManager
{
    public class ExManager
    {
        public static InvalidAmountValueException AmountException()
        {
            return new InvalidAmountValueException();
        }
        public static InvalidAmountValueException AmountException(string messsage)
        {
            return new InvalidAmountValueException(messsage);
        }


        public static InvalidCreditCardException CreditCardException()
        {
            return new InvalidCreditCardException();
        }
        public static InvalidCreditCardException CreditCardException(string message)
        {
            return new InvalidCreditCardException(message);
        }


        public static InvalidCVV2NumberException CVV2Exception()
        {
            return new InvalidCVV2NumberException();
        }
        public static InvalidCVV2NumberException CVV2Exception(string message)
        {
            return new InvalidCVV2NumberException(message);
        }


        public static InvalidMonthException MonthException()
        {
            return new InvalidMonthException();
        }
        public static InvalidMonthException MonthException(string message)
        {
            return new InvalidMonthException(message);
        }


        public static InvalidYearException YearException()
        {
            return new InvalidYearException();
        }
        public static InvalidYearException YearException(string message)
        {
            return new InvalidYearException(message);
        }
    }
}
