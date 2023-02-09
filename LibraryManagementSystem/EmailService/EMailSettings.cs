using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.EmailService
{
    public class EMailSettings
    {
        public string APIKey { get; set; }
        public string FromMailId { get; set; }
        public string FromMailName { get; set; }
    }
}