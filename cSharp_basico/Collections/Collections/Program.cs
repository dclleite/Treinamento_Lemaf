using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> meuDicionario = new Dictionary<string, string>();
            meuDicionario.Add("teste","teste 1 significa");
            meuDicionario.Add("teste2", "teste 2 significa");
            meuDicionario.Add("teste3", "teste 3 significa");
            meuDicionario.Add("teste4", "teste 4 significa");

            foreach (string chave in meuDicionario.Keys)
            {
                Console.WriteLine("{0}: {1}", chave, meuDicionario[chave]);
            }

        }
    }
}
