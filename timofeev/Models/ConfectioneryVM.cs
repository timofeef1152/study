using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace timofeev.Models
{
    public class ConfectioneryVM
    {
        public ConfectioneryVM() { }
        public ConfectioneryVM(IEnumerable<ConfectioneryCategory> categories, Confectionery confectionery = null)
        {
            Confectionery = confectionery ?? new Confectionery();
            ConfectioneryCategories = new SelectList(categories, "Id", "CategoryName", Confectionery.ConfectioneryCategory?.Id);
        }

        [Display(Name = "Кондитерское изделие")]
        public Confectionery Confectionery { get; set; }

        [Display(Name = "Категория")]
        public IEnumerable<SelectListItem> ConfectioneryCategories { get; set; }
    }
}