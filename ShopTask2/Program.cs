// See https://aka.ms/new-console-template for more information

using CustomListTask;

bool stop = false;

Shop shop = new();
do
{
    Console.WriteLine("1 for add product:\n2 for buy product:");
    int choise = int.Parse(Console.ReadLine());

    if (choise == 1)
    {
        Console.Write("Write Name: ");
        string name = Console.ReadLine();

        Console.Write("Write Price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.Write("Write count: ");
        int count = int.Parse(Console.ReadLine());

        Console.Write("Write type (1-Coffee or 2-Tea): ");
        DrinkType type = (DrinkType)int.Parse(Console.ReadLine());

        switch (type)
        {
            case DrinkType.Coffee:
                Coffee coffee = new Coffee(name, count, price);
                shop.AddCoffee(coffee);
                break;
            case DrinkType.Tea:
                Tea tea = new Tea(name, count, price);
                shop.AddTea(tea);
                break;
            default:
                Console.WriteLine("Please enter 1 for Coffee 2 for Tea");
                break;
        }

        Console.WriteLine("Added Successfully");
        Console.Write("Do you want cotinue (y/n): ");
        string something = Console.ReadLine();
        stop = something == "y" ? false : true;
    }
    else if (choise == 2)
    {
        shop.ProductsInfo();

        Console.Write("What you want to buy 1-Coffee or 2-Tea: ");
        DrinkType type = (DrinkType)int.Parse(Console.ReadLine());

        Console.Write("Write Name: ");
        string name = Console.ReadLine();

        Console.Write("Write count: ");
        int count = int.Parse(Console.ReadLine());

        switch (type)
        {
            case DrinkType.Coffee:
                shop.RemoveCoffe(name, count);
                break;
            case DrinkType.Tea:
                shop.RemoveTea(name, count);
                break;
            default:
                Console.WriteLine("Please enter 1 for Coffee 2 for Tea");
                break;
        }

        Console.Write("Do you want cotinue (y/n): ");
        string something = Console.ReadLine();
        stop = something == "y" ? false : true;
    }
    else Console.WriteLine("Please enter 1 for adding product and 2 for buy");
} while (!stop);

Console.WriteLine(shop.TotalIncome);