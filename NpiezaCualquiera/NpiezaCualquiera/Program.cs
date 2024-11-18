using System;
class NPIEZAS
{
    static int n;
    static int[] Tablero;
    static string pieza;
    static int soluciones;
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
  /*  static bool Reina(int Columna)
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

        }
        return false;
    }*/
    static bool EsValido(int Columna)
    {
        for(int i=0; i<Columna;i++)
        {
            if (Tablero[i] == Tablero[Columna])
                return false;
            int diferenciaFilas = Math.Abs(Tablero[i] - Tablero[Columna]);
            int diferenciaColumnas = Columna - i;

            if (pieza == "q" || pieza == "a")
            {
                if (diferenciaFilas == diferenciaColumnas)
                    return false; 
            }

            if (pieza == "r")
            {
                if (diferenciaFilas <= 1 && diferenciaColumnas <= 1)
                    return false;   
            }

            if (pieza == "c")
            {
                if ((diferenciaFilas == 2 && diferenciaColumnas == 1) ||
                    (diferenciaFilas == 1 && diferenciaColumnas == 2))
                    return false;             }

            if (pieza == "p")
            {
                if (diferenciaFilas == 1 && diferenciaColumnas == 1)
                    return false;
            }
        }
        return true;
    }

    static bool colocarPieza(int Columna)
    {
        if (Columna ==n)
        {
            soluciones++;
            Console.WriteLine($"Solucion{soluciones}:");
            Ptablero();
            return true;
        }
        for (int fila = 0; fila < n; fila++)
        {
            Tablero[Columna] = fila;
            if (EsValido(Columna))
            {
                colocarPieza(Columna + 1);
            }
        }
        return false;
    }
    static void Main(string[] args)
    {
        Console.Write("Ingresar numero dimension del tablero (n):");
        n = int.Parse(Console.ReadLine());

        Console.Write("seleccione pieza: r(rey),q(reina), c(caballo):");
        pieza = Console.ReadLine().ToLower();
        Tablero = new int[n];
        soluciones = 0;

        Console.WriteLine($"Colocando {pieza}s en un tablero de {n}x{n}:");
        colocarPieza(0);

        if (soluciones == 0)
        {
            Console.WriteLine("No se encontraron soluciones.");
        }
        Console.ReadKey();
    }
}