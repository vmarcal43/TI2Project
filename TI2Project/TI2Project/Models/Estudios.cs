using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TI2Project.Models{

    public class Estudios{
        public Estudios()
        {
            ListaDeFilmes= new HashSet<Filmes>();
        }

        //atributos de cada estúdio: id, nome e imagem
        public int ID { get; set; }

        [Required(ErrorMessage = "Write studio's name.")]
        [Display(Name = "Name")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insert an Image.")]
        [Display(Name = "Image")]
        public string Imagem { get; set; }

        public virtual ICollection<Filmes> ListaDeFilmes { get; set; } //filmes produzidos pelo estúdio
    }
}