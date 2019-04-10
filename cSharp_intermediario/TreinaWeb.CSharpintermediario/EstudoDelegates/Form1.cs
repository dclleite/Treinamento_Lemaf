using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstudoDelegates
{
    public partial class frmCalculadora : Form
    {
        private delegate int ExecutarOperacao(int n1, int n2);
        private ExecutarOperacao minhaOperacao;
        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmCalculadora_Load(object sender, EventArgs e)
        {

        }

        private int Calcular()
        {
            int n1 = Convert.ToInt32(txbNumero1.Text);
            int n2 = Convert.ToInt32(txbNumero2.Text);
            return minhaOperacao(n1, n2);
        }

        private int Somar(int n1, int n2)
        {
            return n1 + n2;
        }

        private int Subtrair(int n1, int n2)
        {
            return n1 - n2;
        }

        private int Multiplicar(int n1, int n2)
        {
            return n1 * n2;
        }

        private int Dividir(int n1, int n2)
        {
            return n1 / n2;
        }

        private void btnAdicao_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutarOperacao(Somar);
            txbResultado.Text = Calcular().ToString();
        }

        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutarOperacao(Subtrair);
            txbResultado.Text = Calcular().ToString();
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutarOperacao(Multiplicar);
            txbResultado.Text = Calcular().ToString();
        }

        private void btnDivisão_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutarOperacao(Dividir);
            txbResultado.Text = Calcular().ToString();
        }
    }
}
