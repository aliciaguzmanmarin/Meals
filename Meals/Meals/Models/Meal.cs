using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Meals.Models
{
    public class Meal
    {
        [Key]
        public int FoodID { get; set; }
        [Required]
        public string Food { get; set; }
        [Required]
        public string Drink { get; set; }
        [Required]
        public string Accompaniment { get; set; }
        [Required]
        public string Extra { get; set; }
    }
}