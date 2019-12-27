using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Meals.Models
{
    public class DataContext : DbContext

    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Meals.Models.Meal> Meals { get; set; }
    }
}