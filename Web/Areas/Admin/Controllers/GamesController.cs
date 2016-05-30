using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DAL;
using DAL.Interfaces;
using Domain;
using Web.Helpers;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GamesController : BaseController
    {
        private readonly IUOW _uow ;
        //private DataBaseContext db = new DataBaseContext();

        public GamesController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Admin/Games
        public ActionResult Index()
        {
            var vm = new GamesIndexViewModel();
            vm.Games = _uow.Games.AllIncluding(); 
            //var games = db.Games.Include(g => g.Track);
            return View(vm);
        }

        // GET: Admin/Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new GamesViewModel();
            vm.Game = _uow.Games.GetById(id);
           // Game game = db.Games.Find(id);
            if (vm.Game == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // GET: Admin/Games/Create
        public ActionResult Create()
        {
            var vm = new GamesViewModel();
            vm.TrackSelectList = new SelectList(_uow.Tracks.All, nameof(Track.TrackId), nameof(Track.TrackName));

            //ViewBag.TrackId = new SelectList(db.Tracks, "TrackId", "TrackName");
            return View(vm);
        }

        // POST: Admin/Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GamesViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Games.Add(vm.Game);
                _uow.Commit();
                //db.Games.Add(game);
                //db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            vm.TrackSelectList = new SelectList(_uow.Tracks.AllIncluding(), nameof(Track.TrackId), nameof(Track.TrackName), vm.Game.TrackId);
            
            //ViewBag.TrackId = new SelectList(db.Tracks, "TrackId", "TrackName", game.TrackId);
            return View(vm);
        }

        // GET: Admin/Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new GamesViewModel();
            vm.Game = _uow.Games.GetById(id);
           // Game game = db.Games.Find(id);
            if (vm.Game == null)
            {
                return HttpNotFound();
            }
            vm.TrackSelectList = new SelectList(_uow.Tracks.All, nameof(Track.TrackId), nameof(Track.TrackName)/*, vm.Game.TrackId*/);
           // ViewBag.TrackId = new SelectList(db.Tracks, "TrackId", "TrackName", game.TrackId);
            return View(vm);
        }

        // POST: Admin/Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GamesViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Games.Update(vm.Game);
                _uow.Commit();
                //db.Entry(game).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.TrackSelectList = new SelectList(_uow.Tracks.All, nameof(Track.TrackId), nameof(Track.TrackName), vm.Game.TrackId);
            return View(vm);
        }

        // GET: Admin/Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new GamesViewModel();
            vm.Game = _uow.Games.GetById(id);
            if (vm.Game == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: Admin/Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(GamesViewModel vm)
        {
            vm.Game = _uow.Games.GetById(vm.Game.GameId);
            _uow.Games.Delete(vm.Game.GameId);
            _uow.Commit();
            //db.Games.Remove(game);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
         
        }
    }
}
