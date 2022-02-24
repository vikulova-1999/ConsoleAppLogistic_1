using System;
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

            ZnM(); //Ввод значения M
            ZnN(); //Ввод значения n

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

            //количество рейсов
            double VoyageTruck1 = Math.Ceiling(workload * 50 / 100 / Truck1);
            double VoyageTruck2 = Math.Ceiling(workload * 50 / 100 / Truck2);

            //сколько товаров перевезет грузовик
            double Rote1 = Math.Round(workload * 50 / 100);
            double Rote2 = workload - Rote1;

            double Hours = Math.Ceiling(workload / sum); //время, за которое склад заполнится на 95%

            //Тип и количество продукции на складе
            double sum_a = Hours * a;
            double sum_b = Hours * b;
            double sum_c = Hours * c;

            //Продукция, которую увозит 1 грузовик
            double sum_a1 = Math.Ceiling(sum_a * 50 / 100);
            double sum_b1 = Math.Ceiling(sum_b * 50 / 100);
            double sum_c1 = Math.Ceiling(sum_c * 50 / 100);

            //Продукция, которую увозит 2 грузовик
            double sum_a2 = sum_a - sum_a1;
            double sum_b2 = sum_b - sum_b1;
            double sum_c2 = sum_c - sum_c1;

            Console.Write("\n\n\nПоследовательность поступления продукции на склад");

            //поток A
            Thread fabricA = new Thread(Product_a);
            fabricA.Start();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            //поток B
            Thread fabricB = new Thread(Product_b);
            fabricB.Start();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            //поток C
            Thread fabricC = new Thread(Product_c);
            fabricC.Start();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Вывод информации по складу
            Console.Write(string.Format("\n\nМаксимальная вместимость склада: {0} едениц продукции со всех фабрик", Sklad));
            Console.Write(string.Format("\nЗаполняемость склада 95% - {0} едениц продукции", workload));

            /*
            Console.Write(string.Format("\nКоличество часов, за которое склад заполнится на 95%: {0} ч", Hours));
            
            Console.Write(string.Format("\nКоличество продукции a на складе: {0} единиц", sum_a));
            Console.Write(string.Format("\nКоличество продукции b на складе: {0} единиц", sum_b));
            Console.Write(string.Format("\nКоличество продукции c на складе: {0} единиц", sum_c));
            */

            Console.Write(string.Format("\n\nСтатистика по 1 грузовику" +
                "\nВместимость грузовика: {0} едениц продукции" +  "\nКоличество рейсов: {1}" +
             "\nПеревезёт {2} едениц товара, в том числе: продукт a - {3} единиц, продукт b - {4} единиц, продукт c - {5} единиц", 
             Truck1, VoyageTruck1, Rote1, sum_a1, sum_b1, sum_c1));

            Console.Write(string.Format("\n\nСтатистика по 2 грузовику" +
                "\nВместимость грузовика: {0} едениц продукции" + "\nКоличество рейсов: {1}" +
             "\nПеревезёт {2} едениц товара, в том числе: продукт a - {3} единиц, продукт b - {4} единиц, продукт c - {5} единиц",
             Truck2, VoyageTruck2, Rote2, sum_a2, sum_b2, sum_c2));
        }

        public static void Product_a()
        {
            Console.WriteLine(string.Format("\nФабрика A. Продукт a. Количество продукции: {0} единиц продукции в час",  a));
        }
        public static void Product_b()
        {
            Console.WriteLine(string.Format("Фабрика B. Продукт b. Количество продукции: {0} единиц продукции в час", b));
        }
        public static void Product_c()
        {
            Console.WriteLine(string.Format("Фабрика C. Продукт c. Количество продукции: {0} единиц продукции в час", c));
            Console.ReadLine();
        }

        private static void ZnM()
        {
            try
            {
                Console.Write("\nУкажите объём выпуска продукции в час >=100:");
                string userString = Console.ReadLine();
                M = Convert.ToInt32(userString);
                if (M < 100)
                {
                    throw new Exception();
                }
            }
            // Обработка исключения
            catch (Exception)
            {
                Console.Write("Введите корректное значение M");
                ZnM();
            }
        }

        private static void ZnN()
        {
            try
            {
                Console.Write("\nУкажите объём выпуска продукции в час >=50:");
                string userString1 = Console.ReadLine();
                n = Convert.ToInt32(userString1);
                if (n < 50)
                {
                    throw new Exception();
                }
            }
            // Обработка исключения
            catch (Exception)
            {
                Console.Write("Введите корректное значение объёма выпуска продукции в час");
                ZnN();
            }


        }


    }
}
