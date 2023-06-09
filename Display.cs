using Restourant_ORM.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restourant_ORM
{
     class Display
    {
        private int closeOperationId = 6;
        private DishesContext dishContext = new dishContext();
        public Display()
        {
            Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            dishContext.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Dish dish = dishContext.Get(id);
            if (dish != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + dish.Id);
                Console.WriteLine("Name: " + dish.Name);
                Console.WriteLine("Price: " + dish.Price);
                Console.WriteLine("DishType: " + dish.DishTypeId);
                Console.WriteLine("Quantity: " + dish.Quantity);
                Console.WriteLine(new string('-', 40));
            }
        }
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Dish dish = DishesContext.Get(id);
            if (dish != null)
            {
                Console.WriteLine("Enter name: ");
                dish.Name = Console.ReadLine();
                Console.WriteLine("Enter price: ");
                dish.Price = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter availability: ");
                dish.DishTypeId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Quality: ");
                dish.Quantity = int.Parse(Console.ReadLine());
                dish.Update(dish);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }
        private void Add()
        {
            Dish dish = new Dish();
            Console.WriteLine("Enter name: ");
            dish.Name = Console.ReadLine();
            Console.WriteLine("Enter price: ");
            dish.Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter availability: ");
            dish.DishTypeId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Quantity: ");
            dish.Quantity = int.Parse(Console.ReadLine());
            DishesContext.Add(dish);
        }
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "PRODUCTS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var dishes = DishesContext.GetAll();
            foreach (var item in dishes)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.Id, item.Name, item.Price, item.Stock);
            }
        }
    }

}
