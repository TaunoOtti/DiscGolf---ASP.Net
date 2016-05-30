using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Identity;

namespace Web.Areas.User.ViewModels
{
    public class UserGameViewModel
    {
        public Game Game { get; set; }
        public UserInt UserInt { get; set; }
        public SelectList Tracks{ get; set; }
        public MultiSelectList Users { get; set; }
        public PlayerInGame PlayerInGame { get; set; }
        public List<UserInt> UsersList { get; set; }
        public MultiSelectList UsersMultiList { get; set; }
        public int[] UserListBoxId { get; set; }
        public List<Basket> BasketsInTrack { get; set; }


    }

    public class UserGameIndexViewModel
    {
        public Game Game { get; set; }
        public List<Game> Games { get; set; }
        public List<UserInt> Users { get; set; }
        public List<Basket> BasketsInTrack { get; set; }
        public List<KeyValuePair<int, int>> Totalx { get; set; }
        public int TotalPars { get; set; }
        //public List<UserInt> Users { get; set; }
        //public List<Basket> BasketsInTrack { get; set; }
    }

    public class UserGameDetailViewModel
    {
        public Game Game { get; set; }
        public List<UserInt> Users { get; set; }
        public List<Basket> BasketsInTrack { get; set; }
        public List<Score> Scores { get; set; }
        public List<KeyValuePair<int, int>> Totalx { get; set; }
        public int TotalPars { get; set; }
        public int TotalBaskets { get; set; }   

    }


}