using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace timofeev.Models
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

        public string EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public string OrderThemeId { get; set; }
        public virtual OrderTheme OrderTheme { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        [NotMapped]
        [Display(Name = "Заказ")]
        public string Info => $"{Client.Info}/{Employee.Info}/{OrderTheme.Description}";
    }
}