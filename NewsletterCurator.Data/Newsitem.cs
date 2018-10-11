using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsletterCurator.Data
{
    public class Newsitem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public DateTime DateTime { get; set; }
        public Category Category { get; set; }
        public string URL { get; set; }
        public string ImageURL { get; set; }
        public string Summary { get; set; }

    }
}
