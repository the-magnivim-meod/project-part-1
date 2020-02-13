using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() { }
    }
}
