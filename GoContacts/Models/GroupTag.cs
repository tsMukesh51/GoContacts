using System.ComponentModel.DataAnnotations;

namespace GoContacts.Models
{
    public class GroupTag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(128)]
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
        public GroupTag() 
        {
            ApplicationUserId = "zxghop";
        }
    }
}