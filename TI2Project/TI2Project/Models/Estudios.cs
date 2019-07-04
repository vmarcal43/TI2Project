using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TI2Project.Models{

    public class Estudios{
        public Estudios()
        {

            ListaDeFilmes= new HashSet<Filmes>();
            
        }

        public int ID { get; set; }

        public string Nome { get; set; }

        public string Imagem { get; set; }

        public virtual ICollection<Filmes> ListaDeFilmes { get; set; }
    }
}