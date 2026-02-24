using System;

namespace exercicioLinq2.Entities;

public class Products
{
public string Name { get; set; }
public string Email { get; set; }
public double Price { get; set; }

public Products(string name, string email, double price)
    {
        Name = name;
        Email = email;
        Price = price;
    }
}
