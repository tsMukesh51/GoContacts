using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoContacts.DTOs
{
    public class ApplicationUserDTO
    {
        public string UserName { get; set; }
        public bool IsEnabled { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
    }
}