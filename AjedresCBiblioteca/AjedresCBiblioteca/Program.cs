using System;
using AjedrezBiblio;//biblioteca creada

class Program
{
    static int[] tablero;
    static int soluciones;//va a mostrar el numero total de posibles soluciones
    static IAjedrez piezaSeleccionada;
   

    static void Main(string[] args)
    {
        Console.Write("Dimensión del tablero (n): ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Seleccione la pieza:");
        Console.WriteLine("1. Reina");
        Console.WriteLine("2. Alfil");
        Console.WriteLine("3. Peón");
        Console.WriteLine("4. Rey");
        Console.WriteLine("5. Caballo");

        bool opcionValida = false;
        while (!opcionValida)
        {
            int opcion = int.Parse(Console.ReadLine());

            piezaSeleccionada = opcion switch
            {
                1 => new Reina(),
                2 => new Alfil(),
                3 => new Peon(),
                4 => new Rey(),
                5 => new Caballo(),
                _ => null
            };

            if (piezaSeleccionada != null)
            {
                opcionValida = true;
            }
            else
            {
                Console.WriteLine("Opción no válida. Por favor, elija nuevamente:");
                Console.WriteLine("1. Reina");
                Console.WriteLine("2. Alfil");
                Console.WriteLine("3. Peón");
                Console.WriteLine("4. Rey");
                Console.WriteLine("5. Caballo");
            }
        }

        Console.Write("Cantidad de piezas: ");
        int cantidad = int.Parse(Console.ReadLine());

        tablero = new int[cantidad];
        soluciones = 0;

        ColocarPieza(0, n, cantidad);

        Console.WriteLine($"Total de soluciones encontradas: {soluciones}");
    }

    static void ColocarPieza(int columnaActual, int n, int cantidad)
    {
        if (columnaActual == cantidad)
        {
            soluciones++;
            ImprimirTablero(n, cantidad);
            return;
        }

        for (int fila = 0; fila < n; fila++)
        {
            if (piezaSeleccionada.EsPosicionValida(fila, columnaActual, tablero, columnaActual))
            {
                tablero[columnaActual] = fila;
                ColocarPieza(columnaActual + 1, n, cantidad);
            }
        }
    }


    static void ImprimirTablero(int n, int cantidad)
    {
        Console.WriteLine($"Solución {soluciones}:");
        for (int fila = 0; fila < n; fila++)
        {
            for (int columna = 0; columna < cantidad; columna++)
            {
                if (tablero[columna] == fila)
                    Console.Write("*");
                else
                    Console.Write(".");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
