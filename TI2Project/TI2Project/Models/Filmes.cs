using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TI2Project.Models{

    public class Filmes{

        public Filmes()
        {
            ListaDePersonagens = new HashSet<AtoresFilmes>();
            ListaDeComentarios = new HashSet<Comentarios>();
        }

        //atributos de cada filme: id, titulo, imagem, trailer, ano de lançamento, género e duração (em minutos)
        public int ID { get; set; }

        [Required(ErrorMessage = "Write the movie's name.")]
        [Display(Name = "Title")]
        public string Titulo { get; set; }

        [Display(Name = "Image")]
        public string Imagem { get; set; }

        public string Trailer { get; set; } //id correspondente ao video no youtube

        [Display(Name = "Release Year")]
        [Required(ErrorMessage = "Release year is needed.")]
        public int Lancamento { get; set; }

        [Display(Name = "Genre")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Movie length is needed.")]
        [Display(Name = "Duration (in mins)")]
        public int Duracao { get; set; }

        //chave forasteira do estúdio que produziu o filme
        [ForeignKey("Estudio")]
        public int EstudioFK { get; set; }
        public virtual Estudios Estudio { get; set; }

        public virtual ICollection<AtoresFilmes> ListaDePersonagens { get; set; } //personagens que aparecem no filme

        public virtual ICollection<Comentarios> ListaDeComentarios { get; set; } //comentários acerca do filme
    }
}