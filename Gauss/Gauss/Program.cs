/*
 * AUTOR: JOSE ARMANDO SAENZ ESQUEDA.
 * FECHA: 7 DE NOVIEMBRE DE 2019.
 * DESCRIPCION: PROGRAMA PARA RESOLVER UN SISTEMA DE ECUACIONES LINEALES
 * POR EL METODO DE GAUSS JORDAN.
 * LIMITANTES:  EL SISTEMA DEBE SER CUADRADO (MISMO NUMERO DE VARIABLES QUE DE ECUACIONES)
 *              DEBE DE TENER SOLUCION UNICA
 *              LOS ELEMENTOS EN LA DIAGONAL NO DEBEN DE SER CEROS
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gauss
{
    class Program
    {
        static void Main(string[] args)
        {
            //DEFINICION DE VARIABLE
            int numVar;
            double[,] Matriz;
            //IMPRIME EN PANTALLA LA DESCRIPCION DEL PROGRAMA
            Console.WriteLine("PROGRAMA PARA RESOLVER UN SISTEMA DE ECUACIONES POR EL METODO DE GAUSS-JORDAN");
            //PIDE EL NUMERO DE VARIABLES
            Console.WriteLine("INGRESAR EL NUMERO DE VARIABLES:");
            while (!int.TryParse(Console.ReadLine(), out numVar))
            {
                Console.WriteLine("DATO NO VALIDO. REINGRESAR EL NUMERO DE VARIABLES:");
            }
            //CONSTRUYE LA MATRIZ
            Matriz = new double[numVar, numVar + 1];
            //PIDE LOS ELEMENTOS DE LA MATRIZ
            for (int i = 0; i < numVar; i++)
                for (int j = 0; j <= numVar; j++)
                {
                    Console.WriteLine("INGRESA EL ELEMENTO [{0},{1}]:",(i+1),(j+1));
                    while(!double.TryParse(Console.ReadLine(),out Matriz[i,j]))
                    {
                        Console.WriteLine("DATO NO VALIDO. REINGRESAR EL ELEMENTO:");
                    }
                }
            //IMPRIME LA MATRIZ EN PANTALLA
            Console.WriteLine("LA MATRIZ A RESOLVER ES:");
            MuestraMatriz(Matriz);
            //CICLO PARA RESOLVER LA MATRIZ
            for (int i = 0; i < numVar; i++)
            {

                Matriz = EOR1(Matriz, i, 1 / Matriz[i, i]);
                for (int k = 0; k < numVar; k++)
                {
                    if (i == k)
                    {
                        continue;
                    }
                    Matriz = 
                    EOR2(Matriz, i, k, -Matriz[k, i]);
                }
            }
            //IMPRIME LA MATRIZ EN PANTALLA
            Console.WriteLine("LA SOLUCION ES:");
            MuestraMatriz(Matriz);
            //FINAL DE RUTINA
            Console.WriteLine("PRESIONE CUALQUIER TECLA PARA FINALIZAR");
            Console.ReadKey();
        }

        private static void MuestraMatriz(double[,] A)
        {
            //OBTIENE EL NUMERO DE RENGLONES
            int ren = A.GetLength(0);
            //OBTIENE EL NUMERO DE COLUMNAS
            int col = A.GetLength(1);
            //OBTIENE EL TAMAÑO MAXIMO DE CARACTERTES DE CADA COLUMNA
            int[] tam = new int[col];
            for (int j = 0; j < col; j++)
            {
                for (int i = 0; i < ren; i++)
                {
                    tam[j] = A[i, j].ToString("F2").Length <= tam[j] ? tam[j] : A[i, j].ToString("F2").Length;
                }
            }
            //IMPRIME LA MATRIZ EN PANTALLA
            for (int i = 0; i < ren; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    //IMPRIME LOS ELEMENTOS EN PANTALLA
                    Console.Write(A[i, j].ToString("F2").PadLeft(tam[j]) + (j<col-1?"|":Environment.NewLine));
                }
            }
            Console.WriteLine();
        }


        static double[,] EOR1(double[,] A, int renglon, double factor)
        {
            //OBTIENE EL NUMERO DE COLUMNAS
            int col = A.GetLength(1);
            //MULTIPLICA EL RENGLON POR EL FACTOR
            for (int i = 0; i < col; i++)
            {
                A[renglon, i] *= factor;
            }
            //FINALIZA LA RUTINA Y REGRESA EL RESULTADO
            return A;
        }


        static double[,] EOR2(double[,] A, int renglon1, int renglon2, double factor)
        {
            //OBTIENE EL NUMERO DE COLUMNAS
            int col = A.GetLength(1);
            //MODIFICA EL RENGLON
            for (int i = 0; i < col; i++)
            {
                A[renglon2, i] += A[renglon1, i] * factor;
            }
            //FINALIZA LA RUTINA Y REGRESA EL RESULTADO
            return A;
        }
    }
}
