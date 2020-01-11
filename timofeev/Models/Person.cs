using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace timofeev.Models
{
    public class Person
    {
        public Person()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Display(Name="Фамилия")]
        public string Firstname { get; set; }
        [Display(Name="Имя")]
        public string Name { get; set; }
        [Display(Name="Отчество")]
        public string Secondname { get; set; }
        [Display(Name="Адрес")]
        public string Address { get; set; }
        [Display(Name="Телефон")]
        public string PhoneNumber { get; set; }
        [Display(Name="Email")]
        public string Email { get; set; }
        [Display(Name="Паспорт")]
        public string PassportInfo { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        [NotMapped]
        [Display(Name = "ФИО")]
        public string Fullname => $"{Firstname} {Name} {Secondname}";
    }
}