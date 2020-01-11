using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace timofeev.Models
{
    public class Client
    {
        public Client()
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
        [Display(Name="Телефон")]
        public string PhoneNumber { get; set; }
        [Display(Name="Адрес доставки")]
        public string DeliveryAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        [NotMapped]
        [Display(Name = "ФИО")]
        public string Fullname => $"{Firstname} {Name} {Secondname}";

        [NotMapped]
        [Display(Name = "Клиент")]
        public string Info => $"{Fullname}/{PhoneNumber}";
    }
}