using System;

namespace Delegates.Service;

public class CalculationService
{
    public static double ShowMax(double x, double y)
    {
        double max = (x > y) ? x : y;
        System.Console.WriteLine(mas);
    }

    public static double ShowSum(double x, double y)
    {
        double sum = x + y;
        System.Console.WriteLine(sum);
    }

    public static double Square(double x)
    {
        return x * x;
    }
}
