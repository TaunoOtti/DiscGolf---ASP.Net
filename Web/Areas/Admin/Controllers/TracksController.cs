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
using Web.Areas.Admin.ViewModels;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TracksController : BaseController
    {
        //private DataBaseContext db = new DataBaseContext();
        private readonly IUOW _uow;

        public TracksController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Admin/Tracks
        public ActionResult Index()
        {
            var vm = new TracksIndexViewModel();
            vm.Tracks = _uow.Tracks.All;
            return View(vm);
        }

        // GET: Admin/Tracks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new TracksViewModel();
            vm.Track = _uow.Tracks.GetById(id);
            
            if (vm.Track == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // GET: Admin/Tracks/Create
        public ActionResult Create()
        {
            var vm = new TracksViewModel();
            return View(vm);
        }

        // POST: Admin/Tracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TracksViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Tracks.Add(vm.Track);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Admin/Tracks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new TracksViewModel();
            vm.Track = _uow.Tracks.GetById(id);
            
            if (vm.Track == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: Admin/Tracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TracksViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Tracks.Update(vm.Track);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Admin/Tracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new TracksViewModel();
            vm.Track = _uow.Tracks.GetById(id);
            if (vm.Track == null)
            {
                return HttpNotFound();
            }
            return View(vm);   
        }

        // POST: Admin/Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Track track = _uow.Tracks.GetById(id);
            _uow.Tracks.Delete(track);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
         
        }
    }
}
