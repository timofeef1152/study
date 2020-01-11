using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace timofeev.Models
{
    public class OrderVM
    {
        public OrderVM() { }
        public OrderVM(IEnumerable<Client> clients, IEnumerable<Employee> employees, IEnumerable<OrderTheme> themes, Order order = null)
        {
            Order = order ?? new Order();
            Clients = new SelectList(clients, "Id", "Info", Order.Client?.Id);
            Employees = new SelectList(employees, "Id", "Info", Order.Employee?.Id);
            OrderThemes = new SelectList(themes, "Id", "Description", Order.OrderTheme?.Id);
        }

        [Display(Name = "Заказ")]
        public Order Order { get; set; }

        [Display(Name = "Клиент")]
        public IEnumerable<SelectListItem> Clients { get; set; }
        [Display(Name = "Сотрудник")]
        public IEnumerable<SelectListItem> Employees { get; set; }
        [Display(Name = "Тема заказа")]
        public IEnumerable<SelectListItem> OrderThemes { get; set; }
    }
}