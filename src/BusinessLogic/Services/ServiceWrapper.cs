using BusinessLogic.Contracts;
using DataAccess;
using DataAccess.Contracts;

namespace BusinessLogic.Services
{
    public class ServiceWrapper : IServiceWrapper
    {
       
        private IFruitService _fruits;
        private IFruitTypeService _fruitTypes;

        public IFruitService Fruits
        {
            get
            {
                if (_fruits == null)
                {
                    _fruits = new FruitService(z);
                }
                return _fruits;
            }
        }

        public IFruitTypeService FruitTypes
        {
            get
            {
                if (_fruitTypes == null)
                {
                    _fruitTypes = new FruitTypeService(z);
                }
                return _fruitTypes;
            }
        }
        private IRepositoryWrapper z;
        public ServiceWrapper(IRepositoryWrapper r)
        {
            z = r;
        }
       
    }
}
