/********************************************************************
*** NAME : Kyle Thompson                                          ***
*** CLASS : CSc 346                                               ***
*** ASSIGNMENT : Assignment #4                                    ***
*** DUE DATE : 3-31-23                                            ***
*** INSTRUCTOR : GAMRADT                                          ***
*********************************************************************
*** DESCRIPTION : Using VS Code create a user-defnined Abstract   ***
***               Data Type using C# classes named App, AppStore, ***
***               Apple, and google. App.cs contains a            ***
***               default/overloaded/parameterized constructor    ***
***               setting the defaults for Name to "", Pirce to 0,***
***               and Available to 0. As well a copy constructor  ***
***               to create an exact copy of an existing App      ***
********************************************************************/
namespace AppStoreNS
{

    public class App 
    {
        //properties
        public string Name {get; set;}
        public int Price {get; set;}
        public int Available {get; set;} 


        /*********************************************************************
        *** METHOD: public App(....)                                       ***
        **********************************************************************
        *** DESCRIPTION : This is the default/overloaded/parameterized     ***
        ***               constructor. If no attributes are set when       ***
        ***               creating an App the default of name is "",       ***
        ***               price to 0 and available to 0, otherwise set to  ***
        ***               what is specified.                               ***
        *** INPUT ARGS : string name = "", int price = 0, int available = 0***
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : returns a new instance of App object                  ***
        *********************************************************************/
        public App(string name = "", int price = 0, int available = 0)
        {
            Name = name;
            Price = price;
            Available = available;
        }


         /********************************************************************
        *** METHOD: public App(App copy)                                   ***
        **********************************************************************
        *** DESCRIPTION : This is the copy constructor which copies        ***
        ***               all attributes from one App object instance      ***
        ***               to another App object instance                   ***
        *** INPUT ARGS : App copy                                          ***                                         ***
        *** OUTPUT ARGS : n/a                                              ***
        *** IN/OUT ARGS : n/a                                              ***
        *** RETURN : n/a                                                   ***
        *********************************************************************/
        public App(App copy)
        {
            Name = copy.Name;
            Price = copy.Price;
            Available = copy.Available;

        }
    }

}