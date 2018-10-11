using System.ComponentModel.DataAnnotations;

namespace NewsletterCurator.Data
{
    public class Recepient
    {
        [Key, Required]
        public string Email { get; set; }
        [Required]
        public string DisplayName { get; set; }
    }
}
