using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Restourant_ORM
{
    public class DishesLogic
    {
        private DishesContext dishesContext = new DishesContext();
        public List<Dish>GetAll()
        {
            using (dishesContext = new DishesContext())
            {
                List<Dish> listDishes = dishesContext.Dishes.ToList();
                return listDishes;
            }
        }
        public Dish Get(int id)
        {
            using (dishesContext = new DishesContext())
            {
                Dish findedDish = dishesContext.Dishes.Find(id);
                if (findedDish != null)
                {
                    dishesContext.Entry(findedDish).Reference(x => x.DishType).Load();
                }
                return findedDish;
            }
        }
        public void Create(Dish dish)
        {
            using (dishesContext = new DishesContext())
            {
                dishesContext.Dishes.Add(dish);
                dishesContext.SaveChanges();
            }
        }
        public void Update(int id, Dish dish) 
        {
            using (dishesContext = new DishesContext())
            {
                Dish finded = dishesContext.Dishes.Find(id);
                if(finded == null)
                {
                    return;
                }
            }
        }
        public void Delete(int id)
        {
            using (dishesContext = new DishesContext())
            {
                var dish = dishesContext.Dishes.Find(id);
                if (dish != null)
                {
                    dishesContext.Dishes.Remove(dish);
                    dishesContext.Dishes.SaveChanges();
                }
            }
        }
    }
}
