using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace timofeev.Models
{
    public class OrderDetailsVM
    {
        public OrderDetailsVM() { }
        public OrderDetailsVM(IEnumerable<Confectionery> confectioneries, IEnumerable<Order> orders, OrderDetails details = null)
        {
            OrderDetails = details ?? new OrderDetails();
            Confectioneries = new SelectList(confectioneries, "Id", "Info", OrderDetails.Confectionery?.Id);
            Orders = new SelectList(orders, "Id", "Info", OrderDetails.Order?.Id);
        }

        [Display(Name = "Детали заказа")]
        public OrderDetails OrderDetails { get; set; }

        [Display(Name = "Кондитерское изделие")]
        public IEnumerable<SelectListItem> Confectioneries { get; set; }
        [Display(Name = "Заказ")]
        public IEnumerable<SelectListItem> Orders { get; set; }
    }
}