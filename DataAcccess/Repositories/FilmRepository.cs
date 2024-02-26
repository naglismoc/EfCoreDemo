using DataAcccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcccess.Repositories
{
    public class FilmRepository
    {
        private readonly SakilaDBContext _context;
        public FilmRepository(SakilaDBContext context)
        {
            _context = context;
        }
        //CRUD

        //CREATE
        public async Task CreateAsync(Film film)
        {
            _context.Films.Add(film);
            await _context.SaveChangesAsync();
        }
        public async Task<Film> ReadAsync(int id)
        {
            return await _context.Films
                // .Include(f => f.Actors)
                //Include(a => a.KitasTeiblas) // paima su child bet reikia objektineje klaseje tureti public Child child get set bei public int ChildId get; private set IR private construktoriu. 25 1:15
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateAsync(Film film)
        {
            var existingFilm = await _context.Films.FindAsync(film.Id);
            if (existingFilm == null)
            {
                throw new KeyNotFoundException($"Film with ID{film.Id} not found.");
            }
            _context.Entry(existingFilm).CurrentValues.SetValues(film);
            await _context.SaveChangesAsync();
            // _context.Update(film);
        }

        public async Task DeleteAsync(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                throw new KeyNotFoundException($"Film with ID{film.Id} not found.");
            }
            _context.Films.Remove(film);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Film>> ReadAll()
        {

            return await _context.Films
                .Include(f => f.FilmActors)
                    .ThenInclude(fa => fa.Actor)
                .ToListAsync();
        }
    }
}
