using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OMD.Models{

    public class Comentarios{

        public int ID { get; set; }

        public string Conteudo { get; set; }

        public DateTime Data { get; set; }

        [ForeignKey("Filme")]
        public int FilmeFK { get; set; }
        public Filmes Filme { get; set; }
    }
}