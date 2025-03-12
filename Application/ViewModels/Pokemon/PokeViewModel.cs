using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels.Pokemon
{
    public class PokeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Caracteristica { get; set; }


        public string TypeName { get; set; }
        public string RegionName { get; set; }
        public int RegionId{ get; set; }
    }
}