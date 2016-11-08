using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using nsProduct;
using nsCategory;
using nsStore;

public static class Seed
{
    public static void Initialize(DB db, bool isDevEnvironment)
    {
        if(isDevEnvironment){
            db.Database.EnsureDeleted(); // delete then, ...
        }

        db.Database.EnsureCreated(); // create the tables!!
        // db.Database.Migrate(); // ensure migrations are registered

        if(db.Products.Any() || db.Categories.Any() || db.Stores.Any()) return;

        List<Product> p = new List<Product> {
            new Product {
                ImageURLs = new List<URL> { new URL { Value = "https://media3.giphy.com/media/ttdWms7uQMpR6/200.gif" } },
                Title = "One (coding) hitman for hire",
                Price = 5.99f,
                Description = "Buy me tacos, I'll code your app.",
                Categories = new List<Category> { new Category { Name = "Services" } }
            },
            new Product {
                ImageURLs = new List<URL> { new URL { Value = "https://media.giphy.com/media/Cr5aOy5MeUXrG/giphy.gif" } },
                Title = "Code wizard for hire",
                Price = 15.99f,
                Description = "Purchase a code wizard, set your virtual reality free.",
                Categories = new List<Category> { new Category { Name = "Services" } }
            },
            new Product {
                ImageURLs = new List<URL> { new URL { Value = "https://media.giphy.com/media/CsR56PJlHELUA/giphy.gif" } },
                Title = "Amazon Express: Instant Taco Delivery",
                Price = 2.99f,
                Description = "Purchase in bulk to save on shipping.",
                Categories = new List<Category> { new Category { Name = "Food" } }
            },
            new Product {
                ImageURLs = new List<URL> { new URL { Value = "https://media3.giphy.com/media/ttdWms7uQMpR6/200.gif" } },
                Title = "One more (coding) hitman for hire",
                Price = 6.99f,
                Description = "Buy me burgers, I'll code your app.",
                Categories = new List<Category> { new Category { Name = "Services" } }
            },
            new Product {
                ImageURLs = new List<URL> { new URL { Value = "https://media.giphy.com/media/Cr5aOy5MeUXrG/giphy.gif" } },
                Title = "Another code wizard for hire",
                Price = 16.99f,
                Description = "Purchase a code wizard, set your virtual reality free.",
                Categories = new List<Category> { new Category { Name = "Services" } }
            },
            new Product {
                ImageURLs = new List<URL> { new URL { Value = "https://media.giphy.com/media/CsR56PJlHELUA/giphy.gif" } },
                Title = "Amazon Express: Instant Delivery Everywhere",
                Price = 21.99f,
                Description = "Purchase in bulk to save.",
                Categories = new List<Category> { new Category { Name = "Food" } }
            },
            new Product {
                ImageURLs = new List<URL> { new URL { Value = "https://media.giphy.com/media/Cr5aOy5MeUXrG/giphy.gif" } },
                Title = "Another AI for hire",
                Price = 99.99f,
                Description = "Purchase AI, set your virtual reality free.",
                Categories = new List<Category> { new Category { Name = "Services" } }
            },
            new Product {
                ImageURLs = new List<URL> { new URL { Value = "https://media.giphy.com/media/CsR56PJlHELUA/giphy.gif" } },
                Title = "Windows",
                Price = 89.99f,
                Description = "Purchase OEM to save.",
                Categories = new List<Category> { new Category { Name = "Software" } }
            }
        };

        var htown = new Store { Title="TIY Houston Amazon Store", Products = p };

        db.Stores.Add(htown);
        db.SaveChanges();

        // Console.WriteLine(db.Products.First());
        Console.WriteLine("----------DB SEEDED-------------");
    }
}