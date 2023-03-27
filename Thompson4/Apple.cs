

namespace AppStoreNS
{
    public class Apple : AppStore
    {
        public Apple(List<App>? apps = null, int selected = -1, int paid = 0) : base(apps, selected, paid)
        {
            Apps = apps ?? new List<App>();
            Selected = selected;
            Paid = paid;  

            Apps.Add(new App("Final Cut Pro", 54, 3));
            Apps.Add(new App("Logic Pro", 50, 4));
            Apps.Add(new App("MainStage", 46, 5));
            Apps.Add(new App("Pixelmator Pro", 57, 2)); 
        }

        private Apple(Apple copy) : base (copy.Apps.Select(a => new App(a)).ToList(), copy.Selected, copy.Paid)
        { 
            Apps  = copy.Apps;
            Selected = copy.Selected;
            Paid = copy.Paid;

        }
    

       
        protected override void WelcomeToStore()
        {
            Console.WriteLine("Welcome to the Apple AppStore!");
            Console.WriteLine("------------------------------");
        }

        protected override void PayForApp() 
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







