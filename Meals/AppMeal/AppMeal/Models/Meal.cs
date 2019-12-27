using System;
using System.Collections.Generic;
using System.Text;

namespace AppMeal.Models
{
    public class Meal
    {
        public int FoodID { get; set; }
        public string Food { get; set; }
        public string Drink { get; set; }
        public string Accompaniment { get; set; }
        public string Extra { get; set; }
    }
}
