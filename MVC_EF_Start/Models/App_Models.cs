using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_EF_Start.Models
{
    
    public class Orders
    {
        [Key]
        public string OrderID { get; set; }
        public string CustomerName { get; set; }
        public string OrderCategory { get; set; }
        public string MealID { get; set; }
        public string Quantity { get; set; }
        public string Messege { get; set; }

    }

    public class Menu
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
  
    }

}
