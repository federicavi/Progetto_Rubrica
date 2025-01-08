using Microsoft.EntityFrameworkCore;
using Prova_Rubrica.ContextDb;
using Prova_Rubrica.Models;

namespace Prova_Rubrica.Repositories
{
    public class NumeriUtiliRepository : INumeriUtiliRepository
    {
        private readonly ProvaRubricaContext _context;
        public NumeriUtiliRepository(ProvaRubricaContext context) 
        {
            _context = context;
        }
        public async Task Add(NumeriUtili numero)
        {
             _context.NumeriUtilis.Add(numero);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            NumeriUtili? numero = await GetById(id);

            //bool presente = await _context.NumeriUtilis.AnyAsync(n => n.Id == id); capire come istanziare il contesto nel program in modo da averlo visibile su tutta l'applicazione

            if (numero != null)
            {
                 _context.NumeriUtilis.Remove(numero);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<NumeriUtili?>> GetAll()
        {
            var listaNumeri = await _context.NumeriUtilis.ToListAsync();
            return listaNumeri;
        }

        public async Task<NumeriUtili?> GetById(int id)
        {
            NumeriUtili? numeroUtile = await _context.NumeriUtilis.Where( n => n.Id == id).FirstOrDefaultAsync();
            return numeroUtile;
        }

        public async Task Update(NumeriUtili nuovoNum, int id)
        {
            NumeriUtili? numeroDaModificare = await GetById(id);

            if(numeroDaModificare != null)
            {
                numeroDaModificare.Name = nuovoNum.Name;
                numeroDaModificare.Number = nuovoNum.Number;
                _context.NumeriUtilis.Update(numeroDaModificare);
            }
            
            await _context.SaveChangesAsync();
        }
    }
}
