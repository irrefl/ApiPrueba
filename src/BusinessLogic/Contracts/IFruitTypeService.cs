using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Contracts
{
    public interface IFruitTypeService
    {
        Task<IEnumerable<FruitType>> GetAll();
        /*
        Task<FruitType> GetByIdAsync(string id);
        Task<FruitType> CreateAsync(FruitType entity);
        Task<FruitType> UpdateAsync(FruitType entity);
        Task<string> DeleteAsync(string id);

        */
    }
}
