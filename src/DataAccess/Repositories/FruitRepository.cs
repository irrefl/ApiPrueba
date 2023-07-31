using DataAccess.Contracts;
using Domain.Entities;

namespace DataAccess.Repositories
{
    public class FruitRepository : Repository<Fruit>, IFruitRepository
    {
        protected readonly FruitContext _myContext;

        public FruitRepository(FruitContext context) : base(context)
            => _myContext = context;
    }

}
