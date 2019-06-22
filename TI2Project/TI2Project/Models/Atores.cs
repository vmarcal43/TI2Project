using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMD.Models{

    public class Atores{

        public int ID { get; set; }

        public string Nome { get; set; }

        public DateTime? Nascimento { get; set; }

        public string Nacionalidade { get; set; }

        public string Foto { get; set; }

        public virtual ICollection<AtoresFilmes> ListaDePersonagens { get; set; }
    }
}