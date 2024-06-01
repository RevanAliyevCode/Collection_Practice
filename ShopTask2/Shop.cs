using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomListTask
{
    public class Shop
    {
        public List<Coffee> coffeeList { get; } = [];
        public List<Tea> teaList { get; } = [];
        public decimal TotalIncome { get; set; } = 0;

        public void AddCoffee(Coffee coffee)
        {
            Coffee? finded = coffeeList.FirstOrDefault(x => x.Name.ToLower() == coffee.Name.ToLower());
            if (finded == null)
            {
                coffeeList.Add(coffee);
            }
            else Console.WriteLine("This Product alreaady exist");
        }

        public void RemoveCoffe(string name, int count)
        {
            Coffee? coffee = coffeeList.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

            if (coffee is not null)
            {
                if (count <= coffee.Count)
                {

                    if (coffee.Count - count == 0)
                        coffeeList.Remove(coffee);
                    else
                        coffee.RemoveCoffe(count);

                        TotalIncome += count * coffee.Price;
                }
                else Console.WriteLine($"You can not get more {coffee.Count}");
            }
            else Console.WriteLine("We do not have a product like that");
        }

        public void AddTea(Tea tea)
        {
            Tea? finded = teaList.FirstOrDefault(x => x.Name.ToLower() == tea.Name.ToLower());
            if (finded == null)
            {
                teaList.Add(tea);
            }
            else Console.WriteLine("This product already exist");
        }

        public void RemoveTea(string name, int count)
        {
            Tea? tea = teaList.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

            if (tea is not null)
            {
                if (count <= tea.Count)
                {
                    if (tea.Count - count == 0)
                        teaList.Remove(tea);
                    else
                        tea.RemoveTea(count);

                    TotalIncome += tea.Count * tea.Price;

                }
                else Console.WriteLine($"You can not get more {tea.Count}");
            }
            else Console.WriteLine("We do not have a product like that");
        }

        public void ProductsInfo()
        {
            Console.WriteLine("Teas: ");
            foreach (var tea in teaList)
            {
                Console.Write("\t");
                tea.GetDeatils();
            }
            Console.WriteLine("Coffees: ");
            foreach (var coffee in coffeeList)
            {
                Console.Write("\t");
                coffee.GetDeatils();
            }
        }
    }
}
