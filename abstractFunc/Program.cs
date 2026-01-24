// See https://aka.ms/new-console-template for more information
using System.Drawing;

Console.WriteLine("Hello, World!");

System.Console.WriteLine("rectangle or circle (r/c)? ");
#pragma warning disable CS8604 // Possível argumento de referência nula.
char clss = char.Parse(Console.ReadLine());
#pragma warning restore CS8604 // Possível argumento de referência nula.

public abstract class Shape ()
{
    Color color;

    public abstract Double area();
}

public class Rectangle () : Shape
{
    double width;
    double height;

    public override double area()
    {
        return width * height;
    }
}

public class Circle () : Shape
{
    double radius;

    public override double area()
    {
        return radius * 2 * Math.PI;
    }
}