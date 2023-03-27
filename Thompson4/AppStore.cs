
namespace AppStoreNS
{
    public abstract class AppStore
    {
        protected List<App> Apps { get; set; }
        protected int Selected { get; set; }
        protected int Paid { get; set; }

        public AppStore(List<App>? apps = null, int selected = -1, int paid = 0)
        {
            Apps = apps ?? new List<App>();
            Selected = selected;
            Paid = paid;
        }

        private AppStore(AppStore copy)
        {
            Apps = copy.Apps;
            Selected = copy.Selected;
            Paid = copy.Paid;
        }

        public void PurchaseApp()
        {
            WelcomeToStore();
            SelectApp();
            PayForApp();
            ReturnChange();
            DownloadApp();
        }

        protected abstract void WelcomeToStore();

        protected void SelectApp()
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



        protected virtual void ReturnChange()
        {
            int change = Paid - Apps[Selected].Price; 
            int[] changeValues = { 10, 1 };
            int[] changeQuantities = new int[changeValues.Length];

            for (int i = 0; i < changeValues.Length; i++)
            {
                changeQuantities[i] = change / changeValues[i];
                change %= changeValues[i];
            }

            Console.WriteLine("Change returned:");
            for (int i = 0; i < changeValues.Length; i++)
            {
            Console.WriteLine($"({changeQuantities[i]})${changeValues[i]}");
            }
        }

        protected void DownloadApp()
        {
            Console.WriteLine($"Downloading {Apps[Selected].Name}...");
            Console.WriteLine($"Thank you for using our AppStore!");
        }
    }
}

            
        