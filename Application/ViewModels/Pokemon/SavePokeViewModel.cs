using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Pokemon
{
    public class SavePokeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocarle un nombre al pokemon")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe colocarle una caracteristica al pokemon")]
        public string ImgUrl { get; set; }

        [Required(ErrorMessage = "Debe colocarle una imagen al pokemon")]
        public string Caracteristica { get; set; }

        [Required(ErrorMessage = "Debe colocarle un tipo al pokemon")]
        public int TypeId { get; set; }

        [Required(ErrorMessage = "Debe colocarle una region al pokemon")]
        public int RegionId { get; set; }
    }
}
