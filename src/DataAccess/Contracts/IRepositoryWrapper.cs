namespace DataAccess.Contracts
{
    public interface IRepositoryWrapper
    {
        IFruitRepository Fruits { get; }
        IFruitTypeRepository FruitTypes { get; }
        Task SaveAsync();
    }
}
