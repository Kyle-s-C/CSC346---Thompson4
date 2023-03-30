namespace AppStoreNS
{
    public class Google : AppStore
    {
        public Google(List<App>? apps = null, int selected = -1, int paid = 0) : base(apps, selected, paid)
        {
            Apps = apps ?? new List<App>();
            Selected = selected;
            Paid = paid;

            // Apps.Add(new App("Cubasis 3", 46, 3));
            // Apps.Add(new App("FL Studio Mobile", 50, 5));
            // Apps.Add(new App("LumaFusion Pro", 57, 1));

        }
        
        private Google(Google copy) : base (copy.Apps.Select(a => new App(a)).ToList(), copy.Selected, copy.Paid)
        { 


        }
    

        protected override void WelcomeToStore()
        {
            Console.WriteLine("Welcome to the Google AppStore!");
            Console.WriteLine("-------------------------------");
        }

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

