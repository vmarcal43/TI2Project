namespace TI2Project.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TI2Project.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TI2Project.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TI2Project.Models.ApplicationDbContext";
        }

        protected override void Seed(TI2Project.Models.ApplicationDbContext context)
        {

            var estudios = new List<Estudios>
            {
                new Estudios {Nome="Marvel Studios", Imagem="marvel.png"},

            };
            estudios.ForEach(dd => context.Estudios.AddOrUpdate(d => d.Nome, dd));
            context.SaveChanges();


            var filmes = new List<Filmes>
            {
                new Filmes {Titulo="Avengers: Age of Ultron", Duracao=141, Lancamento=2015,Imagem="Avengers1.jpg", Trailer="tmeOjFno6Do",Genero="Action", EstudioFK=1},
                new Filmes {Titulo="Avengers: Endgame", Duracao=181, Lancamento=2019,Imagem="Avengers2.jpg", Trailer="hA6hldpSTF8",Genero="Action", EstudioFK=1, },


            };

            filmes.ForEach(dd => context.Filmes.AddOrUpdate(d => d.Titulo, dd));
            context.SaveChanges();

            var atores = new List<Atores>
            {
                new Atores {Nome="Chris Evans", Nacionalidade="American", Foto="ChrisEvans.jfif"  },
                new Atores {Nome="Chris Hemsworth", Nacionalidade="Australian",  Foto="ChrisHemsworth.jfif" },
                new Atores {Nome="Robert Downey Jr.", Nacionalidade="American",  Foto="RobertDowneyJR.jfif" }


            };
            atores.ForEach(dd => context.Atores.AddOrUpdate(d => d.Nome, dd));
            context.SaveChanges();



            var atoresFilmes = new List<AtoresFilmes>
            {
                new AtoresFilmes {NomePersonagem="Captain America", AtorFK=1, FilmeFK=1},              
                new AtoresFilmes {NomePersonagem="Thor", AtorFK=2, FilmeFK=1},              
                new AtoresFilmes {NomePersonagem="Iron Man", AtorFK=3, FilmeFK=1},
                new AtoresFilmes {NomePersonagem="Captain America", AtorFK=1, FilmeFK=2},
                new AtoresFilmes {NomePersonagem="Thor", AtorFK=2, FilmeFK=2},
                new AtoresFilmes {NomePersonagem="Iron Man", AtorFK=3, FilmeFK=2}


            };
            atoresFilmes.ForEach(dd => context.AtoresFilmes.AddOrUpdate(d => d.NomePersonagem, dd));
            context.SaveChanges();


            var comentarios = new List<Comentarios>
            {
                new Comentarios {Conteudo="good", FilmeFK=1},
                new Comentarios {Conteudo="very godd", FilmeFK=1},
                new Comentarios {Conteudo="best movie ever", FilmeFK=1},
                new Comentarios {Conteudo="good", FilmeFK=2},
                new Comentarios {Conteudo="very godd", FilmeFK=2},
                new Comentarios {Conteudo="best movie ever", FilmeFK=2}

            };
            comentarios.ForEach(dd => context.Comentarios.AddOrUpdate(d => d.Conteudo, dd));
            context.SaveChanges();







        }
    }
}
