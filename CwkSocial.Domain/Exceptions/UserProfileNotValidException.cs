using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Domain.Exceptions
{
    public class UserProfileNotValidException : NotValidException
    {
        internal UserProfileNotValidException()
        {

        }

        internal UserProfileNotValidException(string message) : base(message)
        {

        }

        public UserProfileNotValidException(string message, Exception inner): base(message, inner)
        {

        }

    }
}
