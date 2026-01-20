using System;
using System.Security.Cryptography.X509Certificates;

class Referencia
{
    // é um ponteiro
    public static void mostrar()
    {
        int x = 10;
        tripicar(ref x);

        int triplo = 0;
        tripicar(x, out triplo);
    }

    public static void tripicar(ref int x)
    {
        x = x*3;
    }

    public static void tripicar(int x, out int result)
    {
        result = x*3;
    }
}