using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blank.Domain.Security.Models;
using FluentNHibernate.Mapping;

namespace Blank.Application.Infrastructure.NHibernate.Maps
{
    public class GrupoMap : ClassMap<Grupo>
    {
        public GrupoMap() 
        {
            Id(g => g.Id).GeneratedBy.Identity();
            Map(g => g.Nome).Unique().Not.Nullable();
            Map(g => g.Descricao).Not.Nullable();
            Map(g => g.Inativo);
        }
    }
}