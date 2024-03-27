using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoContacts.Models
{
    public class ContactGroupTag
    {
        [Key, Column(Order = 0)]
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        [Key, Column(Order = 1)]
        public int GroupTagId { get; set; }
        public GroupTag GroupTag { get; set; }
    }
}