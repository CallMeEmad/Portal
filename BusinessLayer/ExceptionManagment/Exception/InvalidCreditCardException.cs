namespace Api.Portal.BusinessLayer.ExceptionManagment.Exception
{
    public class InvalidCreditCardException : ExceptionBase
    {
        public InvalidCreditCardException() : base("رقم هفتم شماره کارت برابر با عدد 3 نیست")
        {
        }
        public InvalidCreditCardException(string message) : base(message)
        {
        }
    }
     
}
