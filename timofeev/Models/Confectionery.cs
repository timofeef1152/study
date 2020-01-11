using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace timofeev.Models
{
    public class Confectionery
    {
        public Confectionery()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Display(Name="Название")]
        public string Name { get; set; }
        [Display(Name="Состав")]
        public string Composition { get; set; }
        [Display(Name="Цена")]
        public float Price { get; set; }
        [Display(Name="Вес")]
        public float Weight { get; set; }

        public string ConfectioneryCategoryId { get; set; }
        public virtual ConfectioneryCategory ConfectioneryCategory { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        [NotMapped]
        [Display(Name = "Кондитерское изделие")]
        public string Info => $"{Name}/{Weight}/{Price}";
    }
}