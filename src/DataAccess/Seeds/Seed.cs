
using Domain.Entities;
namespace DataAccess.Seeds
{
    public class Seed
    {
        static void AddFruitTypes(FruitContext ctx)
        {


            List<FruitType> supplyCategories = new()
            {
                new FruitType(1, "Vegetales", new List<Fruit>(){
                        new Fruit(1,"Orange", "this is my descriptionasdfas;ldasdfasd", 1),
                        new Fruit(2,"Sandia", "this is my descriptionasdfas;ldasdfasd", 1),
                    }),
                  new FruitType(1, "Frutas", new List<Fruit>(){
                        new Fruit(1,"Orange", "this is my descriptionasdfas;ldasdfasd", 1),
                        new Fruit(2,"Sandia", "this is my descriptionasdfas;ldasdfasd", 1),
                    }),
                    new FruitType(1, "Refrescos", new List<Fruit>(){
                        new Fruit(1,"Orange", "this is my descriptionasdfas;ldasdfasd", 1),
                        new Fruit(2,"Sandia", "this is my descriptionasdfas;ldasdfasd", 1),
                    }),
                      new FruitType(1, "Carnes", new List<Fruit>(){
                        new Fruit(1,"Orange", "this is my descriptionasdfas;ldasdfasd", 1),
                        new Fruit(2,"Sandia", "this is my descriptionasdfas;ldasdfasd", 1),
                    })
            };

            List<Fruit> f = new(){
                 new Fruit(1,"Orange", "this is my descriptionasdfas;ldasdfasd", 1),
                 new Fruit(2,"Sandia", "this is my descriptionasdfas;ldasdfasd", 1),
            };



            ctx.Database.EnsureCreated();
           // ctx.Fruits.AddRange(f);
           ctx.FruitTypes.AddRange(supplyCategories);
            // ctx.Fruits.AddRange(f);
            ctx.SaveChanges();

        }


        public static void SeedData(FruitContext ctx)
        {
            /*   if (!ctx.RestaurantMenus.Any())
               {  */
            AddFruitTypes(ctx);
            //}

        }

    }
}
