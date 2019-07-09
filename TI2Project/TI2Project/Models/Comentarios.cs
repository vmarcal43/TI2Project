using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TI2Project.Models{

    public class Comentarios{

        //atributos de cada comentario, id, conteúdo e data
        public int ID { get; set; }

        public string Conteudo { get; set; }

        public DateTime? Data { get; set; } //momento em que o comentário foi criado ou editado pela última vez, guardado automaticamente

        //chave forasteira do filme a que pertence o comentário
        [ForeignKey("Filme")]
        public int FilmeFK { get; set; }
        public virtual Filmes Filme { get; set; }
    }
}