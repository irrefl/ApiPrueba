using System;

namespace Domain.Entities
{
    public class FruitType : BaseEntity
    {

        public long FruitTypeId;
        public string Name { get; set; }
        public ICollection<Fruit> Fruits { get; set; }

        public FruitType(long fruitId, string name, ICollection<Fruit> f)
        {
            FruitTypeId = fruitId;
            Name = name;
            Id = Guid.NewGuid().ToString();
            Fruits = f;
        }
        public FruitType()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
