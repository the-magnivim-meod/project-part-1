﻿using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace BE
{
    public class User
    {
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public string UserName { get; set; }
        public SecureString Password { get;private set; }
        public UserType Type { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
