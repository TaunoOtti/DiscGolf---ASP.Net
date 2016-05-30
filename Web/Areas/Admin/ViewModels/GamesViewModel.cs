using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class GamesIndexViewModel
    {
        public List<Game> Games { get; set; }
        public Game Game { get; set; }
    }

    public class GamesViewModel
    {
        public Game Game { get; set; }
        public SelectList TrackSelectList { get; set; }


    }
}