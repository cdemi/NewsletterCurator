using System.ComponentModel.DataAnnotations;

namespace NewsletterCurator.Data
{
    public class Recepient
    {
        [Key]
        public string Email { get; set; }
        public string DisplayName { get; set; }
    }
}
