using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2.Tools
{
    class WrongEmailException:Exception
    {
        public string Email
        {
            get;
        }
        public WrongEmailException() { }

        public WrongEmailException(string message)
            : base(message) { }

        public WrongEmailException(string message, Exception inner)
            : base(message, inner) { }

        public WrongEmailException(string message, string email)
            : this(message)
        {
            Email = email;
        }
    }
}
