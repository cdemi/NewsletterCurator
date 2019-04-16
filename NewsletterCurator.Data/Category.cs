using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsletterCurator.Data
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Newsitem> Newsitems { get; set; }
        [Required]
        public float Priority { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string HashTag { get; set; }
    }
}
