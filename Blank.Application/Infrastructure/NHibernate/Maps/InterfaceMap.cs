using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using Blank.Domain.Security.Models;

namespace Blank.Application.Infrastructure.NHibernate.Maps
{
    public class InterfaceMap : ClassMap<Interface>
    {
        public InterfaceMap()
        {
            Id(i => i.Id).GeneratedBy.Identity();
            Map(i => i.Controle).Unique().Not.Nullable();
            Map(i => i.Descricao).Not.Nullable();
            Map(i => i.ValidacaoObrigatoria);
            HasMany(i => i.Permissoes).Cascade.SaveUpdate();
        }
    }
}