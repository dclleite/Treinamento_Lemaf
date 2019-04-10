using CadastroPessoas.Dominio;
using CadastroPessoas.Persistencia.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAvancado.CadastroPessoas.Repositorio
{
    public class PessoaRepositorio : IRepositorio<Pessoa>
    {
        public List<Pessoa> SelecionarTodos()
        {
            CadastroPessoasDbContext contexto = new CadastroPessoasDbContext();
            List<Pessoa> pessoas = contexto.Pessoas.OrderBy(o => o.Nome).ToList();
            //Dispose mata a conexão com banco de dados
            contexto.Dispose();
            return pessoas;

        }
        public int Adicionar(Pessoa objeto)
        {
            CadastroPessoasDbContext contexto = new CadastroPessoasDbContext();
            contexto.Pessoas.Add(objeto);
            // Save changes faz o insert into ... ele tambem retorna um numero inteiro de quantos objetos foram inseridos, por isso meu metodo retorna um int 
            return contexto.SaveChanges();
        }


    }
}
