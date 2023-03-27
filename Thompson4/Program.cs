using System;
using System.Collections.Generic;

namespace AppStoreNS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<App> appleApps = new List<App>
            {
                new App("Final Cut Pro", 54, 3),
                new App("Logic Pro", 50, 4),
                new App("MainStage", 46, 5),
                new App("Pixelmator Pro", 57, 2)
            };
            Apple appleStore = new Apple(appleApps);

            List<App> googleApps = new List<App>
            {
                new App("Cubasis 3", 46, 3),
                new App("FL Studio Mobile", 50, 5),
                new App("LumaFusion Pro", 57, 1)
                
            };
            Google googleStore = new Google(googleApps);

            bool exit = false;

            do
            {
                Console.WriteLine("Select an app store:");
                Console.WriteLine("1. Apple");
                Console.WriteLine("2. Google");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                


                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine();
                    switch (choice)
                    {
                        case 1:
                            appleStore.PurchaseApp();
                            break;
                        case 2:
                            googleStore.PurchaseApp();
                            break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }

                Console.WriteLine();
            } while (!exit);
        }
    }
}

