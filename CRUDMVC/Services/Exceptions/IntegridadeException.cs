using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDMVC.Services.Exceptions
{
    public class IntegridadeException : ApplicationException
    {
        public IntegridadeException(string messegae) : base(messegae)
        {
           
        }
    }
}