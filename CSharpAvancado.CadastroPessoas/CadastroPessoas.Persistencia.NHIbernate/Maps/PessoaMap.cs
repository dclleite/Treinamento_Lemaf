using CadastroPessoas.Dominio;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoas.Persistencia.NHIbernate.Maps
{
    public class PessoaMap : ClassMapping<Pessoa>
    {
        public PessoaMap()
        {
            Schema("dbo");
            Table("Pessoas");
            Id(pk => pk.Id, (map) => { map.Generator(Generators.Identity); });
            Property(p => p.Nome);
            Property(p => p.Idade);
            Property(p => p.Endereco);

        }
    }
}
