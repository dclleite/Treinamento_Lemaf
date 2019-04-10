using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vetores
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5] { 1, 3, 5, 2, 0 };

            int i = Array.IndexOf(arr, 10);

            foreach (int vet in arr)
            {
                Console.WriteLine(vet);
            }
            Console.WriteLine(i);

            Console.ReadKey();
        }
    }
}
