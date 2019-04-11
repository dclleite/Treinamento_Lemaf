using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Treinamento.ProdutosMarcas.Apresentacao.VIewModels;
using Treinamento.ProdutosMarcas.Dominio;
using Treinamento.ProdutosMarcas.Repositorio.EF;
using Treinamento.Repositorio.Comum;

namespace Treinamento.ProdutosMarcas.Apresentacao
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            PreencherDataGridViewMarcasAsync();
            PreencherDataGridViewProdutossAsync();
        }
        private async void PreencherDataGridViewMarcasAsync()
        {
            IRepositorioGenerico<Marca> repositorioMarcas = new RepositorioMarca();
            List<Marca> marcas = await repositorioMarcas.SelecionarTodos();
            List<MarcaViewModel> marcaViewModels = new List<MarcaViewModel>();
            foreach (Marca marca in marcas)
            {
                MarcaViewModel viewModel = new MarcaViewModel()
                {
                    Id = marca.Id,
                    Nome = marca.Nome
                };
                marcaViewModels.Add(viewModel);
            }
            dgvMarcas.Invoke((MethodInvoker)delegate
            {
                dgvMarcas.DataSource = marcaViewModels;
                dgvMarcas.Refresh();
            });
        }
        private async void PreencherDataGridViewProdutossAsync()
        {
            IRepositorioGenerico<Produto> repositorioProduto = new RepositorioProduto();
            List<Produto> produtos = await repositorioProduto.SelecionarTodos();
            List<ProdutoViewModel> produtoViewModels = new List<ProdutoViewModel>();
            foreach (Produto produto in produtos)
            {
                ProdutoViewModel viewModel = new ProdutoViewModel()
                {
                    Id = produto.Id,
                    Marca = produto.Marca.Nome,
                    MarcaId = produto.Marca.Id,
                    Nome = produto.Nome
                };
                produtoViewModels.Add(viewModel);
            }
            dgvProdutos.Invoke((MethodInvoker)delegate
            {
                dgvProdutos.DataSource = produtoViewModels;
                dgvProdutos.Refresh();
            });
        }
    }
}
