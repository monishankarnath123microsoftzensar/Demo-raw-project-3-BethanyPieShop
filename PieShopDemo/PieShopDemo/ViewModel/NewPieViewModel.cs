using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PieShopDemo.Models;

namespace PieShopDemo.ViewModel
{
    public class NewPieViewModel
    {
        public IEnumerable<PieCategory> PieCategories { get; set; }
        public Pies Pies { get; set; }
    }
}