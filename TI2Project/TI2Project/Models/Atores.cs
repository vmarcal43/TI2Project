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

        [Required(ErrorMessage = "Escreva o nome do autor.")]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        public string Nascimento { get; set; }

        public string Nacionalidade { get; set; }

        [Required(ErrorMessage = "Insira uma imagem.")]
        [Display(Name = "Fotografia")]
        public string Foto { get; set; }

        public virtual ICollection<AtoresFilmes> ListaDePersonagens { get; set; } //personagens interpretadas pelo ator
    }
}