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
using Web.Areas.Admin.ViewModels;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    public class PlayerInGamesController : BaseController
    {
       // private DataBaseContext db = new DataBaseContext();
        private readonly IUOW _uow;

        public PlayerInGamesController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Admin/PlayerInGames
        public ActionResult Index()
        {
            //var playerInGames = _uow.PlayerInGames.AllIncluding(p => p.Game, x => x.User).ToList();
            var vm = new PlayerInGameIndexViewModel();

            vm.PlayerInGames = _uow.PlayerInGames.AllIncluding();
            

            //var playerInGames = db.PlayerInGames.Include(p => p.Game).Include(p => p.User);
            return View(vm);
        }

        // GET: Admin/PlayerInGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerInGame playerInGame = _uow.PlayerInGames.GetById(id);
            if (playerInGame == null)
            {
                return HttpNotFound();
            }
            return View(playerInGame);
        }

        // GET: Admin/PlayerInGames/Create
        public ActionResult Create()
        {
            var vm = new PlayerInGamesViewModel();

            vm.GameSelectList = new SelectList(_uow.Games.All, nameof(Game.GameId), nameof(Game.GameName));
            vm.UserSelectList = new SelectList(_uow.UsersInt.All, nameof(UserInt.Id), nameof(UserInt.Email));
            //ViewBag.GameId = new SelectList(db.Games, "GameId", "GameName");
            //ViewBag.UserId = new SelectList(_uow.UsersInt.All, "Id", "Email");
            return View(vm);
        }

        // POST: Admin/PlayerInGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayerInGamesViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.PlayerInGames.Add(vm.PlayerInGame);
                _uow.Commit();
                //db.PlayerInGames.Add(playerInGame);
                //db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }

            vm.UserSelectList = new SelectList(_uow.UsersInt.All, nameof(UserInt.Id), nameof(UserInt.Email), vm.PlayerInGame.UserId);
            vm.GameSelectList = new SelectList(_uow.Games.All, nameof(Game.GameId), nameof(Game.GameName), vm.PlayerInGame.GameId);

            //ViewBag.GameId = new SelectList(db.Games, "GameId", "GameName", playerInGame.GameId);
            //ViewBag.UserId = new SelectList(_uow.UsersInt.All, "Id", "Email", playerInGame.UserId);
            return View(vm);
        }

        // GET: Admin/PlayerInGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new PlayerInGamesViewModel();
            vm.PlayerInGame = _uow.PlayerInGames.GetById(id);
           // PlayerInGame playerInGame = db.PlayerInGames.Find(id);
            if (vm.PlayerInGame == null)
            {
                return HttpNotFound();
            }

            vm.UserSelectList = new SelectList(_uow.UsersInt.All, nameof(UserInt.Id), nameof(UserInt.Email));
            vm.GameSelectList = new SelectList(_uow.Games.All, nameof(Game.GameId), nameof(Game.GameName));

            //ViewBag.GameId = new SelectList(db.Games, "GameId", "GameName", playerInGame.GameId);
            //ViewBag.UserId = new SelectList(_uow.UsersInt.All, "Id", "Email", playerInGame.UserId);
            return View(vm);
        }

        // POST: Admin/PlayerInGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlayerInGamesViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.PlayerInGames.Update(vm.PlayerInGame);
                _uow.Commit();
                //db.Entry(playerInGame).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            vm.UserSelectList = new SelectList(_uow.UsersInt.All, nameof(UserInt.Id), nameof(UserInt.Email), vm.PlayerInGame.UserId);
            vm.GameSelectList = new SelectList(_uow.Games.All, nameof(Game.GameId), nameof(Game.GameName), vm.PlayerInGame.GameId);

            return View(vm);
        }

        // GET: Admin/PlayerInGames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new PlayerInGamesViewModel();
            vm.PlayerInGame = _uow.PlayerInGames.GetById(id);
            //PlayerInGame playerInGame = db.PlayerInGames.Find(id);
            if (vm.PlayerInGame == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: Admin/PlayerInGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(PlayerInGamesViewModel vm)
        {

           // PlayerInGame playerInGame = _uow.PlayerInGames.GetById(id);
          // _uow.Games.Delete(playerInGame);
            _uow.PlayerInGames.Delete(vm.PlayerInGame.PlayerInGameId);
           _uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing)
        {
           
        }
    }
}
