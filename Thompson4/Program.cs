/********************************************************************
*** NAME : Kyle Thompson                                          ***
*** CLASS : CSc 346                                               ***
*** ASSIGNMENT : Assignment #4                                    ***
*** DUE DATE : 3-31-23                                            ***
*** INSTRUCTOR : GAMRADT                                          ***
*********************************************************************
*** DESCRIPTION : Using VS Code create a user-defnined Abstract   ***
***               Data Type using C# classes named App, AppStore, ***
***               Apple, and google. This is the driver program   ***
***               that will display a menu to the user to slect an***
***               Appstore. Not exiting the program until the user***
***               selects exit. Only one AppStore selected per time***
********************************************************************/
namespace AppStoreNS
{
    class Program
    {
        /********************************************************************
        *** METHOD: static void Main(string[] args)                       ***
        *********************************************************************
        *** DESCRIPTION : This method will be the starting point at which ***
        ***               the code inside is executed when ran. In this   ***
        ***               method it will create the list using the default***
        ***               constructor in App.cs. Allowing for each appstore***
        ***               to manage their apps.                           ***
        *** INPUT ARGS : n/a                                              ***
        *** OUTPUT ARGS : n/a                                             ***
        *** IN/OUT ARGS : n/a                                             ***
        *** RETURN : void - no value                                      ***
        ********************************************************************/
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
                Console.WriteLine("Select an AppStore:");
                Console.WriteLine("1. Apple");
                Console.WriteLine("2. Google");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");


                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            appleStore.PurchaseApp();
                            break;
                        case 2:
                            googleStore.PurchaseApp();
                            break;
                        case 3:
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
                Console.WriteLine("Thank you for using the AppStore! Have a great day!");
                Console.WriteLine();
            } while (!exit);
            
        }
    }
}

