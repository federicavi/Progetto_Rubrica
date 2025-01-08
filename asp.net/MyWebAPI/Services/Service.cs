using Prova_Rubrica.Models;
using Prova_Rubrica.Repositories;

namespace Prova_Rubrica.Services
{
    public class Service : IService
    {
        private readonly INumeriUtiliRepository _inumeriUtiliRepository;

        public Service(INumeriUtiliRepository numeriUtiliRepository)
        {
            _inumeriUtiliRepository = numeriUtiliRepository;
        }

        public async Task<List<NumeriUtili?>> GetNumeriList()
        {
           var listaNumeri = await _inumeriUtiliRepository.GetAll();
           return listaNumeri.ToList();
        }
    }
}
