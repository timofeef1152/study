using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace timofeev.Models
{
    public class EmployeeVM
    {
        public EmployeeVM() { }

        public EmployeeVM(IEnumerable<Person> persons, IEnumerable<Position> positions, IEnumerable<Rating> ratings, Employee employee = null)
        {
            Employee = employee ?? new Employee();
            Persons = new SelectList(persons, "Id", "Fullname", Employee.Person?.Id);
            Positions = new SelectList(positions, "Id", "PositionName", Employee.Position?.Id);
            Ratings = new SelectList(ratings, "Id", "RatingLevel", Employee.Rating?.Id);
        }

        [Display(Name = "Сотрудник")]
        public Employee Employee { get; set; }

        [Display(Name = "Физ. лицо")]
        public IEnumerable<SelectListItem> Persons { get; set; }
        [Display(Name = "Должность")]
        public IEnumerable<SelectListItem> Positions { get; set; }
        [Display(Name = "Рейтинг")]
        public IEnumerable<SelectListItem> Ratings { get; set; }
    }
}