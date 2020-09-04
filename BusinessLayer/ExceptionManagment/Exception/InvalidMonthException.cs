namespace Api.Portal.BusinessLayer.ExceptionManagment.Exception
{
    public class InvalidMonthException : ExceptionBase
    {
        public InvalidMonthException() : base("ماه انقضا کارت معتبر نیست")
        {
        }
        public InvalidMonthException(string message) : base(message)
        {
        }
    }
     
}
