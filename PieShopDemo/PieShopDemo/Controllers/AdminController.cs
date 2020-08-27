using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PieShopDemo.Models;
using PieShopDemo.ViewModel;
using System.Data.Entity;

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
        public ActionResult AddPie()
        {
            var addPie = _context.PieCategories.ToList();
            var viewModel = new NewPieViewModel
            {
                PieCategories = addPie
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Pies pies)
        {
            _context.Pies.Add(pies);
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

    }
}