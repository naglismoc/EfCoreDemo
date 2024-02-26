using DataAcccess.Entities;
using DataAcccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace EfCoreDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var dbcf = new SakilaDBContextFactory();
            using var context = dbcf.CreateDbContext(args);
            var actors = await context.Actors.ToListAsync();
            foreach (var actor1 in actors)
            {
                //       await Console.Out.WriteLineAsync(actor1.LastUpdate.ToString("yyyy:MM:dd HH:mm:ss"));
            }
            var films = await context.Films.ToListAsync();
            //foreach (var film in films)
            //{
            //    foreach (var actor in film.Actors)
            //    {
            //        await Console.Out.WriteLineAsync("-- " + actor.FirstName);
            //    }
            //    await Console.Out.WriteLineAsync(film.Title);
            //}


            var actorRepository = new ActorRepository(context);
            await AddActor(actorRepository);
            //  await GetActor(actorRepository);
        }
        //read
        private static async Task GetActor(ActorRepository repository)
        {
            var actor = await repository.ReadAsync(20);
        }
        //create
        private static async Task AddActor(ActorRepository repository)
        {
            var actor = new Actor()
            {
                FirstName = "labas",
                LastName = "labas2"
            };
            await repository.CreateAsync(actor);
        }
    }
}
