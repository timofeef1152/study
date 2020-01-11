using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace timofeev.Models
{
    public class ConfectioneryCategory
    {
        public ConfectioneryCategory()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Display(Name = "Наименование")]
        public string CategoryName { get; set; }

        public virtual ICollection<Confectionery> Confectioneries { get; set; }
    }
}