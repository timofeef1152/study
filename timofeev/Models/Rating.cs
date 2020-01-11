using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace timofeev.Models
{
    public class Rating
    {
        public Rating()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Display(Name="Рейтинг")]
        public int RatingLevel { get; set; }
        [Display(Name="Бонус ($)")]
        public float BonusPercent { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}