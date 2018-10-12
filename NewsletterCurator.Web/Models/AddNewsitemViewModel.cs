using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewsletterCurator.Data;

namespace NewsletterCurator.Web.Models
{
    public class AddNewsitemViewModel
    {
        public string URL { get; set; }
        public Category Category { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public string Title { get; internal set; }
    }
}
