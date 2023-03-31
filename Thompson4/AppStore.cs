/********************************************************************
*** NAME : Kyle Thompson                                          ***
*** CLASS : CSc 346                                               ***
*** ASSIGNMENT : Assignment #4                                    ***
*** DUE DATE : 4-03-23                                               ***
*** INSTRUCTOR : GAMRADT                                          ***
*********************************************************************
*** DESCRIPTION : Using VS Code create a user-defnined Abstract   ***
***               Data Type using C# classes named App, AppStore, ***
***               Apple, and google. This the AppStore class that ***
***               is abstract. AppStore class describes the       ***
***               abstract generalized AppStore.                  ***
********************************************************************/
namespace AppStoreNS
{
    public abstract class AppStore 
    {
        //properties
        protected List<App> Apps { get; set; }
        protected int Selected { get; set; }
        protected int Paid { get; set; }

        /*********************************************************************
        *** METHOD: public AppStore(....)                                  ***
        **********************************************************************
        *** DESCRIPTION : This is the default/overloaded/parameterized     ***
        ***               constructor. If no attributes are set when       ***
        ***               creating an App the default of name is "",       ***
        ***               price to 0 and available to 0, otherwise set to  ***
        ***               what is specified.                               ***
        *** INPUT ARGS : List<App>? apps = null, int selected = 0,         ***
        ***              int paid = 0                                      ***
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : returns a new instance of AppStore object             ***
        *********************************************************************/
        public AppStore(List<App>? apps = null, int selected = 0, int paid = 0)
        {
            Apps = apps ?? new List<App>();
            Selected = selected;
            Paid = paid;
        }

        /*********************************************************************
        *** METHOD: private AppStore(AppStore copy)                        ***
        **********************************************************************
        *** DESCRIPTION : This is the copy constructor which copies        ***
        ***               all attributes from one AppStore object instance ***
        ***               to another AppStore object instance              ***
        *** INPUT ARGS : AppStore copy                                     ***                                    
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : n/a                                                   ***
        *********************************************************************/
        private AppStore(AppStore copy)
        {
            Apps = copy.Apps;
            Selected = copy.Selected;
            Paid = copy.Paid;
        }


        /*********************************************************************
        *** METHOD: public void PurchaseApp()                              ***
        **********************************************************************
        *** DESCRIPTION : PurchaseApp manages the overall flow of each     ***
        ***               AppStore and is repeated until shutdown by the   ***
        ***               driver program.                                  ***
        *** INPUT ARGS : n/a                                               *** 
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : n/a                                                   ***
        *********************************************************************/
        public void PurchaseApp()
        {
            WelcomeToStore();
            SelectApp();
            PayForApp();
            ReturnChange();
            DownloadApp();
        }

        /*********************************************************************
        *** METHOD: protected abstract void WelcomeToStore()               ***
        **********************************************************************
        *** DESCRIPTION : This function is to display a message to the user***
        ***               based off of the AppStore selected. It will      ***
        ***               utilize an override in the Apple.cs and Google.cs***
        ***               files.                                           ***
        *** INPUT ARGS : n/a                                               *** 
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : n/a                                                   ***
        *********************************************************************/
        protected abstract void WelcomeToStore();

        /*********************************************************************
        *** METHOD: protected void SelectApp()                             ***
        **********************************************************************
        *** DESCRIPTION : SelectApp will display another menu listing off  ***
        ***               all of the apps in the selected store if there   ***
        ***               are any. Only allowing the user to go through    ***
        ***               with purchases if the app is in stock. As well,  ***
        ***               decrementing the amount available after a purchase**
        *** INPUT ARGS : n/a                                               *** 
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : n/a                                                   ***
        *********************************************************************/
        protected void SelectApp()
        {
            
            //to check if there are any apps in the selected store
            if(Apps.Count == 0)
            {
                if (this is Apple)
                {
                    Console.WriteLine($"There are no apps in the Apple AppStore!");
                } 
                else if (this is Google) 
                {
                    Console.WriteLine($"There are no apps in the Google AppStore");
                }
            }
            else
            {
                Console.WriteLine("Select an App:");
                for (int i = 0; i < Apps.Count; ++i)
                {
                    if (Apps[i].Available >= 0)
                    {
                        Console.WriteLine($"{i + 1}. {Apps[i].Name} (${Apps[i].Price}), {Apps[i].Available}");
                    }
                }

                int choice;
                bool validInput;

                do
                {
                    Console.Write("Enter the number of the App you want to purchase: ");
                    validInput = int.TryParse(Console.ReadLine(), out choice);
                    choice -= 1;

                    if (choice < 0 || choice >= Apps.Count)
                    {
                        Console.WriteLine($"Invalid App number. Please select a number between 1 and {Apps.Count}.");
                    }
                    else if (Apps[choice].Available <= 0)
                    {
                        Console.WriteLine($"{Apps[choice].Name} is sold out. Please select another App!");
                    }
                } while (!validInput || choice < 0 || choice >= Apps.Count || Apps[choice].Available <= 0);
            
                Selected = choice;
                Apps[choice].Available--;
            }
        }


        /*********************************************************************
        *** METHOD: protected virtual void PayForApp()                     ***
        **********************************************************************
        *** DESCRIPTION : PayForApp will prompt the user to enter the      ***
        ***               amount of each bill. It is virtual void as Google***
        ***               will override PayForApp() accepting different    ***
        ***               types of bills. In both scenarios it will always ***
        ***               prompt for all payment values.                   ***
        *** INPUT ARGS : n/a                                               *** 
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : n/a                                                   ***
        *********************************************************************/
        protected virtual void PayForApp()
        {
            int totalPayment = 0;
            int[] payments = { 20, 10 };

            do
            {
                Console.WriteLine("Accepted payment values: $20, $10");
                totalPayment = 0;

                for (int i = 0; i < payments.Length; ++i)
                {
                    int quantity;
                    bool validInput;

                    do
                    {
                        Console.Write($"Enter the quantity of ${payments[i]} bills:");
                        validInput = int.TryParse(Console.ReadLine(), out quantity);
                    } while (!validInput);

                    totalPayment += payments[i] * quantity;
                }

                    if (totalPayment < Apps[Selected].Price)
                    {
                        Console.WriteLine("|-----------------------------------------|");
                        Console.WriteLine("| Insufficient payment. Please try again. |");
                        Console.WriteLine("|-----------------------------------------|");
                    }
            }while (totalPayment < Apps[Selected].Price);

            Paid = totalPayment;
        }


        /*********************************************************************
        *** METHOD: protected virtual void ReturnChange()                  ***
        **********************************************************************
        *** DESCRIPTION : ReturnChgange is virtual in AppStore as Apple    ***
        ***               will override this method and create it's own    ***
        ***               It will dispaly the quantity of each change value***
        ***               It will always display even if 0 in change.      ***
        *** INPUT ARGS : n/a                                               *** 
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : n/a                                                   ***
        *********************************************************************/
        protected virtual void ReturnChange()
        {
            if (Apps.Count == 0)
            {

            } else
            {
                int change = Paid - Apps[Selected].Price; 
                int[] changeValues = { 10, 1 };
                int[] changeQuantities = new int[changeValues.Length];

                for (int i = 0; i < changeValues.Length; ++i)
                {
                    changeQuantities[i] = change / changeValues[i];
                    change %= changeValues[i];
                }

                Console.WriteLine("Change returned:");

                for (int i = 0; i < changeValues.Length; ++i)
                {
                Console.WriteLine($"({changeQuantities[i]})${changeValues[i]}");
                }
            }
        }

        /*********************************************************************
        *** METHOD: protected void DownloadApp()                           ***
        **********************************************************************
        *** DESCRIPTION : DownloadApp will tell the customer that their    ***
        ***               app was succesfully downloaded, and say          ***
        ***               which specific store was used.                   ***
        *** INPUT ARGS : n/a                                               *** 
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : n/a                                                   ***
        *********************************************************************/
        protected void DownloadApp()
        {
            if (Apps.Count == 0) 
            {

            } 
            else
            {
                Console.WriteLine($"Downloading {Apps[Selected].Name}...");

                if (this is Apple)
                {
                    Console.WriteLine($"Thank you for using the Apple AppStore!");
                } 
                else if (this is Google) 
                {
                    Console.WriteLine($"Thank you for using the Google AppStore!");
                }
                else
                {
                    Console.WriteLine($"Thank you for using our AppStore!");
                }
            }
        }

    }
}

            
        