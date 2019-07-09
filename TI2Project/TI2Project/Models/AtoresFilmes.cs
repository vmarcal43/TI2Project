using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TI2Project.Models{

    public class AtoresFilmes{

        //atributos de cada personagem: id e nome
        public int ID { get; set; }

        public string NomePersonagem { get; set; }

        //chave forasteira do ator que interpreta a personagem
        [ForeignKey("Ator")]
        public int AtorFK { get; set; }
        public virtual Atores Ator { get; set; }

        //chave forasteira do filme em que aparece a personagem
        [ForeignKey("Filme")]
        public int FilmeFK { get; set; }
        public virtual Filmes Filme { get; set; }
    }
}