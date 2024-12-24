using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Pokemons
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Caracteristica { get; set; }
        public int TypeId { get; set; }
        public int RegionId { get; set; }

        //navegation property
        public Regions Regions { get; set; }
        public Types Types { get; set; }
    }
}
