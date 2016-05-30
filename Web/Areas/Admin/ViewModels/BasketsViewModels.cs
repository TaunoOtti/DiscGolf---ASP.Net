using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class BasketsIndexViewModels
    {
        public Basket Basket { get; set; }
        public List<Basket> Baskets { get; set; }    
    }

    public class BasketsViewModel
    {
        public Basket Basket { get; set; }
        public SelectList TrackSelectList { get; set; }    
    }
}