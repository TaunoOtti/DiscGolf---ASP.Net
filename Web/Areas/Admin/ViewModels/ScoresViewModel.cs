using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class ScoresIndexViewModel
    {
        public List<Score> Scores { get; set; } 
    }

    public class ScoreCreateEditViewModel
    {
        public Track Track { get; set; }
        public Score Score { get; set; }
        public Basket Basket { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public SelectList BasketSelectList { get; set; }
        public SelectList GameSelectList { get; set; }
        public SelectList TrackSelectList { get; set; }
        public SelectList UserSelectList { get; set; }  

    }

    public class ScoreChooseGameViewModel
    {
        public Game Game { get; set; }
        public int GameId { get; set; }
        public SelectList GameSelectList { get; set; }
    }
}