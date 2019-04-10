using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaContatosTreinaWeb
{
    public partial class frmAgendaContatos : Form
    {
        private OpecaraoEnum acao;
        public frmAgendaContatos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbxContatos.SelectedIndex;
            Contato contato = (Contato)lbxContatos.Items[index];
            txbNome.Text = contato.Nome;
            txbEmail.Text = contato.Email;
            txbNumeroTelefone.Text = contato.NumeroTelefone;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmAgendaContatos_Shown(object sender, EventArgs e)
        {
            AlterarBotoesSalvarECancelar(false);
            AlterarBotoesIncluirAlterarExcluir(true);
            CarregarListaContatos();
            AlterarEstadoCampos(false);
        }

        private void AlterarBotoesSalvarECancelar(bool estado)
        {
            btnSalvar.Enabled = estado;
            btnCancelar.Enabled = estado;
        }

        private void AlterarBotoesIncluirAlterarExcluir(bool estado){
            btnIncluir.Enabled = estado;
            btnAlterar.Enabled = estado;
            btnExcluir.Enabled = estado;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            AlterarBotoesSalvarECancelar(true);
            AlterarBotoesIncluirAlterarExcluir(false);
            AlterarEstadoCampos(true);
            acao = OpecaraoEnum.INCLUIR;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AlterarBotoesSalvarECancelar(true);
            AlterarBotoesIncluirAlterarExcluir(false);
            AlterarEstadoCampos(true);
            acao = OpecaraoEnum.ALTERAR;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AlterarBotoesSalvarECancelar(false);
            AlterarBotoesIncluirAlterarExcluir(true);
            AlterarEstadoCampos(false);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato
            {
                Nome = txbNome.Text,
                Email = txbEmail.Text,
                NumeroTelefone = txbNumeroTelefone.Text
            };
            List<Contato> contatoList = new List<Contato>();
            foreach (Contato contatoDaLista in lbxContatos.Items)
            {
                contatoList.Add(contatoDaLista);
            }
    
            if (acao == OpecaraoEnum.INCLUIR)
            {
                contatoList.Add(contato);
            }
            else
            {
                int indice = lbxContatos.SelectedIndex;
                contatoList.RemoveAt(indice);
                contatoList.Insert(indice, contato);
            }
            ManipuladorArquivos.EscreverArquivo(contatoList);
            CarregarListaContatos();
            AlterarBotoesSalvarECancelar(false);
            AlterarBotoesIncluirAlterarExcluir(true);
            LimparCampos();
            AlterarEstadoCampos(false);
        }

        private void CarregarListaContatos()
        {
            lbxContatos.Items.Clear();
            lbxContatos.Items.AddRange(ManipuladorArquivos.LerArquivo().ToArray());

        }
        private void LimparCampos()
        {
            txbNome.Text = "";
            txbEmail.Text = "";
            txbNumeroTelefone.Text = "";
        }

        private void AlterarEstadoCampos(bool estado)
        {
            txbNome.Enabled = estado;
            txbEmail.Enabled = estado;
            txbNumeroTelefone.Enabled = estado;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza?", "Pergunta", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int indiceExcluir = lbxContatos.SelectedIndex;
                lbxContatos.SelectedIndex = 0;
                lbxContatos.Items.RemoveAt(indiceExcluir);
                List<Contato> contatoList = new List<Contato>();
                foreach (Contato contato in lbxContatos.Items)
                {
                    contatoList.Add(contato);
                }
                ManipuladorArquivos.EscreverArquivo(contatoList);
                CarregarListaContatos();
                LimparCampos();
            }
        }
    }
}
