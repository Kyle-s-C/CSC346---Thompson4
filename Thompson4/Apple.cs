

namespace AppStoreNS
{
    public class Apple : AppStore
    {
        public Apple(List<App>? apps = null, int selected = -1, int paid = 0) : base(apps, selected, paid)
        {
            Apps = apps ?? new List<App>();
            Selected = selected;
            Paid = paid;


        
        }

        public Apple(Apple copy) : base (copy.Apps.Select(a => new App(a)).ToList(), copy.Selected, copy.Paid)
        { 


        }
    

       
        protected override void WelcomeToStore()
        {
            Console.WriteLine("Welcome to the Apple AppStore!");
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
                    Console.WriteLine("Insufficient payment. Please try again.");
                }

            }while(totalPayment < Apps[Selected].Price);

            Paid = totalPayment;

        }

    }
}







