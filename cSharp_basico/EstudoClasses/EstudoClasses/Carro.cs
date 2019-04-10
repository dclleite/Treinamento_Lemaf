using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoClasses
{
    public class Carro : Veiculo
    {


        public int NumeroPortas { get; set; }

        private List<Dono> antigosDonos;

        public void AdicionarAntigoDono(Dono dono)
        {
            antigosDonos.Add(dono);
        }

        public List<Dono> GetAntigosDonos()
        {
            return antigosDonos;
        }

        //Construtor 
        public Carro()
        {
            this.antigosDonos = new List<Dono>();
            // inicalizar propiedas com valores padrão
            this.NumeroPortas = 4;
        }
        public override string Ligar()
        {
            return "O Carro está ligado";
        }

        public override string Desligar()
        {
            return "O carro está desligado";
        }

        public override string Abastecer()
        {
            return "O carro esta abastecido";
        }
    }
}
