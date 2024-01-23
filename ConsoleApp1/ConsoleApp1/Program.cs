namespace ConsoleApp1
{
    internal class Program
    {
        static int[,] CreateSquareMatrixGenerate(int size)
        {
            int[,] SquareMatrix = new int[size, size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    SquareMatrix[i, j] = random.Next(1, 10);
                }
            }
            return SquareMatrix;
        }

        static int[,] CreateSquareMatrixKeyboard(int size)
        {
            int[,] SquareMatrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"Елемент [{i + 1},{j + 1}]: ");
                    SquareMatrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            return SquareMatrix;
        }
        static void Main()
        {
            Console.WriteLine("Enter size of square matrix:");
            int size = Convert.ToInt32(Console.ReadLine());
            int[,] myMatrix = CreateSquareMatrixGenerate(size);
            //int[,] myMatrix = CreateSquareMatrixKeyboard(size);
            int rows = size;
            int columns = size;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(myMatrix[i, j] + "\t");
                }

                int rowSum = 0;
                for (int j = 0; j < columns; j++)
                {
                    rowSum += myMatrix[i, j];
                }
                
                Console.Write(rowSum);
                Console.WriteLine();
            }

            for (int j = 0; j < columns; j++)
            {
                int columnSum = 0;
                for (int i = 0; i < rows; i++)
                {
                    columnSum += myMatrix[i, j];
                }
                Console.Write($"{columnSum}\t");
            }
            Console.WriteLine();
        }
    }
}