using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCForms.ViewModels
{
    public class BookViewModel
    {
        public string Title { get; set; }

        public string AuthorName { get; set; }

        public DateTime PublishedDate { get; set; }

        public int Rating { get; set; }
    }
}