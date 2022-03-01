using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLogistic_1
{

    class Fabric : Production
    {
        public static int a, b, c; //Завод
        public static int sum = 0;
        public Fabric()
        {
            a = n;  //количество выпускаемой продукции завода A в час
            b = Convert.ToInt32(1.1 * n); //количество выпускаемой продукции завода B в час
            c = Convert.ToInt32(1.2 * n); //количество выпускаемой продукции завода C в час
            sum = a + b + c;
        }
        public static void Product_a()
        {
            Console.WriteLine(string.Format("\nФабрика A. Продукт a. Количество продукции: {0} единиц продукции в час", a));
        }

        public static void Product_b()
        {
            Console.WriteLine(string.Format("Фабрика B. Продукт b. Количество продукции: {0} единиц продукции в час", b));
        }

        public static void Product_c()
        {
            Console.WriteLine(string.Format("Фабрика C. Продукт c. Количество продукции: {0} единиц продукции в час", c));
        }
    }

}
