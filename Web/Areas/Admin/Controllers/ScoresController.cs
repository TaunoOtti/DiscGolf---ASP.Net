using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using Domain;
using Domain.Identity;
using Microsoft.AspNet.Identity;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ScoresController : BaseController
    {
        private readonly IUOW _uow;
        
        //private DataBaseContext db = new DataBaseContext();

        public ScoresController(IUOW uow)
        {
            _uow = uow;           
        }

        // GET: Admin/Scores
        public ActionResult Index()
        {
            var scores = new ScoresIndexViewModel()
            {
                Scores = _uow.Scores.All
            };
          
            //var scores = db.Scores.Include(s => s.Basket);
            return View(scores);
        }

        public ActionResult ChooseGame()
        {
            //var vm = new ScoreCreateEditViewModel();
            var vm = new ScoreChooseGameViewModel();

            vm.GameSelectList = new SelectList(_uow.Games.All, nameof(Game.GameId), nameof(Game.GameName));

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChooseGame(ScoreChooseGameViewModel vm)
        {
         
            vm.GameSelectList = new SelectList(_uow.Games.All, nameof(Game.GameId), nameof(Game.GameName), vm.Game.GameId);
            vm.GameId = vm.Game.GameId;
            int ad = vm.GameId;

            if (ModelState.IsValid)
            {
                return RedirectToAction("Create", new { gameId = ad});
            }

            return View(vm);
        }

        // GET: Admin/Scores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = _uow.Scores.GetById(id);
           // Score score = db.Scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // GET: Admin/Scores/Create
        public ActionResult Create(int gameId)
        {
          
            var vm = new ScoreCreateEditViewModel();

            vm.Game = _uow.Games.GetById(gameId);
            vm.Track = vm.Game.Track; /*_uow.Tracks.GetTrackByGameId(gameId);*/
            vm.BasketSelectList = new SelectList(_uow.Baskets.GetAllBasketsForTrack(vm.Track.TrackId), nameof(Basket.BasketId), nameof(Basket.BasketNr));
            vm.UserSelectList = new SelectList(_uow.PlayerInGames.GetAllUsersInGames(gameId), nameof(UserInt.Id), nameof(UserInt.Email));
            

            return View(vm);
        }

        // POST: Admin/Scores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScoreCreateEditViewModel vm)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            vm.BasketSelectList = new SelectList(_uow.Baskets.All, nameof(Basket.BasketId), nameof(Basket.BasketNr), vm.Score.BasketId);
           // vm.UserSelectList = new SelectList(_uow.UsersInt.All, nameof(UserInt.Id), nameof(UserInt.Email), _uow.PlayerInGames.GetPlayerInGameId(vm.GameId,vm.Score.PlayerInGame.UserId));
            vm.Score.PlayerInGameId = _uow.PlayerInGames.GetPlayerInGameId(vm.GameId, vm.Score.PlayerInGame.UserId);
            vm.Score.GameId = vm.GameId;
            vm.Score.Basket = _uow.Baskets.GetById(vm.Score.BasketId);
            vm.Score.Game = _uow.Games.GetById(vm.Score.GameId);
            vm.Score.PlayerInGame = _uow.PlayerInGames.GetById(vm.Score.PlayerInGameId);
           

            if (ModelState.IsValid && vm.Score.BasketId != 0 && vm.Score.PlayerInGameId != 0 && vm.Score.GameId != 0 && vm.Score.Throws != 0 )
            {
                _uow.Scores.Add(vm.Score);
                _uow.Commit();

                return RedirectToAction(nameof(Index));
            }

           // vm.GameSelectList = new SelectList(_uow.Games.All, nameof(Game.GameId), nameof(Game.GameName), vm.Score.GameId);
           

         
             //  _uow.PlayerInGames.GetPlayerInGameId(vm.GameId,vm.Score.PlayerInGame.UserId));

            return View(vm);
        }

        // GET: Admin/Scores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = _uow.Scores.GetById(id);
            
            if (score == null)
            {
                return HttpNotFound();
            }
             var vm = new ScoreCreateEditViewModel()
            {
                Score = score,
                Game = _uow.Games.GetById(score.GameId),
                Track = _uow.Tracks.GetTrackByGameId(score.GameId),
               
                               
        };

            vm.UserSelectList = new SelectList(_uow.PlayerInGames.GetAllUsersInGames(vm.Score.GameId), nameof(UserInt.Id), nameof(UserInt.Email));
            vm.BasketSelectList = new SelectList(_uow.Baskets.All, nameof(Basket.BasketId), nameof(Basket.BasketNr), vm.Score.BasketId);
            vm.GameId = vm.Game.GameId;
          //  vm.Game = _uow.Games.GetById(vm.GameId);
            //vm.Score.PlayerInGameId = _uow.PlayerInGames.GetPlayerInGameId(vm.GameId, vm.Score.PlayerInGame.UserId);

            //ViewBag.BasketId = new SelectList(db.Baskets, "BasketId", "Comment", score.BasketId);
            return View(vm);
        }

        // POST: Admin/Scores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScoreCreateEditViewModel vm)
        {
            vm.BasketSelectList = new SelectList(_uow.Baskets.All, nameof(Basket.BasketId), nameof(Basket.BasketNr), vm.Score.BasketId);
            //vm.UserSelectList = new SelectList(_uow.UsersInt.All, nameof(UserInt.Id), nameof(UserInt.Email), _uow.PlayerInGames.GetPlayerInGameId(vm.Game.GameId, vm.Score.PlayerInGame.UserId));

            vm.Score.PlayerInGameId = _uow.PlayerInGames.GetPlayerInGameId(vm.GameId, vm.Score.PlayerInGame.UserId);// vm.Score.PlayerInGame.PlayerInGameId;
            vm.Score.GameId = vm.GameId;
            //vm.Score.ScoreId = vm.Score.ScoreId;

            //vm.Score.Game = null;
            //vm.Score.PlayerInGame = null;
            //vm.GameId = 0;
            //vm.Game = null;
            //vm.Basket = null;
            //vm.Track = null;

            if (ModelState.IsValid && vm.Score.BasketId != 0 && vm.Score.PlayerInGameId != 0 && vm.Score.GameId != 0 && vm.Score.Throws != 0)
            {
                _uow.Scores.Update(vm.Score);
                _uow.Commit();
                
                return RedirectToAction(nameof(Index));
            }
            //vm.BasketSelectList = new SelectList(_uow.Baskets.All, nameof(Basket.BasketId), nameof(Basket.BasketNr), vm.Score.BasketId);
            //vm.GameSelectList = new SelectList(_uow.Games.All, nameof(Game.GameId), nameof(Game.GameName), vm.Score.PlayerInGame.GameId);
            //vm.TrackSelectList = new SelectList(_uow.Tracks.All, nameof(Track.TrackId), nameof(Track.TrackName), vm.Score.PlayerInGame.Game.TrackId);
            //vm.UserSelectList = new SelectList(_uow.UsersInt.All, nameof(UserInt.Id), nameof(UserInt.Email), vm.Score.PlayerInGame.UserId);
            return View(vm);
        }

        // GET: Admin/Scores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = _uow.Scores.GetById(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // POST: Admin/Scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Score score = _uow.Scores.GetById(id);
           _uow.Scores.Delete(score);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}
