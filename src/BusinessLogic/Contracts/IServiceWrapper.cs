namespace BusinessLogic.Contracts
{
    public interface IServiceWrapper
    {
        IFruitService Fruits { get; }
        IFruitTypeService FruitTypes { get; }
    }
}
