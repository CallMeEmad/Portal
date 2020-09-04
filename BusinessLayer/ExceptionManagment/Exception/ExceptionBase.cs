using SystemException = System.Exception;

namespace Api.Portal.BusinessLayer.ExceptionManagment.Exception
{
    public class ExceptionBase : SystemException
    {
        public ExceptionBase()
        {

        }
        public ExceptionBase(string message) : base(message)
        {

        }
    }
}
