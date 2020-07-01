using System;
namespace CRUDMVC.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public  DbConcurrencyException(string message) : base(message)
        {
            
        }
    }
}
