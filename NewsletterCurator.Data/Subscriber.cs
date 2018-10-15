using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsletterCurator.Data
{
    public class Subscriber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public Guid ID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string DisplayName { get; set; }
        public DateTimeOffset? DateSubscribed { get; set; }
        public DateTimeOffset? DateValidated { get; set; }
        public DateTimeOffset? DateUnsubscribed { get; set; }
    }
}
