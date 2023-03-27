
namespace AppStoreNS
{

    public class App 
    {

        public string Name {get; set;} = "";
        public int Price {get; set;} = 0;
        public int Available {get; set;} = 0;

        public App(string name, int price, int available)
        {
            Name = name;
            Price = price;
            Available = available;
        }

        public App(App app)
        {
            Name = app.Name;
            Price = app.Price;
            Available = app.Available;

        }
    }

}