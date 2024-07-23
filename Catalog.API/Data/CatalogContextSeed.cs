using Catalog.API.Entities;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetMyProducts());
            }
        }

        private static IEnumerable<Product> GetMyProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "ac064d38ee12445bbffed2e695d0a018",
                    Name  = "Name I",
                    Description = "Description I",
                    Category = "Category I",
                    Image = "name-I.png",
                    Price = 950.00M
                },
                new Product()
                {
                    Id = "047f42f39f8b4fa7ba22ec29f373fbb1",
                    Name  = "Name II",
                    Description = "Description II",
                    Category = "Category II",
                    Image = "name-II.png",
                    Price = 800.00M
                },
                new Product()
                {
                    Id = "f09214ae65694022ae6ffd68001fa1aa",
                    Name  = "Name III",
                    Description = "Description III",
                    Category = "Category III",
                    Image = "name-III.png",
                    Price = 750.00M
                },
                new Product()
                {
                    Id = "6a4cac86f3524136abb36c2e06bc0d6d",
                    Name  = "Name IV",
                    Description = "Description IV",
                    Category = "Category IV",
                    Image = "name-IV.png",
                    Price = 600.00M
                },
                new Product()
                {
                    Id = "e1a08c47441746c58ffde6e06791825e",
                    Name  = "Name V",
                    Description = "Description V",
                    Category = "Category V",
                    Image = "name-V.png",
                    Price = 500.00M
                }
            };
        }
    }
}