using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace timofeev.Models
{
    public class Position
    {
        public Position()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Display(Name="Наименование")]
        public string PositionName { get; set; }
        [Display(Name="Зарплата ($)")]
        public float Salary { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}