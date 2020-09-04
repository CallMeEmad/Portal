namespace Api.Portal.BusinessLayer.ExceptionManagment.Exception
{
    public class InvalidYearException : ExceptionBase
    {
        public InvalidYearException() : base("سال انقضا کارت معتبر نیست")
        {
        }
        public InvalidYearException(string message) : base(message)
        {
        }
    }
     
}
