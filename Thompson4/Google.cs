/********************************************************************
*** NAME : Kyle Thompson                                          ***
*** CLASS : CSc 346                                               ***
*** ASSIGNMENT : Assignment #4                                    ***
*** DUE DATE : 4-03-23                                               ***
*** INSTRUCTOR : GAMRADT                                          ***
*********************************************************************
*** DESCRIPTION : Using VS Code, create a user-defined Abstract   ***
***               Data Type using C# classes named App, AppStore, ***
***               Apple, and Google. This is the Google class that***
***               describes the current state of a specialized    ***
***               AppStore class instance.                        ***
********************************************************************/

namespace AppStoreNS
{
    public class Google : AppStore
    {
        /*********************************************************************
        *** METHOD: public Google(...) : base(...)                         ***
        **********************************************************************
        *** DESCRIPTION : This is the default/overloaded/parameterized     ***
        ***               constructor. It initializes the Apps property of ***
        ***               the Google class by calling the base constructor ***
        ***               from the AppStore class.                         ***
        *** INPUT ARGS : List<App>? apps = null                            ***
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : returns a new instance of the Google object           ***
        *********************************************************************/
        public Google(List<App>? apps = null) : base(apps)
        {
            Apps = apps?? new List<App>();
        }
        
        /*********************************************************************
        *** METHOD: private Google(...) : base(...)                        ***
        **********************************************************************
        *** DESCRIPTION : This is the copy constructor which copies        ***
        ***               all attributes from one Google object instance   ***
        ***               to another Google object instance                ***
        *** INPUT ARGS : Google copy                                       ***
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : n/a                                                   ***
        *********************************************************************/
        private Google(Google copy) : base(copy.Apps)
        {
            Apps = copy.Apps;
        }
    
        /*********************************************************************
        *** METHOD: protected override void WelcomeToStore()               ***
        **********************************************************************
        *** DESCRIPTION : Displays a welcome message specific to the Google***
        ***               AppStore.                                        ***
        *** INPUT ARGS : n/a                                               ***
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : n/a                                                   ***
        *********************************************************************/
        protected override void WelcomeToStore()
        {
            Console.WriteLine("Welcome to the Google AppStore!");
            Console.WriteLine("-------------------------------");
        }


        /*********************************************************************
        *** METHOD: protected override void ReturnChange()                  ***
        **********************************************************************
        *** DESCRIPTION : Calculates and displays the change to return      ***
        ***               to the user after they have paid for an app.     ***
        *** INPUT ARGS : n/a                                               ***
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : n/a                                                   ***
        *********************************************************************/
        protected override void ReturnChange()
        {
            int change = Paid - Apps[Selected].Price;
            int[] demoninations = { 5, 2, 1 };
            int[] changeQuantities = new int[demoninations.Length];

            for (int i = 0; i < demoninations.Length; i++)
            {
                changeQuantities[i] = change / demoninations[i];
                change %= demoninations[i];
            }

            Console.WriteLine("Change returned:");
            for (int i = 0; i < demoninations.Length; i++)
            {
                Console.WriteLine($"({changeQuantities[i]})${demoninations[i]}");
            }
        }
    }
}

