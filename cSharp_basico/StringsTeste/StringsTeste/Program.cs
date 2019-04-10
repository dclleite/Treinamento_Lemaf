using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "teste";
            string s2 = "de strings";

            // fomas de concatenar

            string s3 = s1 + " " + s2;

            Console.WriteLine("s1 + s2 : {0}", s1 + " " + s2);
            Console.WriteLine("s3 : {0}", s3);


            // StringBuilder: manipular strings de forma mais eficiente;

            StringBuilder s4 = new StringBuilder();

            // metodo Append da classe StringBuilder junta strings dentro do buffer do StringBuilder;
            s4.Append(s1);
            s4.Append(" ");
            s4.Append(s2);

            Console.WriteLine("s4 : {0}", s4.ToString());

            Console.ReadKey();

        }
    }
}
