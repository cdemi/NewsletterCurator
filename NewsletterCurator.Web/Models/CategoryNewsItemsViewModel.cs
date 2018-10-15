using System.Collections.Generic;
using NewsletterCurator.Data;

namespace NewsletterCurator.Web.Models
{
    public class CategoryNewsItemsViewModel
    {
        public Category Category { get; set; }

        public List<Newsitem> Newsitems { get; set; }
    }
}
