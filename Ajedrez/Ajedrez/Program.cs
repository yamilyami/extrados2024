using System;
using System.ComponentModel.DataAnnotations.Schema;
using System;
class P8QUEENS
{
  static int[] Tablero = new int[8];
  static void Ptablero()
    {
       // Console.Clear();
        //Console.WriteLine();
        for (int Fila = 0; Fila<8; Fila++)
        {
            for (int Columna=0; Columna<8; Columna++)
            { 
                if (Tablero[Columna] == Fila)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
               
            }
            Console.WriteLine();
           // Console.ReadKey();
        }
        Console.WriteLine();
    }
    static bool Reina(int Columna)
        {
            if (Columna == 8)
            {
                Ptablero();
                return true;
            }
            for (int Fila = 0; Fila<8; Fila++) 
            {
                Tablero[Columna] = Fila;
                if(EsValido(Columna))
                {
                  if(Reina(Columna + 1))
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
 static void Main(string[]args)
        {
            Reina(0);
            Console.ReadKey();
        }
  
    
}

