using System.Collections.Generic;
using NewsletterCurator.Data;

namespace NewsletterCurator.Web.Models
{
    public class HomeView
    {
        public List<CategoryNewsItemsViewModel> CategoryNewsItems { get; set; }
        public List<Setting> Settings { get; set; }
    }
}
