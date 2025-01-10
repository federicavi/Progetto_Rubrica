using Prova_Rubrica.Models;

namespace Prova_Rubrica.Services
{
    public interface IService
    {
        Task<List<NumeriUtili?>> GetNumeriList();

        Task<List<Persone?>> GetPersoneList();
    }
}
