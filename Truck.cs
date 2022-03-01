using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLogistic_1
{
    class Truck : Fabric
    {
        public static int Truck1, Truck2, Sklad; //Грузовик
        public static double workload, VoyageTruck1, VoyageTruck2, Rote1, sum_a1, sum_b1, sum_c1,
            Rote2, sum_a2, sum_b2, sum_c2;
        public void Print_Truck()
        {
            //Вместимость 1 грузовика
            Console.Write("Укажите вместимость 1 грузовика:");
            string userString2 = Console.ReadLine();
            Truck1 = Convert.ToInt32(userString2);

            //Вместимость 2 грузовика
            Console.Write("Укажите вместимость 2 грузовика:");
            string userString3 = Console.ReadLine();
            Truck2 = Convert.ToInt32(userString3);

            //количество рейсов
            VoyageTruck1 = Math.Ceiling(workload * 50 / 100 / Truck1);
            VoyageTruck2 = Math.Ceiling(workload * 50 / 100 / Truck2);
        }
        public Truck()
        {
            //Общая вместимость склада
            Sklad = M * sum;
            workload = Convert.ToInt32(Sklad * 95 / 100); //Загруженность склада 95%

            //сколько товаров перевезет грузовик
            Rote1 = Math.Round(workload * 50 / 100);
            Rote2 = workload - Rote1;

            double Hours = Math.Ceiling(workload / sum); //время, за которое склад заполнится на 95%

            //Тип и количество продукции на складе
            double sum_a = Hours * a;
            double sum_b = Hours * b;
            double sum_c = Hours * c;

            //Продукция, которую увозит 1 грузовик
            sum_a1 = Math.Ceiling(sum_a * 50 / 100);
            sum_b1 = Math.Ceiling(sum_b * 50 / 100);
            sum_c1 = Math.Ceiling(sum_c * 50 / 100);

            //Продукция, которую увозит 2 грузовик
            sum_a2 = sum_a - sum_a1;
            sum_b2 = sum_b - sum_b1;
            sum_c2 = sum_c - sum_c1;
        }

        public static void Statistic_Sklad()
        {
            // Вывод информации по складу
            Console.Write(string.Format("\n\nМаксимальная вместимость склада: {0} едениц продукции со всех фабрик", Sklad));
            Console.Write(string.Format("\nЗаполняемость склада 95% - {0} едениц продукции", workload));
        }
        public static void Statistic_Truck()
        {
            //Вывод статистики по грузовику
            Console.Write(string.Format("\n\nСтатистика по 1 грузовику" +
                "\nВместимость грузовика: {0} едениц продукции" + "\nКоличество рейсов: {1}" +
             "\nПеревезёт {2} едениц товара, в том числе: продукт a - {3} единиц, продукт b - {4} единиц, продукт c - {5} единиц",
             Truck1, VoyageTruck1, Rote1, sum_a1, sum_b1, sum_c1));

            Console.Write(string.Format("\n\nСтатистика по 2 грузовику" +
                "\nВместимость грузовика: {0} едениц продукции" + "\nКоличество рейсов: {1}" +
             "\nПеревезёт {2} едениц товара, в том числе: продукт a - {3} единиц, продукт b - {4} единиц, продукт c - {5} единиц",
             Truck2, VoyageTruck2, Rote2, sum_a2, sum_b2, sum_c2));
        }
    }
}
