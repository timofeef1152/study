using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace timofeev.Models
{
    public class OrderDetails
    {
        public OrderDetails() 
        { 
            Id = Guid.NewGuid().ToString(); 
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Display(Name="Количество")]
        public int Quantity { get; set; }
        [Display(Name="Сумма")]
        public decimal TotalAmount { get; set; }

        public string ConfectioneryId { get; set; }
        public virtual Confectionery Confectionery { get; set; }

        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}