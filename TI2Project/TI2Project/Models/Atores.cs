using System;
using System.Collections.Generic;
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

        public string Nome { get; set; }

        public string Nascimento { get; set; }

        public string Nacionalidade { get; set; }

        public string Foto { get; set; }

        public virtual ICollection<AtoresFilmes> ListaDePersonagens { get; set; } //personagens interpretadas pelo ator
    }
}