using BusinessLogic.Contracts;
using Domain.Entities;
using DataAccess.Contracts;
using Domain.Exceptions;

namespace BusinessLogic.Services
{
    public class FruitService : IFruitService
    {
        private readonly IRepositoryWrapper _repository;

        public FruitService(IRepositoryWrapper re)
        {
            _repository = re;
        }

        public async Task<IEnumerable<Fruit>> GetAll()
        {
            var fruits = await _repository.Fruits.AllAsync();
            return fruits;
        }

        public async Task<Fruit> GetByIdAsync(string id)
        {
            var fruit = await _repository.Fruits.GetByIdAsync(id);

            if (fruit == null)
            {
                throw new NotFoundException("Fruit not found");
            }

            return fruit;
        }

        public async Task<Fruit> CreateAsync(Fruit entity)
        {
            ValidateFruit(entity);
            var createdFruit = await _repository.Fruits.CreateAsync(entity);
            await _repository.SaveAsync();

            return createdFruit;
        }

        public async Task<Fruit> UpdateAsync(Fruit entity)
        {
            ValidateFruit(entity);

            var existingFruit = await GetByIdAsync(entity.Id);

            existingFruit.Name = entity.Name;
            existingFruit.FruitType = entity.FruitType;
            existingFruit.Description = entity.Description;

            await _repository.Fruits.UpdateAsync(existingFruit);
            await _repository.SaveAsync();

            return existingFruit;
        }

        public async Task<string> DeleteAsync(string id)
        {
            var existingFruit = await GetByIdAsync(id);

            await _repository.Fruits.DeleteAsync(existingFruit.Id);
            await _repository.SaveAsync();

            return "";
        }

        private void ValidateFruit(Fruit fruit)
        {
            if (string.IsNullOrEmpty(fruit.Name))
            {
                throw new ValidationException("Name cannot be null or empty");
            }

            if (string.IsNullOrEmpty(fruit.FruitType.Name))
            {
                throw new ValidationException("Type cannot be null or empty");
            }
            bool lastItem = string.IsNullOrEmpty(fruit.Description) || fruit.Description.Length < 25;
            if (lastItem)
            {
                throw new ValidationException("Description cannot be null or empty; minimum length should be at least 25 characters");
            }

        }
    }

}
