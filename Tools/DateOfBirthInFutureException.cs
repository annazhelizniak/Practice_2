using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2.Tools
{
    class DateOfBirthInFutureException:Exception
    {
        public DateTime DateOfBirth
        {
            get;
        }
        public DateOfBirthInFutureException() { }

        public DateOfBirthInFutureException(string message)
            : base(message) { }

        public DateOfBirthInFutureException(string message, Exception inner)
            : base(message, inner) { }

        public DateOfBirthInFutureException(string message, DateTime dateOfBirth)
            : this(message)
        {
            DateOfBirth = dateOfBirth;
        }
    }

}
