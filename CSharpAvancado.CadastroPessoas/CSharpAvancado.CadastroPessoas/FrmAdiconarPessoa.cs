using CadastroPessoas.Dominio;
using CSharpAvancado.CadastroPessoas.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpAvancado.CadastroPessoas
{
    public partial class FrmAdiconarPessoa : Form
    {
        public FrmAdiconarPessoa()
        {
            InitializeComponent();
        }

        private void FrmAdiconarPessoa_Load(object sender, EventArgs e)
        {

        }

        private void dtnSalvar_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa
            {
                Nome = txbNome.Text,
                Idade = Convert.ToInt32(txbIdade.Text),
                Endereco = txbEndereco.Text
            };
            IRepositorio<Pessoa> repositorioPessoas = new PessoaRepositorio();
            repositorioPessoas.Adicionar(pessoa);
            Close();

        }
    }
}
