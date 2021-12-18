using System;

namespace Laba_7
{
    public class ATM
    {
        private string Remainder { get; set; }
        private static int PIN = 1189;
        public static void AddPassenger()
        {
            Console.Clear();
            Console.Write("Введіть пінкод: ");
            int Pin_code = Convert.ToInt32(Console.ReadLine());
            Console.Write("Який залишок: ");
            string[] Remainder = Console.ReadLine().Split(' ');
            if (Pin_code == Remainder.Length)
            {
                try
                {

                    if (Pin_code != PIN)
                    {
                        throw new ZnyatyZRahunkuException($"ПОМИЛКА: Неправильний пароль");
                    }
                    else
                    {
                        Statistic.Rem++;
                        Statistic.sname = Remainder;
                        Console.WriteLine(Remainder);
                        Console.WriteLine("У вас такий залишок на рахунку:> " + Statistic.Rem + " | " + PIN);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (Pin_code > Remainder.Length)
            {
                Console.WriteLine(": " + Remainder.Length + " | " + Pin_code);
            }
            else if (Pin_code < Remainder.Length)
            {
                Console.WriteLine("Недостатньо коштів " + Remainder.Length + " | " + Pin_code);
            }
            Console.Write("-=-=-=-=-=-=-");
            Console.Write(" ");
            Program.Main();
        }
    }
    public class Bank
    {
        public static void Sum()
        {
            Console.Clear();
            Console.Write("Введіть яку суму хочете зняти: ");
            int Suma = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (Suma <= 0)
                {
                    throw new ZalyshokNaRahunkuException($"ПОМИЛКА: Недостатньо коштів на рахунку: " + Suma);
                    Statistic.ordinaryaccount = "На Звичайному р";
                }
                else
                {
                    Statistic.Bank = Suma;
                    Statistic.ordinaryaccount = "Грошей достатньо";
                    Console.WriteLine("Видача");
                    Console.WriteLine("Залишок: " + Statistic.Bank);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("************");
            Console.Write(" ");
            Program.Main();
        }
    }
    public static class Statistic
    {
        public static string[] sname;
        public static string landingPlace = "Не вказано";
        public static int Rem;
        public static int Bank;
        public static string ordinaryaccount = "Не вказано";
    }
    public class ZnyatyZRahunkuException : Exception
    {
        public ZnyatyZRahunkuException(string aMessage) : base(aMessage) { }
    }
    public class ZalyshokNaRahunkuException : Exception
    {
        public ZalyshokNaRahunkuException(string aMessage) : base(aMessage) { }
    }
    public class Program
    {
        private static string[] args;
        private static void Commands()
        {
            args = Console.ReadLine().Split(' ');
            if (args[0] == "Pin-code")
            {
                ATM.AddPassenger();
            }
            if (args[0] == "Remainder")
            {
                Bank.Sum();
            }
            if (args[0] == "InfoGet")
            {
                Console.WriteLine("Залишок: " + Statistic.Rem);
                Console.WriteLine("Pin-code: " + Statistic.sname);
                Console.WriteLine("Сума: " + Statistic.Bank);
                Console.WriteLine("Звичайний рахунок: " + Statistic.ordinaryaccount);
            }
            if (args[0] == "exit")
            {
                return;
            }
            Commands();
        }
        public static void Main()
        {
            Console.WriteLine("Pin-code -> Ввести Pin ");
            Console.WriteLine("Remainder -> Залишок");
            Commands();
        }
    }
}
