using DataAccess.Contracts;

namespace DataAccess.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private FruitContext _repoContext;
        private IFruitRepository _fruits;
        private IFruitTypeRepository _fruitTypes;

     public IFruitRepository Fruits => _fruits ??= new FruitRepository(_repoContext);

     public IFruitTypeRepository FruitTypes => _fruitTypes ??= new FruitTypeRepository(_repoContext);

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
