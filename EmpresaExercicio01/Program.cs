using System;
using Exercicios.Entities;
using System.Globalization;

List<Employee> list = new List<Employee>();

// See https://aka.ms/new-console-template for more information
System.Console.WriteLine("enter the number of employess: ");
int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++ {
    System.Console.WriteLine($"Employee #{i} data: ");
    System.Console.Write("outsource (y/n)? ");
    char ch = char.Parse(Console.ReadLine());
    string name = Console.ReadLine();
    System.Console.WriteLine("hours: ");
    int hours = int.Parse(Console.ReadLine);
    System.Console.WriteLine("value per hours: ");
    double valuePHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    if (ch == 'y')
    {
        System.Console.WriteLine("adicional ");
        double AdditionalCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        list.Add(new OutsourcedEmployee(name, hours, valuePHour, AdditionalCharge));
    } else
    {
        list.Add(new Employee(name, hours, valuePHour));
    }

    System.Console.WriteLine("paymentsd");
    
})