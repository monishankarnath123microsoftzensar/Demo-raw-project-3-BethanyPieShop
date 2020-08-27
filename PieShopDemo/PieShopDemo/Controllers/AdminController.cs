using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PieShopDemo.Models;
using PieShopDemo.ViewModel;
using System.Data.Entity;
using System.Net;

namespace PieShopDemo.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Admin
        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var pie = _context.Pies.Include(c => c.PieCategory).ToList();
            return View(pie);
        }
        public ActionResult IndexCategory()
        {
            var pie = _context.PieCategories.ToList();
            return View(pie);
        }
        public ActionResult AddPie()
        {
            var addPie = _context.PieCategories.ToList();
            var viewModel = new NewPieViewModel
            {
                PieCategories = addPie
            };
            return View(viewModel);
        }
        //[HttpPost]
        //public ActionResult Create(Pies pies)
        //{
        //    _context.Pies.Add(pies);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Admin");
        //}
        [HttpPost]
        public ActionResult SavePie(Pies pies)
        {
            if (pies.Id == 0)
            {
                _context.Pies.Add(pies);
            }
            else
            {
                var pieInDb = _context.Pies.Single(c => c.Id == pies.Id);
                pieInDb.Name = pies.Name;
                pieInDb.SDescription = pies.SDescription;
                pieInDb.LDescription = pies.LDescription;
                pieInDb.Price = pies.Price;
                pieInDb.IsPieOfTheWeek = pies.IsPieOfTheWeek;
                pieInDb.InStock = pies.InStock;
                pieInDb.PieCategoryId = pies.PieCategoryId;
                pieInDb.Image = pies.Image;
                pieInDb.ImageThumb = pies.ImageThumb;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult AddPieCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveCategory(PieCategory pieCategory)
        {
            if (pieCategory.Id == 0)
            {
                _context.PieCategories.Add(pieCategory);
            }
            else
            {
                var catInDb = _context.PieCategories.Single(c => c.Id == pieCategory.Id);
                catInDb.CName = pieCategory.CName;
                catInDb.Description = pieCategory.Description;
            }
            _context.SaveChanges();
            return RedirectToAction("IndexCategory", "Admin");
        }
        //[HttpPost]
        //public ActionResult CreateCategory(PieCategory pieCategory)
        //{
        //    _context.PieCategories.Add(pieCategory);
        //    _context.SaveChanges();
        //    return RedirectToAction("IndexCategory", "Admin");
        //}
        public ActionResult EditPie(int id)
        {
            var updatePie = _context.Pies.SingleOrDefault(c => c.Id == id);
            if (updatePie == null)
            {
                return HttpNotFound();
            }
            var vm = new NewPieViewModel
            {
                Pies = updatePie,
                PieCategories = _context.PieCategories.ToList()
            };
            return View("AddPie", vm);
        }
        public ActionResult EditCategory(int id)
        {
            var updateCat = _context.PieCategories.Find(id);
            if (updateCat == null)
            {
                return HttpNotFound();
            }
            return View("AddPieCategory", updateCat);
        }
        public ActionResult DeletePie(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pieTbl = _context.Pies.Find(id);
            _context.Pies.Remove(pieTbl);
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categoryTbl = _context.PieCategories.Find(id);
            _context.PieCategories.Remove(categoryTbl);
            _context.SaveChanges();
            return RedirectToAction("IndexCategory", "Admin");
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


    }
}