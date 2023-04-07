using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class MachineOperations
    {
        public int balance = 0;
        string[] kind = new string[] { "Coca cola", "Mirinda", "Ice tea", "Water", "Coffee" };
        Drinks[] drinks = new Drinks[5];

        IDictionary<string, int> numberOfDrinks = new Dictionary<string, int>();
        Random rndQuantity = new Random();

        public MachineOperations()
        {
            CreateDrinks();
        }

        private void CreateDrinks()
        {
            for (int i = 0; i < kind.Length; i++)
            {
                drinks[i] = new Drinks(kind[i]);
            }

            numberOfDrinks = new Dictionary<string, int>();
            numberOfDrinks.Add("Coca cola", rndQuantity.Next(1, 5));
            numberOfDrinks.Add("Mirinda", rndQuantity.Next(1, 5));
            numberOfDrinks.Add("Ice tea", rndQuantity.Next(1, 5));
            numberOfDrinks.Add("Water", rndQuantity.Next(1, 5));
            numberOfDrinks.Add("Coffee", rndQuantity.Next(1, 5));
        }

        public void BuyItem()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i + 1 + ":\t" + drinks[i]);
            }
            Console.WriteLine("Choose a number of drink you want to buy:");
            int idFromList = InputControl();

            int itemPrice = drinks[idFromList - 1].price;

            if (balance >= itemPrice)
            {
                if (numberOfDrinks[kind[idFromList - 1]] >= 1)
                {
                    balance = balance - itemPrice;
                    Console.WriteLine("Here is your drink");
                    numberOfDrinks[kind[idFromList - 1]] -= 1;
                }

                else
                    Console.WriteLine("This drink is no longer available");
            }

            else
                Console.WriteLine("The request cannot be fulfilled");
        }

        //public int ReturnBalance()
        //{
        //    return balance;
        //}

        //public void PutMoneyIn(int cash)
        //{
        //    balance = cash;
        //}

        public int ReturnBalance()
        {
            Console.WriteLine("You have: {0} Kc left", balance);
            return balance;
        }

        private int WithdrawBalance()
        {
            if (balance > 0)
            {
                Console.WriteLine("You have withdrawn {0} Kc", balance);
                balance = 0;
                return balance;
            }
            else
                Console.WriteLine("There are no money to withdraw");
            return balance;
        }

        public int InputControl()
        {
            bool inputCheck;

            string stream = Console.ReadLine();

            if (String.IsNullOrEmpty(stream))
            {
                throw new Exception("Input must be an integer");
            }

            else
            {
                inputCheck = int.TryParse(stream, out int input);

                if (input >= 0)
                {
                    return input;
                }

                else
                    throw new Exception("Input must be a positive number");
            }


        }
        private void PutMoneyIn()
        {

            Console.WriteLine("Choose an amount of cash you want to put in");

            balance = balance + InputControl();
        }

        //public void PutMoneyIn(int castka)
        //{

        //    Console.WriteLine("Zadejte castku, kterou chcete vlozit:");

        //    balance = balance + castka;
        //}

        private void WriteList()
        {
            Console.WriteLine("List of drinks:");
            foreach (Drinks i in drinks)
            {
                Console.WriteLine(i.ToString());
            }
        }

        private void WriteNumberOfDrinks()
        {
            Console.WriteLine("Remaining amount of drinks:");
            var write = String.Join("\n", numberOfDrinks.Select(kvp => kvp.Key + ":  \t" +
                            kvp.Value.ToString()));
            Console.WriteLine(write);
        }


        private void ShowMenu()
        {
            Console.WriteLine("Welcome to the vending machine app\nPlease choose an optionNumber from menu below:");
            Console.WriteLine("1 - Put money in");
            Console.WriteLine("2 - Check balance");
            Console.WriteLine("3 - Withdraw balance");
            Console.WriteLine("4 - List of drinks");
            Console.WriteLine("5 - Remaining number of drinks");
            Console.WriteLine("6 - Buy a drink");
            Console.WriteLine("7 - End program");
        }
        public void Menu()
        {
            string option;
            bool check;
            int optionNumber;

            bool checkContinue = true;

            do
            {
                ShowMenu();
                option = Console.ReadLine();
                check = int.TryParse(option, out optionNumber);

                switch (optionNumber)
                {
                    case 1:
                        PutMoneyIn();
                        Console.Clear();
                        break;
                    case 2:
                        ReturnBalance();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        WithdrawBalance();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        WriteList();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        WriteNumberOfDrinks();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        BuyItem();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 7:
                        checkContinue = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            } while (checkContinue == true);
        }
    }
}
