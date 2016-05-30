using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain;
using Domain.Identity;
using Microsoft.AspNet.Identity;
using Web.Areas.User.ViewModels;
using Web.Controllers;

namespace Web.Areas.User.Controllers
{
    public class UserGameController : BaseController
    {
        private readonly IUOW _uow;

        public UserGameController(IUOW uow)
        {
            _uow = uow;
        }
        // GET: User/UserGame
        public ActionResult Index()
        {
            var vm = new UserGameIndexViewModel();
            int id = Int32.Parse(User.Identity.GetUserId());
            vm.Games = new List<Game>(_uow.Games.GetAllGamesForUser(_uow.PlayerInGames.GetPlayerGames(id)));
            vm.Game = _uow.Games.GetById(id);
            vm.Users = _uow.PlayerInGames.GetAllUsersInGames(id);
            vm.BasketsInTrack = _uow.Baskets.GetAllBasketsForTrack(id);
            vm.TotalPars = _uow.Baskets.GetTotalParsForTrak(vm.Game.TrackId);
            vm.Totalx = new List<KeyValuePair<int, int>>();

            foreach (var usr in vm.Users)
            {
                vm.Totalx.Add(new KeyValuePair<int, int>(usr.Id, _uow.Scores.GetScoreForPlayerGame(id, usr.Id, vm.TotalPars)));
            }

            return View(vm);
        }

        // GET: Admin/Games/Create
        [HttpGet]
        public ActionResult Create()
        {
            var vm = new UserGameViewModel();
            //if(email != null) vm.UsersList.Add(_uow.UsersInt.GetUserByUserName(email));
            vm.Tracks = new SelectList(_uow.Tracks.All, nameof(Track.TrackId), nameof(Track.TrackName));
            vm.UsersMultiList = new MultiSelectList(_uow.UsersInt.GetAllUserExpectGameCreator(Int32.Parse(User.Identity.GetUserId())), 
                nameof(UserInt.Id), nameof(UserInt.UserName));
         

            return View(vm);
        }

        // POST: Admin/Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserGameViewModel vm)
        {
            
            if (ModelState.IsValid)
            {
                _uow.Games.Add(vm.Game);
                _uow.PlayerInGames.Add(new PlayerInGame { GameId = vm.Game.GameId, UserId = Int32.Parse(User.Identity.GetUserId())});
                foreach (var id in vm.UserListBoxId)
                {
                    _uow.PlayerInGames.Add(new PlayerInGame
                    {
                        GameId = vm.Game.GameId,
                        UserId = id
                    });

                }
               
                _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            vm.Tracks = new SelectList(_uow.Tracks.AllIncluding(), nameof(Track.TrackId), nameof(Track.TrackName), vm.Game.TrackId);
            vm.UsersMultiList = new MultiSelectList(_uow.UsersInt.All, nameof(UserInt.Id), nameof(UserInt.UserName), vm.UserListBoxId);
            return View(vm);
        }



        public ActionResult Edit(int id)
        {
            var vm = new UserGameDetailViewModel
            {
                Game = _uow.Games.GetById(id),
                Users = _uow.PlayerInGames.GetAllUsersInGames(id),
                BasketsInTrack = _uow.Baskets.GetAllBasketsForTrack(id),
                Scores = _uow.Scores.GetScoresForGame(id)
            };
            vm.TotalPars = _uow.Baskets.GetTotalParsForTrak(vm.Game.TrackId);
            vm.Totalx = new List<KeyValuePair<int, int>>();

            foreach (var usr in vm.Users)
            {
                vm.Totalx.Add(new KeyValuePair<int, int>(usr.Id, _uow.Scores.GetScoreForPlayerGame(id, usr.Id, vm.TotalPars)));
            }

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserGameDetailViewModel vm)
        {
            if (ModelState.IsValid)
            {
                foreach (var score in vm.Scores)
                {                  
                        _uow.Scores.Update(score);                   
                }
                _uow.Commit();

                return RedirectToAction(nameof(Details), new {id = Int32.Parse(User.Identity.GetUserId())});
            }
            return View(vm);
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new UserGameDetailViewModel
            {
                Game = _uow.Games.GetById(id),
                Users = _uow.PlayerInGames.GetAllUsersInGames(id),
                BasketsInTrack = _uow.Baskets.GetAllBasketsForTrack(id)
            };
            vm.TotalPars = _uow.Baskets.GetTotalParsForTrak(vm.Game.TrackId);
            vm.TotalBaskets = _uow.Baskets.GetTotalBasketCount(vm.Game.TrackId);
       //     vm.TotalBaskets = _uow.Baskets.(vm.Game.TrackId);
            vm.Totalx = new List<KeyValuePair<int, int>>();

            foreach (var usr in vm.Users)
            {       
                vm.Totalx.Add(new KeyValuePair<int, int>(usr.Id, _uow.Scores.GetScoreForPlayerGame(id, usr.Id, vm.TotalPars)));
            }

            return View(vm);
        }


    }
}