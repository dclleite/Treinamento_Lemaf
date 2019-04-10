using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa
            {
                Id = 1,
                Nome = "Eduardo"

            };

            Pessoa pessoa2 = new Pessoa
            {
                Id = 2,
                Nome = "Luiz"
            };


            RepositorioGenerico<Pessoa> repositorioPessoa = new RepositorioGenerico<Pessoa>();

            repositorioPessoa.Insert(pessoa);
            repositorioPessoa.Insert(pessoa2);


            foreach (Pessoa p in repositorioPessoa.Get())
            {
                Console.WriteLine("{0}, {1}", p.Id, p.Nome);
            }
            Console.ReadKey();
        }
    }
}
