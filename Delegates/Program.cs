// See https://aka.ms/new-console-template for more information
using System.Reflection.Emit;
using Delegates.Service;

// ref para função com typesafety
delegate void BinaryNimericOperation(double n1, double n2);

class Proggram
{
    static void Main(string[] args)
    {
        double a = 10;
        double b = 15;

        BinaryNimericOperation op = CalculationService.ShowSum;
        OpCode += CalculationService.ShowMax;

        double result = op.Invoke(a,b);
    }
}