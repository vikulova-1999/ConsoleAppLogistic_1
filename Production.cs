using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLogistic_1
{
    class Production
    {
        public static int M, n; //M, количество продукции на заводе
        public static void ZnM()
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

        public static void ZnN()
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
