using Microsoft.EntityFrameworkCore;
using MELISSA.Data;
namespace MELISSA.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MELISSAContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MELISSAContext>>()))
            {
                if (context == null || context.Mel == null)
                {
                    throw new ArgumentNullException("Null MELISSAContext");
                }

                if (context.Mel.Any())
                {
                    return;

                }
                context.Mel.AddRange(
                    new Mel
                    {
                        NameofProduct = "Bra",
                        Brand = "Avon",
                        PurchaseDate = DateTime.Parse("2022-10-3"),
                        Quantity = 1,
                        Price = 100M






                    },
                    new Mel
                    {
                        NameofProduct = "T-SHIRT",
                        Brand = "Penshop",
                        PurchaseDate = DateTime.Parse("2022-11-1"),
                        Quantity = 1,
                        Price = 10M

                    },
                    new Mel
                    {
                        NameofProduct = "Denim Pants",
                        Brand = "Nike",
                        PurchaseDate = DateTime.Parse("2022-8-3"),
                        Quantity = 1,
                        Price = 1000M
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}
