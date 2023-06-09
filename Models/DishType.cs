using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restourant_ORM
{
    public class DishType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        ICollection<Dish> Dishes { get; set; }
    }
}
