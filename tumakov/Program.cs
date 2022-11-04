using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tumakov
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public class account
        {
            public int num;
            public decimal money;
            public string Initials;
        }
        public static void AddMoney(List<account> bank)
        {
            Console.WriteLine("Enter number of your account");
            int acnum = Convert.ToInt32(Console.ReadLine());
            var found = bank.Find(p => p.num == acnum);

            Console.WriteLine("Emter amount of money you want to add");
            decimal num = Convert.ToDecimal(Console.ReadLine());
            int a = bank.IndexOf(found);
            bank[a].money = num;
            Console.WriteLine("money were added successfully");

        }

        public static void TakeMoney(List<account> bank)
        {
            Console.WriteLine("Enter number of your account");
            int acnum = Convert.ToInt32(Console.ReadLine());
            var found = bank.Find(p => p.num == acnum);

            Console.WriteLine("Emter amount of money you want to take");
            decimal num = Convert.ToDecimal(Console.ReadLine());
            int a = bank.IndexOf(found);
            if (bank[a].money >= num)
            {
                bank[a].money -= num;
                Console.WriteLine("success!");
            }
            else
            {
                Console.WriteLine("You don't have enough money");
            }



        }

        public static void NumOfAcc(int account)
        {
            account newclient = new account();
            account += 1;
            account = newclient.num;
        }

        public static void ex1()
        {
            Console.WriteLine("В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить метод, который переводит деньги с одного счета на другой." +
                "У метода два параметра: ссылка на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.");
            List<account> clients = new List<account>();
            int count = 0;
            Console.WriteLine("Choose needed operation");
            Console.WriteLine(" 1 - Add new client");
            Console.WriteLine(" 2 - Deposit money");
            Console.WriteLine("3 - Withdraw money");
            try
            {
                int a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        account newclient = new account();
                        NumOfAcc(count);
                        newclient.num = count;
                        Console.WriteLine("Your number of account: {0}", count);
                        Console.WriteLine("Enter the account balance");
                        int sum = Convert.ToInt32(Console.ReadLine());
                        newclient.money = sum;
                        Console.WriteLine("Enter Initials of the client");
                        string name = Console.ReadLine();
                        newclient.Initials = name;
                        clients.Add(newclient);
                        return;
                    case 2:
                        AddMoney(clients);
                        return;

                    case 3:
                        TakeMoney(clients);
                        return;

                    default:
                        Console.WriteLine("You entered something wrong");
                        return;
                }
            }

            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            

        }

    }
}
