using Prova_Rubrica.Models;
using Prova_Rubrica.Repositories;

namespace Prova_Rubrica.Services
{
    public class Service : IService
    {
        private readonly INumeriUtiliRepository _inumeriUtiliRepository;
        private readonly IPersoneRepository _personeRepository;

        public Service(INumeriUtiliRepository numeriUtiliRepository, IPersoneRepository personeRepository)
        {
            _inumeriUtiliRepository = numeriUtiliRepository;
            _personeRepository = personeRepository;
        }

        public async Task<List<NumeriUtili?>> GetNumeriList()
        {
           var listaNumeri = await _inumeriUtiliRepository.GetAll();
           return listaNumeri.ToList();
        }

        public async Task<List<Persone?>> GetPersoneList()
        {
            var listaPersone = await _personeRepository.GetAll();
            return listaPersone.ToList();
        }
    }
}
