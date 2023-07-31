using DataAccess.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class FruitTypeRepository : Repository<FruitType>, IFruitTypeRepository
    {
        protected readonly FruitContext _myContext;

        public FruitTypeRepository(FruitContext context) : base(context)
            => _myContext = context;
    }
}
