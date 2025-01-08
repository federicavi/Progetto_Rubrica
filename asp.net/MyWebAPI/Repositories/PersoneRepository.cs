using Microsoft.EntityFrameworkCore;
using Prova_Rubrica.ContextDb;
using Prova_Rubrica.Models;

namespace Prova_Rubrica.Repositories
{
    public class PersoneRepository : IPersoneRepository
    {
        private readonly ProvaRubricaContext _context;

        public PersoneRepository(ProvaRubricaContext context)
        {
            _context = context;
        }

        public async Task Add(Persone persona)
        {
             _context.Persones.Add(persona);
             await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Persone? persona = await GetById(id);
            if (persona != null)
            {
                _context.Persones.Remove(persona);
            }
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Persone?>> GetAll()
        {
            return await _context.Persones.ToListAsync();       
        }

        public async Task<Persone?> GetById(int id)
        {
            Persone? persona = await _context.Persones.Where(p => p.Id == id).FirstOrDefaultAsync();
            return persona;
        }

        public async Task Update(Persone update, int id)
        {
            Persone? personaDaModificare = await GetById(id);

            if(personaDaModificare != null)
            {
                personaDaModificare.Name = update.Name;
                personaDaModificare.Surname = update.Surname;
                _context.Persones.Update(personaDaModificare);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<int?>  GetIdByName(string name, string surname) 
        {
            
            var persona = await _context.Persones.Where(p => p.Name == name && p.Surname == surname).FirstOrDefaultAsync();
            return persona?.Id;

        }
    }
}
