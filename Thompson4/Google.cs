namespace AppStoreNS
{
    public class Google : AppStore
    {
        public Google(List<App>? apps = null, int selected = -1, int paid = 0) : base(apps, selected, paid)
        {
            Apps = apps ?? new List<App>();
            Selected = selected;
            Paid = paid;
        }
        
        private Google(Google copy) : base (copy.Apps.Select(a => new App(a)).ToList(), copy.Selected, copy.Paid)
        { 


        }
    

        protected override void WelcomeToStore()
        {
            Console.WriteLine("Welcome to the Google AppStore!");
        }

        protected override void ReturnChange()
        {
            int change = Paid - Apps[Selected].Price;
            int[] changeValues = { 5, 2, 1 };
            int[] changeQuantities = new int[changeValues.Length];

            for (int i = 0; i < changeValues.Length; i++)
            {
                changeQuantities[i] = change / changeValues[i];
                change %= changeValues[i];
            }

            Console.WriteLine("Change returned:");
            for (int i = 0; i < changeValues.Length; i++)
            {
                Console.WriteLine($"({changeQuantities[i]}) x ${changeValues[i]}");
            }
        }
    }
}

