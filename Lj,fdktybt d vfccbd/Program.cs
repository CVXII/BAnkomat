using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace ConsoleApp66
{
    class Program
    {
        public class UserInfo
        {
            /*ФИО, логин, пароль, группа, дата последнего входа в систему, дата создания учетной записи, количество предупреждений*/

            public string fist_Name { get; set; }

            public string last_Name { get; set; }

            public string pinkode { get; set; }

            public string number_card { get; set; }

            public double balance_card { get; set; }
            public string Info => $"Имя: {fist_Name} || Фамилия: {last_Name} || Номер карты: {number_card} || Баланс: {balance_card} ";


        }


        public static List<UserInfo> Spisok = new List<UserInfo>()
        {
            
        };
        static void Add()
        {
           

            var rand = new Random();
            UserInfo userInfo = new UserInfo();

            Console.WriteLine("Добавление нового пользователя");

            Console.Write("Введите имя: ");
            userInfo.fist_Name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            userInfo.last_Name = Console.ReadLine();
            Console.Write("Введите номер вашей карты: ");
            userInfo.number_card = Console.ReadLine();
            Console.Write("Введите пинкод: ");
            userInfo.pinkode = Console.ReadLine();
            userInfo.balance_card = rand.NextDouble() * 10000;
            Spisok.Add(userInfo);


        }
        
        static void printOptions()
        {
            Console.WriteLine("Куда пойдём");
            Console.WriteLine("1. Пополнение");
            Console.WriteLine("2. Снятие ");
            Console.WriteLine("3. Баланс");
            Console.WriteLine("4. Добавление нового пользователя");
            Console.WriteLine("5. Список пользователей");
            Console.WriteLine("6. Выход");
        }

        void balance(UserInfo userInfo)
        {
                Console.WriteLine("Ваш баланс: " + userInfo.balance_card);
        }

        void popolnenie(UserInfo userInfo)
        {
            double popol = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("На какую сумму вы хотитие пополнить баланс");
            userInfo.balance_card = userInfo.balance_card + popol;

        }

        void snatye(UserInfo userInfo)
        {
            double snatye = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Сколько денег вы желаете снять?");
            if (userInfo.balance_card < snatye)
            {
                Console.WriteLine("Нету столько денег");
                Console.WriteLine("Повторите попытку");
            }
            else
            {
                userInfo.balance_card = userInfo.balance_card - snatye;
                Console.WriteLine("Удачного вам дня!");

            }
            


        }

        static void Main(string[] args )
        {
            Add();
            
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option == 1) { snatye(); }
                else if (option == 2) { popolnenie(); }
                else if (option == 3) { balance(); }
                else if (option == 4) { Add(); }
                else if (option == 5)
                {
                    foreach (var user in Spisok)
                    {
                        Console.WriteLine(user.Info);
                    }; 
                }
                else if (option == 6) { break; }
                else { option = 0; }
            }
            while (option != 6);
            Console.WriteLine("Удачного вам дня!");
        }

        
    }
}
    
 
    
