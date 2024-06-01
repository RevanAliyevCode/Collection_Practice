using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListTask
{
    public class Tea
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }

        public Tea(string name, int count, decimal price)
        {
            Name = name;
            Count = count;
            Price = price;
        }

        public void RemoveTea(int count) => Count -= count;

        public void GetDeatils() => Console.WriteLine($"Name: {Name}, Count: {Count}, Price: {Price}");

    }
}
