using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.Areas.Admin.ViewModels
{
    public class PlayerInGamesViewModel
    {
        public PlayerInGame PlayerInGame { get; set; }
        public SelectList GameSelectList { get; set; }
        public SelectList UserSelectList { get; set; }
      }

    public class PlayerInGameIndexViewModel
    {
        public List<PlayerInGame> PlayerInGames { get; set; }
        public Game Game { get; set; }  
    }

}
