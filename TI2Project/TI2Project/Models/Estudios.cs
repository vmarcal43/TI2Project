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

        [Required(ErrorMessage = "Escreva o nome do estúdio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira uma imagem.")]
        public string Imagem { get; set; }

        public virtual ICollection<Filmes> ListaDeFilmes { get; set; } //filmes produzidos pelo estúdio
    }
}