using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TI2Project.Models{

    public class AtoresFilmes{

        public int ID { get; set; }

        public string NomePersonagem { get; set; }

        [ForeignKey("Ator")]
        public int AtorFK { get; set; }
        public Atores Ator { get; set; }

        [ForeignKey("Filme")]
        public int FilmeFK { get; set; }
        public Filmes Filme { get; set; }
    }
}