using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleAppLogistic_1
{
    class Program
    {
        public static int M, n; //M, количество продукции на заводе
        public static int a, b, c; //Завод
        public static int Truck1, Truck2; //Грузовик
        public static int sum = 0;
        static void Main()
        {
            // Ввод значения M
            Console.Write("Укажите M >=100:");
            string userString = Console.ReadLine();
            M = Convert.ToInt32(userString);
            if (M < 100)
            {
                throw new Exception("Введите корректное значение M");
            }

            // Ввод значения n
            Console.Write("\nУкажите объём выпуска продукции в час >=50:");
            string userString1 = Console.ReadLine();
            n = Convert.ToInt32(userString1);
            if (n < 50)
            {
                throw new Exception("Введите корректное значение объёма выпуска продукции в час");
            }

            //Вместимость 1 грузовика
            Console.Write("Укажите вместимость 1 грузовика:");
            string userString2 = Console.ReadLine();
            Truck1 = Convert.ToInt32(userString2);

            //Вместимость 2 грузовика
            Console.Write("Укажите вместимость 2 грузовика:");
            string userString3 = Console.ReadLine();
            Truck2 = Convert.ToInt32(userString3);

            a = n;  //количество выпускаемой продукции завода A в час
            b = Convert.ToInt32(1.1 * n); //количество выпускаемой продукции завода B в час
            c = Convert.ToInt32(1.2 * n); //количество выпускаемой продукции завода C в час
            sum = a + b + c;
            //Общая вместимость склада
            int Sklad = M * sum;

            double workload = Convert.ToInt32(Sklad * 95 / 100); //Загруженность склада 95%
            //сколько сырья перевезет грузовик
            double VoyageTruck1 = Convert.ToInt32(workload * 50 / 100 / Truck1);
            double VoyageTruck2 = Convert.ToInt32(workload * 50 / 100 / Truck2);
            //за сколько заездов перевезет грузовик сырье
            double Rote1 = Convert.ToInt32(workload * 50 / 100);
            double Rote2 = Convert.ToInt32(workload * 50 / 100);

            Console.Write("\n\n\nПоследовательность поступления продукции на склад");

            // создаем первый поток и назначаем функцию - выпуск продукта_a 
            Thread factory_a = new Thread(ReleaseProduct_a);
            // запускаем первый поток
            factory_a.Start();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // создаем второй поток и назначаем функцию - выпуск продукта_b
            Thread factory_b = new Thread(ReleaseProduct_b);
            // запускаем второй поток
            factory_b.Start();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // создаем третий поток и назначаем функцию - выпуск продукта_c 
            Thread factory_c = new Thread(ReleaseProduct_c);
            // запускаем третий поток
            factory_c.Start();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // далее выводятся расчётные данные по указанному условию задания
            Console.Write(string.Format("\n\nМаксимальная вместимость склада: {0} едениц продукции со всех фабрик", Sklad));
            Console.Write(string.Format("\nПри заполнении склада на 95% - {0} едениц продукции, производится вывоз со склада двумя грузовиками", workload));



            Console.Write(string.Format("\n\nСтатистика по 1 грузовику" +
                "\nВместимость грузовика: {0} едениц продукции" +  "\nКоличество рейсов: {1}" +
             "\nПеревезёт {2} едениц товара, в том числе: продукт a - {3}, продукт b - {4}, продукт c - {5}", 
             Truck1, VoyageTruck1, Rote1, a, b, c));

            Console.Write(string.Format("\n\nСтатистика по 2 грузовику" +
                "\nВместимость грузовика: {0} едениц продукции" + "\nКоличество рейсов: {1}" +
             "\nПеревезёт {2} едениц товара, в том числе: продукт a - {3}, продукт b - {4}, продукт c - {5}",
             Truck2, VoyageTruck2, Rote2, a, b, c));
        }
        public static void ReleaseProduct_a()
        {
            Console.WriteLine(string.Format("\nФабрика A. выпускает  продукт a в размере {0} единиц продукции в час",  a));
        }
        public static void ReleaseProduct_b()
        {
            Console.WriteLine(string.Format("Фабрика B. выпускает продукт b в размере  {0} единиц продукции в час", b));
        }
        public static void ReleaseProduct_c()
        {
            Console.WriteLine(string.Format("Фабрика C. выпускает продукт c в размере  {0} единиц продукции в час", c));
            Console.ReadLine();
        }
    }
}
