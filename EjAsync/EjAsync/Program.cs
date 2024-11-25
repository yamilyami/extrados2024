using System;
using System.Threading.Tasks;

class Program
{
    // funcion para buscar el mayor de los numeros
    int BuscarMayor(int[] numeros, int inicio, int fin)
    {
        int max = int.MinValue; // variable las mas baja
        for (int i = inicio; i < fin; i++)
        {
            if (numeros[i] > max)
            {
                max = numeros[i];  //para subir
            }
        }
        return max;
    }
    //contamos hasta el 30000
    void ContarHasta(int[] numeros, string codigo, object bloqueador)
    {
        lock (bloqueador)
        {
            foreach (var numero in numeros)
            {
                Console.WriteLine($"{codigo} - {numero}");
            }
        }
    }

    // asíncrono de ContarHasta
    async Task ContarHastaAsync(int[] numeros, string codigo, object bloqueador)
    {
        await Task.Run(() => ContarHasta(numeros, codigo, bloqueador)); //creamos la tarea
    }
    async Task Run()
    {
        // ejercicio:Crear y llenar el array con números aleatorios
        int[] numeros = new int[30000];
        Random random = new Random();//para generar numeros aleatorios uso random
        for (int i = 0; i < numeros.Length; i++)
        {
            numeros[i] = random.Next(0, 45001); // aleatorio entre 0 y 45000
        }

        // ejercicio: Dividir el array en dos mitades
        int mitad = numeros.Length / 2;
        object bloqueador = new object();
        int mayor = int.MinValue;

        // ejercicio: Generar dos hilos (tareas) para buscar el mayor en cada mitad
        var tarea1 = Task.Run(() =>
        {
            int max1 = BuscarMayor(numeros, 0, mitad);
            //ejercicio: Utilizar lock para asegurar la integridad
            lock (bloqueador) 
            {
                if (max1 > mayor)
                {
                    mayor = max1;
                }
            }
        });

        var tarea2 = Task.Run(() =>
        {
            int max2 = BuscarMayor(numeros, mitad, numeros.Length);
            //ejercicio: Utilizar lock para asegurar la integridad
            lock (bloqueador) 
            {
                if (max2 > mayor)
                {
                    mayor = max2;
                }
            }
        });
        await Task.WhenAll(tarea1, tarea2);

        //cual es el mayor?
        Console.WriteLine($"El mayor valor encontrado es: {mayor}");
    }

    static async Task Main(string[] args)
    {
        Program program = new Program();
        await program.Run();
    }
}


/*  static async Task Main(string[] args)
  {
      int size = 30000;

      //  Console.WriteLine("Generando el array...");
      //   int[] array = await GenerarArrayAsync(size);
      int[] array = await GenerarArrayAsync(size);
      //  Console.WriteLine($"Array de tamaño {size} generado exitosamente.");
      // imprime
      // Console.WriteLine("Primeros 10 elementos del array:");
      for (int i = 0; i < 10; i++)
      {
          Console.WriteLine(array[i]);
      }
  }

  // Función asíncrona para generar el array
  static async Task<int[]> GenerarArrayAsync(int size)
  {
      return await Task.Run(() =>
      {
          Random random = new Random();
          int[] array = new int[size];

          for (int i = 0; i < size; i++)
          {
              array[i] = random.Next(0, 100); // Genera un número aleatorio entre 0 y 99
          }

          return array;
      });
  }*/
