using System;
using System.ComponentModel.DataAnnotations;

namespace GoContacts.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        [Required]
        [StringLength(2000)]
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        [Required]
        [StringLength(128)]
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
        public Contact()
        {
            ApplicationUserId = "zxghop";
        }
    }
}