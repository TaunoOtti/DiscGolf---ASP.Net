using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class TracksIndexViewModel
    {
        public List<Track> Tracks { get; set; } 
    }

    public class TracksViewModel
    {
        public Track Track { get; set; }

    }
}