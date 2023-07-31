
using Domain.Entities;
namespace BusinessLogic.Contracts
{
    public interface IFruitService
    {
        Task<IEnumerable<Fruit>> GetAll();

        Task<Fruit> GetByIdAsync(string id);
        Task<Fruit> CreateAsync(Fruit entity);
        Task<Fruit> UpdateAsync(Fruit entity);
        Task<string> DeleteAsync(string id);

    }
}
