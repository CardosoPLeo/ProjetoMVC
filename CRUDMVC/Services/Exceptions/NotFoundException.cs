using System;
namespace CRUDMVC.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException (string message) : base(message)
        {

        }
    }
}
;