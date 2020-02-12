using System;
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
        public string Password { get; set; }
        public string MailAddress { get; set; }
        public UserType Type { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool finish { get; set; } = false;
    }
}
