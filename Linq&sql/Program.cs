using Linq_sql;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

static void Print<T>(string msg, IEnumerable<T> collection)
{
    System.Console.WriteLine(msg);
    foreach (T obj in collection)
    {
        System.Console.WriteLine(obj);
    }
}

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

// sql in c#
var r1 = from p in products where p.Category.tier == 1 && p.Price < 900 select p;
Print("sql 1: ", r1);

var r2 = from p in products
    where p.Category.name == "Tools"
    select p.Name;
Print("sql 2: ", r2);

var r3 = from p in products 
    where p.Name[0] == 'C' 
    select new
          {
            p.Name,
            p.Price,
            //precisa do apelido
            CategoryName = p.Category.name
          };
Print("sql 3: ", r3);

var r4 = from p in products
    where p.Category.tier == 1
    orderby p.Name
    orderby p.Price
    select p;
Print("sql 4: ", r4);

var r5 = (from p in r4
    select p).Skip(2).Take(4);
Print("sql 5: ", r5);

var r6 = (from p in products select p).FirstOrDefault();
System.Console.WriteLine("sql 6: ", r6);

var r7 = (from p in products
    where p.Price > 3000.0
    select p).FirstOrDefault();
System.Console.WriteLine("sql 7: ", r7);

System.Console.WriteLine("--------------");
var r8 = from p in products
    group p by p.Category;
    foreach(IGrouping<Category, Product> group in r8)
{
    System.Console.WriteLine("category: "+ group.Key.name + ":");
    foreach (Product p in group)
    {
        System.Console.WriteLine(p);
    }
    System.Console.WriteLine();
}