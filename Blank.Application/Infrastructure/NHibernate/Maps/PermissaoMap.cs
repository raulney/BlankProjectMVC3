using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using Blank.Domain.Security.Models;

namespace Blank.Application.Infrastructure.NHibernate.Maps
{
    public class PermissaoMap : ClassMap<Permissao>
    {
        public PermissaoMap()
        {
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.Metodo).Not.Nullable();
            Map(p => p.Descricao).Not.Nullable();
            Map(p => p.ValidacaoObrigatoria);
            References(p => p.Interface).Not.Nullable();
        }
    }
}