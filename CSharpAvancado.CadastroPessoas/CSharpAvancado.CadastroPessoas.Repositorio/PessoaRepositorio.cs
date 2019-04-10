using CadastroPessoas.Dominio;
using CadastroPessoas.Persistencia.EF;
using CadastroPessoas.Persistencia.NHIbernate.Maps;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAvancado.CadastroPessoas.Repositorio
{
    public class PessoaRepositorio : IRepositorio<Pessoa>
    {
        private NHibernate.ISessionFactory _sessionFactory;

        public PessoaRepositorio()
        {
            Configuration config = new Configuration();
            config.Configure();
            //Assembly para esse caso não fara nada, pois ele procura um arquivo xml onde contem os mapeamentos
            config.AddAssembly(typeof(Pessoa).Assembly);
            HbmMapping mapping = CreateMappings();
            config.AddDeserializedMapping(mapping, null);
            _sessionFactory = config.BuildSessionFactory();
        }

        private HbmMapping CreateMappings()
        {
            ModelMapper mapper = new ModelMapper();
            mapper.AddMapping(typeof(PessoaMap));
            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }

        public List<Pessoa> SelecionarTodos()
        {
            // Entity Framework
            /*CadastroPessoasDbContext contexto = new CadastroPessoasDbContext();
            List<Pessoa> pessoas = contexto.Pessoas.OrderBy(o => o.Nome).ToList();
            //Dispose mata a conexão com banco de dados
            contexto.Dispose();
            return pessoas;
            */
            // NHibernate
            using(ISession sessao = _sessionFactory.OpenSession())
            {
                IQuery consulta = sessao.CreateQuery("FROM Pessoa");
                //var consulta = sessao.Query<Pessoa>();
                return consulta.List<Pessoa>().ToList();
            }
        }
        public int Adicionar(Pessoa objeto)
        {
            // Entity Framework

            /*CadastroPessoasDbContext contexto = new CadastroPessoasDbContext();
            contexto.Pessoas.Add(objeto);
            // Save changes faz o insert into ... ele tambem retorna um numero inteiro de quantos objetos foram inseridos, por isso meu metodo retorna um int 
            return contexto.SaveChanges();
            */

            // NHibernate

            using (ISession sessao = _sessionFactory.OpenSession())
            {
                using (var transacao = sessao.BeginTransaction())
                {
                    sessao.Save(objeto);
                    transacao.Commit();
                    return 0;
                }
                
            }
        }


    }
}
