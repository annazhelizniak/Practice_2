using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2.Tools
{
    class DateOfBirthInPastException:Exception
    {
        public DateTime DateOfBirth
        {
            get;
        }
        public DateOfBirthInPastException() { }

        public DateOfBirthInPastException(string message)
            : base(message) { }

        public DateOfBirthInPastException(string message, Exception inner)
            : base(message, inner) { }

        public DateOfBirthInPastException(string message, DateTime dateOfBirth)
            : this(message)
        {
            DateOfBirth = dateOfBirth;
        }
    }
}
