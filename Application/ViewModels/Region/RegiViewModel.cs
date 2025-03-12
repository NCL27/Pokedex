using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels.Region
{
    public class RegiViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }

        //Para saber cuantos pokemones tiene una region
        public int PokemonsQuantity {  get; set; }  
    }
}
