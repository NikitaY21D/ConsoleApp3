
/*Номер 9 Различные цеха завода выпускают продукцию нескольких наименований. 
 * Сведения о продукции включают: наименование, количество, номер цеха. Для заданного цеха необходимо 
 * вывести изделияпо каждому наименованию в порядке убывания их количества. 
 * Ключ: количество выпущенных изделий..*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp3
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            Console.Write("Количество: ");
            int countManu = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n");

            int countAmount = 0;


            Production[,] prod = new Production[countManu, 50];


            for (int i = 0; i < countManu; i++)
            {
                Console.Write("Номер: ");
                int count = Convert.ToInt32(Console.ReadLine());

                Console.Write("Количество наименований: ");
                countAmount = Convert.ToInt32(Console.ReadLine());

                for (int j = 0; j < countAmount; j++)
                {
                    prod[i, j] = new Production();
                    prod[i, 0].NumManufactory = count;

                    Console.Write("Наименование изделия: ");
                    prod[i, j].Name = Console.ReadLine();

                    Console.Write("Количество изделий: ");
                    prod[i, j].Amount = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n");

                }
            }

            Console.Write("\nНомер цеха для вывода информации: ");
            int manufactory = Convert.ToInt32(Console.ReadLine());


            int l = 0, temp;

            for (int i = 0; i < countManu; i++)
            {
                if (prod[i, 0].NumManufactory == manufactory) { l = i; }
                else if (0 > l || l > countManu) { Console.WriteLine("Ввели неверный номер завода..."); }
            }

            for (int i = 0; i < countAmount - 1; i++)
            {
                for (int j = i + 1; j < countAmount; j++)
                {
                    if (prod[l, i].Amount > prod[l, j].Amount)
                    {
                        temp = prod[l, i].Amount;
                        prod[l, i].Amount = prod[l, j].Amount;
                        prod[l, j].Amount = temp;
                    }
                }
            }

            for (int i = countAmount - 1; i >= 0; i--)
                Console.WriteLine(prod[l, i].Name + " в наличии: " + prod[l, i].Amount + " шт.");

            Console.ReadKey();
        }


    }
}

