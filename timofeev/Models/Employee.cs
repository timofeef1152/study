using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace timofeev.Models
{
    public class Employee
    {
        public Employee()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public string PersonId { get; set; }
        public virtual Person Person { get; set; }

        public string PositionId { get; set; }
        public virtual Position Position { get; set; }

        public string RatingId { get; set; }
        public virtual Rating Rating { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        [NotMapped]
        [Display(Name = "Сотрудник")]
        public string Info => $"{Position.PositionName}/{Person.Fullname}";
    }
}