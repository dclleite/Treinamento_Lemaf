using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingUmboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Boxing: pega uma variavel Value Type e armazena em uma variavel Reference Type
            int n1 = 2;
            object obj1 = n1;
            Console.WriteLine(obj1);

            // Umboxing: e preciso fazer um cast, copiando o valor da memoria heap para memoria stack
            int n2 = (int)obj1;
            Console.WriteLine(n2);
            Console.ReadKey();



        }
    }
}
