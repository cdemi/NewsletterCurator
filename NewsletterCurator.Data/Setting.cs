using System.ComponentModel.DataAnnotations;

namespace NewsletterCurator.Data
{
    public class Setting
    {
        [Key, Required]
        public string Key { get; set; }
        
        public string Value { get; set; }
    }
}
