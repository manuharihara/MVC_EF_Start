using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Models {
    public class Person
    {

        public int ID { get; set; }
        //[Required]
        //[Display(Name = "Name")]
        public string FirstName { get; set; }
       //[Required]
        //[Display(Name = "Name-2")]
        public string SecondName { get; set; }
        //[Required]
        //[Display(Name = "E-mail")]
        //[RegularExpression(".+\\@.+\\..+",ErrorMessage = "Please enter e-mail in correct format")]
        public string Email { get; set; }
        //[Required]
       // [Display(Name = "Password")]
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }

        private class RequiredAttribute : Attribute
        {
        }
    }
}
