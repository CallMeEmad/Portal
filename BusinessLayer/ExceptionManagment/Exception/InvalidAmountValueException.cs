namespace Api.Portal.BusinessLayer.ExceptionManagment.Exception
{
    public class InvalidAmountValueException : ExceptionBase
    {
        public InvalidAmountValueException() : 
            base("مبلغ انتقال باید حداقل 10 هزار تومان و حداکثر 3 میلیون تومان باشد")
        {

        }
        public InvalidAmountValueException(string message) : base(message)
        {
        }
    }
     
}
