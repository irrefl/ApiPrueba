using DataAccess.Contracts;

namespace DataAccess.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private FruitContext _repoContext;
        private IFruitRepository _fruits;
        private IFruitTypeRepository _fruitTypes;

        public IFruitRepository Fruits
        {
            get
            {
                if (_fruits == null)
                {
                    _fruits = new FruitRepository(_repoContext);
                }
                return _fruits;
            }
        }

        public IFruitTypeRepository FruitTypes
        {
            get
            {
                if (_fruitTypes == null)
                {
                    _fruitTypes = new FruitTypeRepository(_repoContext);
                }
                return _fruitTypes;
            }
        }

        public RepositoryWrapper(FruitContext r)
        {
            _repoContext = r;
        }
        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
