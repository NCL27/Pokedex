using Pokedex.Core.Application.ViewModels.Region;
using Pokedex.Core.Application.ViewModels.Type;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels.Pokemon
{
    public class SavePokeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocarle un nombre al pokemon")]
        public string Name { get; set; } = string.Empty;
       
        public string? ImgUrl { get; set; } = string.Empty;

        public string? Caracteristica { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Debe colocarle un tipo al pokemon")]
        public int TypeId { get; set; }
        public List<TypeViewModel>? Types { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe colocarle una region al pokemon")]
        public int RegionId { get; set; }
        public List<RegiViewModel>? Regions { get; set; }
        
    }
}
