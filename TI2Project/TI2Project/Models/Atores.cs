using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TI2Project.Models{

    public class Atores{

        public Atores()
        {
            ListaDePersonagens = new HashSet<AtoresFilmes>();
        }

        //atributos de cada ator: id, nome, data de nascimento, nacionalidade e fotografia
        public int ID { get; set; }

        [Required(ErrorMessage = "Write actor's name.")]
        [Display(Name = "Name")]
        public string Nome { get; set; }

        [Display(Name = "Birth Date")]
        public string Nascimento { get; set; }

        [Display(Name = "Nationality")]
        public string Nacionalidade { get; set; }

        [Display(Name = "Photo")]
        public string Foto { get; set; }

        public virtual ICollection<AtoresFilmes> ListaDePersonagens { get; set; } //personagens interpretadas pelo ator
    }
}