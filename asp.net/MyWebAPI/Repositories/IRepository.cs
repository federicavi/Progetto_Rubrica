namespace Prova_Rubrica.Repositories;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T?>> GetAll();
    Task<T?> GetById(int id);
    Task Add(T value);
    Task Update(T value, int id);
    Task Delete(int id);

}
