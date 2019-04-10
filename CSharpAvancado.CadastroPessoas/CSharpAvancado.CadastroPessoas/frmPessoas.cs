using CadastroPessoas.Dominio;
using CSharpAvancado.CadastroPessoas.Repositorio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSharpAvancado.CadastroPessoas
{
    public partial class FrmPessoas : Form
    {
        public FrmPessoas()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PreencherDataGridView();

        }

        private void PreencherDataGridView()
        {
            IRepositorio<Pessoa> repositorioPessoas = new PessoaRepositorio();
            List<Pessoa> pessoas = repositorioPessoas.SelecionarTodos();
            dgvPessoas.DataSource = pessoas;
            dgvPessoas.Refresh();

        }

        private void btnAdicionarPessoa_Click(object sender, EventArgs e)
        {
            FrmAdiconarPessoa frmAdiconarPessoa = new FrmAdiconarPessoa();
            frmAdiconarPessoa.ShowDialog();
            PreencherDataGridView();
        }


    }
}
