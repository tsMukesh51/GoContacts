using GoContacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoContacts.ViewModels
{
    public class ContactGroupTagForm
    {
        public Contact Contact { get; set; }
        public IEnumerable<GroupTag> GroupTags { get; set; }
        public IEnumerable<int> SelectedGroupTags { get; set; }
    }
}