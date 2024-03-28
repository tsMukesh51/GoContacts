using GoContacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoContacts.ViewModels
{
    public class ContactGroupTags
    {
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<GroupTag> GroupTags { get; set;}
    }
}