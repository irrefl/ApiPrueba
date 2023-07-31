using System;

namespace Domain.Entities
{
    public class Fruit : BaseEntity
    {
        public long FruitId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public long FruitTypeId { get; set; }
        public FruitType FruitType { get; set; }

        public Fruit(long fruitId, string name, string description, long type)
        {
            FruitId = fruitId;
            Name = name;
            Description = description;
            FruitTypeId = type;

        }

        public string GetData()
        {
            List<int> errs = Enumerable.Range(0, 1)
                            .Select(number => number)
                            .TakeWhile(number => number > 0).ToList();
            string isData = FruitId == 0 ? "return" : "not data";
            return isData;
        }

        public Fruit() { Id = Guid.NewGuid().ToString(); }
    }
}
