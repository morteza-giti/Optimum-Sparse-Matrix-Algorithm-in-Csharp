using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimumSparseMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCols = 0;
            int numberOfRows = 0;
            int numberOfNonZeroElements = 0;
            Console.WriteLine("Enter number of rows: ");
            numberOfRows = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of cols: ");
            numberOfCols = int.Parse(Console.ReadLine());
            int[,] Matrix = new int[numberOfRows,numberOfCols];
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.WriteLine("Enter value for index: [{0}, {1}]",i,j);
                    Matrix[i, j] = int.Parse(Console.ReadLine());
                    if (Matrix[i, j] != 0)
                    {
                        numberOfNonZeroElements++;
                    }
                }
            }
            int[,] optimalSparseMatrix = new int[1, 3];
            optimalSparseMatrix[0, 0] = numberOfRows;
            optimalSparseMatrix[0, 1] = numberOfCols;
            optimalSparseMatrix[0, 2] = numberOfNonZeroElements;
            Console.WriteLine("-------------------------------");
            Console.WriteLine("The Sparse Matrix: ");
            Console.WriteLine("-------------------------------");
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {                   
                    Console.Write(Matrix[i, j] +  "      ");
                    if (Matrix[i, j] != 0)
                    {
                        int newSize = optimalSparseMatrix.GetLength(0) + 1;
                        optimalSparseMatrix = (int[,])ResizeArray(optimalSparseMatrix, new int[] { newSize, 3 });
                        optimalSparseMatrix[optimalSparseMatrix.GetUpperBound(0), 0] = i;
                        optimalSparseMatrix[optimalSparseMatrix.GetUpperBound(0), 1] = j;
                        optimalSparseMatrix[optimalSparseMatrix.GetUpperBound(0), 2] = Matrix[i, j];
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Optimal Sparse Matrix");
            Console.WriteLine("-------------------------------");
            for (int i = 0; i < optimalSparseMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < optimalSparseMatrix.GetLength(1); j++)
                {
                    Console.Write(optimalSparseMatrix[i, j] + "      ");
                }
                Console.WriteLine();
            }

            
            Console.ReadKey();
        }
        private static Array ResizeArray(Array arr, int[] newSizes)
        {
            if (newSizes.Length != arr.Rank)
                throw new ArgumentException("arr must have the same number of dimensions " +
                                            "as there are elements in newSizes", "newSizes");

            var temp = Array.CreateInstance(arr.GetType().GetElementType(), newSizes);
            int length = arr.Length <= temp.Length ? arr.Length : temp.Length;
            Array.ConstrainedCopy(arr, 0, temp, 0, length);
            return temp;
        } 
    }
}
