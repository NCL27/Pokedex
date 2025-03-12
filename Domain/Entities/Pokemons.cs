using Pokedex.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Domain.Entities
{
    public class Pokemons : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Caracteristica { get; set; }

        //Id
        public int TypeId { get; set; }
        public int RegionId { get; set; }

        //navegation property
        public Regions Regions { get; set; }
        public Types Types { get; set; }
    }
}
