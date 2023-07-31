using BusinessLogic.Contracts;
using DataAccess.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class FruitTypeService : IFruitTypeService
    {
        private readonly IRepositoryWrapper _repository;

        public FruitTypeService(IRepositoryWrapper re)
        {
            _repository = re;
        }

        public async Task<IEnumerable<FruitType>> GetAll()
        {

            var fruits = await _repository.FruitTypes.AllAsync();
            return fruits;
        }
    }
}
