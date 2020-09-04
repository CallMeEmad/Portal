namespace Api.Portal.BusinessLayer.ExceptionManagment.Exception
{
    public class InvalidCVV2NumberException : ExceptionBase
    {
        public InvalidCVV2NumberException() : base("کد اعتبارسنجی باید 3 یا 4 رقم باشد")
        {
        }
        public InvalidCVV2NumberException(string message) : base(message)
        {
        }
    }
     
}
