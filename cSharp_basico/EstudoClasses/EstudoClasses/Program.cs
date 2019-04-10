using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Carro carro = new Carro();
            Carro carro2 = new Carro();

            Dono donoJoao = new Dono();
            donoJoao.Nome = "João";
            donoJoao.Idade = 30;

            Dono donoMaria = new Dono();
            donoMaria.Nome = "Maria";
            donoMaria.Idade = 27;

            carro.Nome = "Uno";
            carro.Marca = "fiat";
            carro.AdicionarAntigoDono(donoJoao);
            carro.AdicionarAntigoDono(donoMaria);
            carro.Potencia = 1.4;

            carro2.Nome = "Uno";
            carro2.Marca = "Null";
            carro.AdicionarAntigoDono(donoJoao);
            carro.AdicionarAntigoDono(donoMaria);
            carro2.Potencia = 1.0;
            
            Console.WriteLine(carro.Nome);
            Console.WriteLine(carro.Marca);
            foreach (Dono dono in carro.GetAntigosDonos())
            {
                Console.WriteLine("{0} {1}", dono.Nome, dono.Idade);
            }
            Console.WriteLine(carro.Potencia);
            Console.WriteLine("Ligando o carro: {0} ", carro.Ligar());

            Console.WriteLine(carro.Marca.Equals(carro2.Marca));

            Console.ReadKey();

        }
    }
}
