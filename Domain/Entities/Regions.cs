using Pokedex.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Domain.Entities
{
    public class Regions : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }

        //navegation property
        public ICollection<Pokemons> Pokemons { get; set; }
    }
}
