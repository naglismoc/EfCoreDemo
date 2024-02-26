using DataAcccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcccess
{
    public class SakilaDBContext : DbContext
    {
        public SakilaDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmActor> FilmActors { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //       modelBuilder.Entity<FilmActor>()
        //    //.HasKey("film_actor(actor_id)", "film_actor(film_id)"); // Composite primary key using existing columns

        //    modelBuilder.Entity<FilmActor>()
        //        .HasKey(fa => new { fa.FilmId, fa.ActorId });
        //}
    }

}
