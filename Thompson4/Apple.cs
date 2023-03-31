/********************************************************************
*** NAME : Kyle Thompson                                          ***
*** CLASS : CSc 346                                               ***
*** ASSIGNMENT : Assignment #4                                    ***
*** DUE DATE : 3-31-23                                            ***
*** INSTRUCTOR : GAMRADT                                          ***
*********************************************************************
*** DESCRIPTION : Using VS Code, create a user-defined Abstract   ***
***               Data Type using C# classes named App, AppStore, ***
***               Apple, and Google. This is the Apple class that ***
***               represents a specialized instance of the        ***
***               AppStore class, tailored specifically for the   ***
***               Apple App Store.                                ***
********************************************************************/

namespace AppStoreNS
{
    public class Apple : AppStore
    {
        /*********************************************************************
        *** METHOD: public Apple(...) : base(...)                          ***
        **********************************************************************
        *** DESCRIPTION : This is the default/overloaded/parameterized     ***
        ***               constructor. It initializes the Apps. It has   ***
        ***               a base class from the AppStore class.            ***
        *** INPUT ARGS : List<App>? apps = null                            ***
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : returns a new instance of Apple object                ***
        *********************************************************************/
        public Apple(List<App>? apps = null) : base(apps)
        {
        }

            

        /*********************************************************************
        *** METHOD: private Apple(Apple copy)                              ***
        **********************************************************************
        *** DESCRIPTION : This is the copy constructor which copies        ***
        ***               all attributes from one Apple object instance    ***
        ***               to another Apple object instance                ***
        *** INPUT ARGS : Apple copy                                        ***
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : n/a                                                   ***
        *********************************************************************/
        private Apple(Apple copy) : base(copy.Apps, copy.Selected, copy.Paid)
        {
        }
    

        /*********************************************************************
        *** METHOD: protected override void WelcomeToStore()               ***
        **********************************************************************
        *** DESCRIPTION : This function displays a welcome message to the  ***
        ***               user specific to the Apple AppStore.             ***
        *** INPUT ARGS : n/a                                               ***
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : n/a                                                   ***
        *********************************************************************/
        protected override void WelcomeToStore()
        {
            
            Console.WriteLine("\nWelcome to the Apple AppStore!");
            Console.WriteLine("------------------------------");
        }

        /*********************************************************************
        *** METHOD: protected override void PayForApp()                    ***
        **********************************************************************
        *** DESCRIPTION : This method prompts the user to enter the        ***
        ***               amount of each bill for payment specific to the  ***
        ***               Apple AppStore. It then calculates the total     ***
        ***               payment and checks if it is sufficient. If not,  ***
        ***               it asks the user to try again.                   ***
        *** INPUT ARGS : n/a                                               ***
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : n/a                                                   ***
        *********************************************************************/
        protected override void PayForApp() 
        {
            
            if (Apps.Count == 0)
            {
                
            } else 
            {
            int totalPayment = 0;
            int[] payments = { 10, 5, 1 };
            

            do{
                Console.WriteLine("Accepted payment values: $10, $5, $1");
                totalPayment = 0;
                
                for (int i = 0; i < payments.Length; ++i)
                {
                    int quantity;
                    bool validInput;

                    do{
                        Console.Write($"Enter the quanity of ${payments[i]} bills: ");
                        validInput = int.TryParse(Console.ReadLine(), out quantity);
                    }while(!validInput);

                    totalPayment += payments[i] * quantity;
                }

                if (totalPayment < Apps[Selected].Price)
                {
                    Console.WriteLine("|-----------------------------------------|");
                    Console.WriteLine("| Insufficient payment. Please try again. |");
                    Console.WriteLine("|-----------------------------------------|");
                }

            }while(totalPayment < Apps[Selected].Price);

            Paid = totalPayment;
            }

        }

    }
}
