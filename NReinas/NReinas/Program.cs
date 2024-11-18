using System;
class NQUEENS
{
    static int n;
    static int[] Tablero;
    static void Ptablero()
    {
        for (int Fila = 0; Fila < n; Fila++)
        {
            for (int Columna = 0; Columna < n; Columna++)
            {
                if (Tablero[Columna] == Fila)
                {
                    Console.Write("* ");
                }
                else
                {
                    Console.Write(". ");
                }

            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    static bool Reina(int Columna)
    {
        if (Columna == n)
        {
            Ptablero();
            // return true;
            return false;

        }
        for (int Fila = 0; Fila < n; Fila++)
        {
            Tablero[Columna] = Fila;
            if (EsValido(Columna))
            {
                if (Reina(Columna + 1))
                {
                    return true;
                }
            }

            /*
            Tablero[Columna] = Fila;
            if (Columna == 7)
            {
                Ptablero();
            }
            else
            {
                Reina(Columna++);
            }*/
        }
        return false;
    }
    static bool EsValido(int Columna)
    {
        for (int i = 0; i < Columna; i++)
        {
            if (Tablero[i] == Tablero[Columna] || Math.Abs(Tablero[i] - Tablero[Columna]) == Math.Abs(i - Columna))
            {
                return false;
            }
        }
        return true;
    }
    static void Main(string[] args)
    {
        Console.Write("Ingresar numero de reinas deseado (n):");
        n = int.Parse(Console.ReadLine());
        Tablero = new int[n];
            Reina(0);
        Console.ReadKey();
    }
}

