using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace tumakov_2._0
{
    class Program
    {
        public static void Main()
        {
            exhw1();
        }


        class account
        {
            public int num;
            public decimal balance;
            public string AccType;
            public static long AccountNumber;

            public static long Number()
            {
                return AccountNumber++;
            }

            public static void AddMoney(List<account> bank)
            {
                Console.WriteLine("Enter number of your account");
                int acnum = Convert.ToInt32(Console.ReadLine());
                var found = bank.Find(p => p.num == acnum);

                Console.WriteLine("Emter amount of money you want to add");
                decimal num = Convert.ToDecimal(Console.ReadLine());
                int a = bank.IndexOf(found);
                bank[a].balance = num;
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
                if (bank[a].balance >= num)
                {
                    bank[a].balance -= num;
                    Console.WriteLine("success!");
                }
                else
                {
                    Console.WriteLine("You don't have enough money");
                }
            }


            public static void ReadFromFile(string path, List<account> clients)
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        account person = new account();
                        string text = reader.ReadLine().ToLower();
                        string[] guests = new string[3];
                        guests = text.Split(" ");
                        person.num = int.Parse(guests[0]);
                        person.balance = decimal.Parse(guests[1]);
                        person.AccType = guests[2];

                        clients.Add(person);
                    }
                }
            }



            static void ex0()
            {
                //Console.WriteLine("Создать класс счет в банке с закрытыми полями: номер счета, баланс, 
                //тип банковского счета(использовать перечислимый тип из упр.3.1).
                //Предусмотреть методы для доступа к данным – заполнения и чтения. Создать объект класса,
                //заполнить его поля и вывести информацию об объекте класса на печать.

                //Изменить класс счет в банке из упражнения 7.1 таким образом,
                //чтобы номер счета генерировался сам и был уникальным. Для этого надо создать в классе статическую переменную 
                //и метод, который увеличивает значение этого переменной.

                //Добавить в класс счет в банке два метода: снять со счета и положить на счет.
                //Метод снять со счета проверяет, возможно ли снять запрашиваемую сумму, 
                //и в случае положительного результата изменяет баланс.

                //                В класс банковский счет, созданный в упражнениях 7.1 -
                //7.3 добавить метод, который переводит деньги с одного счета на другой.У
                //метода два параметра: ссылка на объект класса банковский счет откуда
                //снимаются деньги, второй параметр – сумма.

                Console.WriteLine("Enter number of needed operation");
                Console.WriteLine("1 - print");
                Console.WriteLine("2 - new");
                Console.WriteLine("3 - exit");
                Console.WriteLine("4 - add money");
                Console.WriteLine("5 - withdraw money");
                string path = @"C:\Users\Allli\source\repos\Sixth homework\clients.txt";
                List<account> clients = new List<account>();
                int num = Convert.ToInt32(Console.ReadLine());
                while (num != 3)
                {
                    switch (num)
                    {
                        case 1:
                            ReadFromFile(path, clients);
                            for (int i = 0; i < clients.Count; i++)
                            {

                                account person = clients[i];
                                Console.WriteLine("Number of account: " + person.num + " Sum: " + person.balance + " Account type: " + person.AccType);
                                continue;
                            }
                            Main();
                            continue;

                        case 2:
                            account NewAccount = new account();
                            Console.WriteLine("Введите номер банковского счета:");
                            long number = account.AccountNumber;
                            Console.WriteLine("Введите баланс банковского счета:");
                            decimal balance;
                            while (!decimal.TryParse(Console.ReadLine(), out balance))
                            {
                                Console.WriteLine("Wrong enter");
                            }
                            Console.WriteLine("Enter account type");
                            Console.WriteLine("1 - saving");
                            Console.WriteLine("2 - current");
                            byte a;
                            while (!byte.TryParse(Console.ReadLine(), out a))
                            {
                                Console.WriteLine("Wrong enter. Try again");
                            }
                            switch (a)
                            {
                                case 1:
                                    string abc = number + " " + balance + " saving ";
                                    using (StreamWriter writer = new StreamWriter(path, false))
                                    {
                                        writer.WriteLine(abc);
                                    }
                                    Main();
                                    continue;
                                case 2:
                                    string abc1 = number + " " + balance + " current ";
                                    using (StreamWriter writer = new StreamWriter(path, false))
                                    {
                                        writer.WriteLine(abc1);
                                    }
                                    Main();
                                    continue;

                                case 3:
                                    account.AddMoney(clients);
                                    Main();
                                    continue;

                                case 4:
                                    account.TakeMoney(clients);
                                    Main();
                                    continue;

                                default:
                                    Console.WriteLine("Wrong enter!");
                                    Main();
                                    continue;
                            }


                    }
                }
            }
        }


        public static void Reverse(string c)
        {
            var b_reverse = new StringBuilder();
            for (int i = c.Length - 1; i >= 0; i--)
            {
                b_reverse.Append(c[i]);
            }
            Console.WriteLine(b_reverse.ToString()); //321cba
            Console.ReadLine();


        }
        public static void ex1()
        {
            Console.WriteLine("Реализовать метод, который в качестве входного параметра принимает строку string, возвращает строку типа string, " +
                "буквы в которой идут в обратном порядке. Протестировать метод.");

            Console.WriteLine("Enter a string");
            string a = Console.ReadLine();
            Reverse(a);

        }

        public static void ex2()
        {
            Console.WriteLine("Написать программу, которая спрашивает у пользователя имя файла.Если такого файла не существует, " +
                "то программа выдает пользователю сообщение и заканчивает работу, иначе в выходной файл записывается содержимое исходного файла, " +
                "но заглавными буквами.");

            Console.WriteLine("Enter a name of file");
            string name = Console.ReadLine();
            string path = @"C:\Users\Allli\Desktop" + name + ".txt";
            string path2 = @"C:\Users\Allli\Desktop\try.txt";
            if (File.Exists(path))
            {
                string a = "";
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        string text = reader.ReadLine().ToUpper();
                        a += text;

                    }
                }
                File.AppendAllText(path2, a);
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }

        public class Temperature : IFormattable
        {
            private decimal temp;

            public Temperature(decimal temperature)
            {
                if (temperature < -273.15m)
                    throw new ArgumentOutOfRangeException(String.Format("{0} is less than absolute zero.",
                                                        temperature));
                this.temp = temperature;
            }

            public string ToString(string format, IFormatProvider provider)
            {
                return temp.ToString("F2", provider) + " °C";
            }
        }

        static void checkArgImplementInterface(Temperature t)
        {
            IFormattable form, form2;

            if (t is IFormattable)
            {
                form = (IFormattable)t;
            }
            else
            {
                form = null;
            }

            if (form is null)
            {
                Console.WriteLine("Не реализует IFormattable");
            }
            else
            {
                Console.WriteLine("Реализует IFormattable");
            }

            form2 = t as IFormattable;

            if (form2 is null)
            {
                Console.WriteLine("Не реализует IFormattable");
            }
            else
            {
                Console.WriteLine("Реализует IFormattable");
            }
        }

        static void ex4()
        {
            Console.WriteLine("Реализовать метод, который проверяет реализует ли входной параметр метода интерфейс System.IFormattable." +
                "Использовать оператор is и as. (Интерфейс IFormattable обеспечивает функциональные возможности форматирования значения " +
                "объекта в строковое представление.)");
            Temperature t = new Temperature(50);
            checkArgImplementInterface(t);
        }

        public static string CutEmail(string v)
        {
            v = v.Split('#')[1];
            return v;
        }








        static void exhw1()
        {
            Console.WriteLine("Список песен. В методе Main создать список из четырех песен.В цикле вывести информацию о каждой песне." +
                "Сравнить между собой первую и вторую песню в списке. Песня представляет собой класс с методами для заполнения каждого из полей, " +
                "методом вывода данных о песне на печать, методом, который сравнивает между собой два объекта: " +
                "class Song { string name; //название песни string author; //автор песни Song prev; //связь с предыдущей песней в списке" +
                "   //метод для заполнения поля name //метод для заполнения поля author //метод для заполнения поля " +
                " //метод для печати названия песни и ее исполнителя public string Title() { ... /*возвращ название+исполнитель*/ ..." +
                " //метод, который сравнивает между собой два объекта-песни:   public bool override Equals(object d) { ...}");
            List<Songs> songs = new List<Songs>();
            Songs song1 = new Songs { name = "Last Christmas", author = "Wham!" };
            songs.Add(song1);
            Songs song2 = new Songs { name = "Santa Tell Me", author = "Ariana Grande" };
            songs.Add(song2);
            Songs song3 = new Songs { name = "The Scientist", author = "Coldplay" };
            songs.Add(song3);
            Songs song4 = new Songs { name = "Snowman", author = "Sia" };
            songs.Add(song4);
            Console.WriteLine("Enter needed operation");
            Console.WriteLine("1 - print list of somgs");
            Console.WriteLine("2 - compare two first songs");
            byte num;
            while (!byte.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Wrong enter! Try again");
            }
            switch (num)
            {
                case 1:
                    Songs.PrintList(songs);
                    return;
                case 2:
                    Songs songone = songs[0];
                    Songs songtwo = songs[1];
                    Console.WriteLine("name: " + songone.name + " | " + songtwo.name);
                    Console.WriteLine("author: " + songone.author + " | " + songtwo.author);
                    return;
                default:
                    Console.WriteLine("Sorry, there is no such option");
                    return;
            }



        }


    }
}
    

