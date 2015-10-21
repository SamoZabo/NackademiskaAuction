using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Domain.Exception
{
    public class CustomerException : ApplicationException
    {
        public CustomerException(string message)
            : base(message)
        {
        }
    }

    public class CustomerNotFoundException : CustomerException
    {
        public CustomerNotFoundException(string message)
            : base(message)
        {
        }
    }

    public class InvalidPasswordException : CustomerException
    {
        public InvalidPasswordException(string message)
            : base(message)
        {
        }
    }

    public class EmailExistsException : CustomerException
    {
        public EmailExistsException(string message)
            : base(message)
        {
        }
    }

}
