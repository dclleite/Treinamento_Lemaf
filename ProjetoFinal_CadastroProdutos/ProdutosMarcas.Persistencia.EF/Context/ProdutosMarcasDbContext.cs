using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.ProdutosMarcas.Dominio;

namespace Treinamento.ProdutosMarcas.Persistencia.EF.Context
{
    public class ProdutosMarcasDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        public ProdutosMarcasDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                //Obrigatorio que um produto tenha uma marca
                .HasRequired(p => p.Marca)
                //Uma marca tem varios produtos
                .WithMany(p => p.Produtos)
                //ForeignKey
                .HasForeignKey(fk => fk.MarcaId)
                //Quando deletar um produto não deleta a marca"false", caso contrario "true"
                .WillCascadeOnDelete(false);
        }
    }
}
