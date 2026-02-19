// See https://aka.ms/new-console-template for more information
using linq_lambda;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

static void Print<T>(string msg, IEnumerable<T> collection)
{
    System.Console.WriteLine(msg);
    foreach (T obj in collection)
    {
        System.Console.WriteLine(obj);
    }
}

Console.WriteLine("Hello, World!");

Category c1 = new Category() {id=1, name="Tools", tier=1};
Category c2 = new Category() {id=2, name="PC", tier=2};
Category c3 = new Category() {id=3, name="ELETRIC", tier=3};

List<Product> products = new List<Product>()
{
    new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = c2 },
    new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 },
    new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = c3 },
    new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2 },
    new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = c1 },
    new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = c2 },
    new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = c3 },
    new Product() { Id = 8, Name = "Printer", Price = 350.0, Category = c3 },
    new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = c2 },
    new Product() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3 },
    new Product() { Id = 11, Name = "Level", Price = 70.0, Category = c1 }
};

var r1 = products.Where(x => x.Category.tier == 1 && x.Price < 900);
Print("tier 1 and < 900: ", r1);

var r2 = products.Where(x => x.Category.name == "Tools");
Print("tools r2: ", r2);

var r3 = products.Where(x => x.Name[0] == 'C').Select(p => new {p.Name, p.Price, CategoryName = p.Category.name});
Print("objs r3: ", r3);

var r4 = products.Where(x => x.Category.tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
Print("objs r4: ", r4);

var r5 = r4.Skip(2).Take(4);
Print("objs r5: ", r5);

var r6 = products.First();
System.Console.WriteLine("first : " + r6);

var r7 = products.Where(p => p.Price > 3000.0).FirstOrDefault();
System.Console.WriteLine("first r7: " + r7);

var r8 = products.Where(p => p.Id == 3).SingleOrDefault();
Console.WriteLine("Single or default test1: "+ r8);

var r9 = products.Where(p => p.Id == 30).SingleOrDefault();
Console.WriteLine("Single or default test1: "+ r9);