using DataAcccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcccess.Repositories
{
    public class ActorRepository
    {
        private readonly SakilaDBContext _context;
        public ActorRepository(SakilaDBContext context)
        {
            _context = context;
        }
        //CRUD

        //CREATE
        public async Task CreateAsync(Actor actor)
        {
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();
        }
        public async Task<Actor> ReadAsync(int id)
        {
            return await _context.Actors.
                //Include(a => a.KitasTeiblas) // paima su child bet reikia objektineje klaseje tureti public Child child get set bei public int ChildId get; private set IR private construktoriu. 25 1:15
                FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateAsync(Actor actor)
        {
            var existingActor = await _context.Actors.FindAsync(actor.Id);
            if (existingActor == null)
            {
                throw new KeyNotFoundException($"Actor with ID{actor.Id} not found.");
            }
            _context.Entry(existingActor).CurrentValues.SetValues(actor);
            await _context.SaveChangesAsync();
            // _context.Update(actor);
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if (actor == null)
            {
                throw new KeyNotFoundException($"Actor with ID{actor.Id} not found.");
            }
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Actor>> ReadAll()
        {
            return await _context.Actors.ToListAsync();
        }
    }
}
