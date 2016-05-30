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
    public class BasketsController : BaseController
    {
        private IUOW _uow;
        //private DataBaseContext db = new DataBaseContext();

        public BasketsController(IUOW uow)
        {
            _uow = uow;
        }
        // GET: Admin/Baskets
        public ActionResult Index()
        {
            var vm = new BasketsIndexViewModels();
            vm.Baskets = _uow.Baskets.All;
            return View(vm);

        }

        // GET: Admin/Baskets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new BasketsViewModel();
            vm.Basket = _uow.Baskets.GetById(id);
            
            if (vm.Basket == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // GET: Admin/Baskets/Create
        public ActionResult Create()
        {
            var vm = new BasketsViewModel();
            vm.TrackSelectList = new SelectList(_uow.Tracks.All, nameof(Track.TrackId), nameof(Track.TrackName));
          
            return View(vm);
        }   

        // POST: Admin/Baskets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BasketsViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Baskets.Add(vm.Basket);
                _uow.Commit();  
                return RedirectToAction(nameof(Index));
            }
            vm.TrackSelectList = new SelectList(_uow.Tracks.All, nameof(Track.TrackId), nameof(Track.TrackName), vm.Basket.TrackId);
            return View(vm);
        }

        // GET: Admin/Baskets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new BasketsViewModel();
            vm.Basket = _uow.Baskets.GetById(id);
          
            if (vm.Basket == null)
            {
                return HttpNotFound();
            }
            vm.TrackSelectList = new SelectList(_uow.Tracks.All, nameof(Track.TrackId), nameof(Track.TrackName));
            return View(vm);
        }

        // POST: Admin/Baskets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BasketsViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.Baskets.Update(vm.Basket);
              _uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            vm.TrackSelectList = new SelectList(_uow.Tracks.All, nameof(Track.TrackId), nameof(Track.TrackName), vm.Basket.TrackId);
            return View(vm);
        }

        // GET: Admin/Baskets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = new BasketsViewModel();
            vm.Basket = _uow.Baskets.GetById(id);

            if (vm.Basket == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: Admin/Baskets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var vm = new BasketsViewModel();
            vm.Basket = _uow.Baskets.GetById(id);
            _uow.Tracks.Delete(vm.Basket);     
            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing)
        {
          
        }
    }
}
