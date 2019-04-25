using System.Collections.Generic;

namespace NewsletterCurator.Web.Models
{
    public class PreviewModel
    {
        public List<CategoryNewsItemsViewModel> Newsitems { get; set; }
        public bool IsWeb { get; set; }
    }
}
