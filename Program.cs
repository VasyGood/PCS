using System.Diagnostics;
using MyMatrix;

class Program
{
    static void Main()
    {
        int operation = 0;
        Matrix A = new Matrix(1, 1), B = new Matrix(1, 1);
        bool flag = false;
        int n, m;
        string? input;

        while (operation != 10)
        {
            Console.WriteLine("Matrix calculator");
            Console.WriteLine("Choose the operation:");
            Console.WriteLine("1: Create two NxM matrices");
            Console.WriteLine("2: Fill in the matrices with values from the keyboard");
            Console.WriteLine("3: Fill in the matrices with random values");
            Console.WriteLine("4: Matrix addition");
            Console.WriteLine("5: Matrix multiplication");
            Console.WriteLine("6: Find the determinant of the matrix");
            Console.WriteLine("7: Find the inverse matrix");
            Console.WriteLine("8: Matrix transposition");
            Console.WriteLine("9: Finding the roots of a system of equations given by a matrix");
            Console.WriteLine("10: Exit");
            Console.WriteLine("Enter command:");

            input = Console.ReadLine();
            if (!int.TryParse(input, out operation))
            {
                Console.WriteLine("Input must be a number");
                continue;
            }

            if (operation == 1)
            {
                Console.Clear();

                Console.WriteLine("Enter N and M for first matrix");

                Console.WriteLine("Enter N:");
                input = Console.ReadLine();
                if (!int.TryParse(input, out n))
                {
                    Console.WriteLine("Input must be a number");
                    continue;
                }

                Console.WriteLine("Enter M:");
                input = Console.ReadLine();
                if (!int.TryParse(input, out m))
                {
                    Console.WriteLine("Input must be a number");
                    continue;
                }

                try
                {
                    A = new Matrix(n, m);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                Console.WriteLine($"Matrix A[{n},{m}] created");

                Console.WriteLine("Enter N and M for second matrix");

                Console.WriteLine("Enter N:");
                input = Console.ReadLine();
                if (!int.TryParse(input, out n))
                {
                    Console.WriteLine("Input must be a number");
                    continue;
                }

                Console.WriteLine("Enter M:");
                input = Console.ReadLine();
                if (!int.TryParse(input, out m))
                {
                    Console.WriteLine("Input must be a number");
                    continue;
                }

                try
                {
                    B = new Matrix(n, m);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                Console.WriteLine($"Matrix B[{n},{m}] created");

                flag = true;
            }
            else if (operation == 2)
            {
                Console.Clear();

                if (!flag)
                {
                    Console.WriteLine("First, create the matrices. (Use operation 1)");
                    continue;
                }

                bool AB = true;
                Console.WriteLine("Choose A or B matrix(Enter A for A and B for B):");
                AB = !(Console.ReadLine() == "B" && AB);

                Console.WriteLine("Values are entered from left to right and from top to bottom");
                try
                {
                    (AB ? A : B).ValuesFromKeyboard();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                Console.WriteLine("Values of " + (AB ? "A" : "B") + ":");
                (AB ? A : B).PrintValues();
            }
            else if (operation == 3)
            {
                Console.Clear();

                if (!flag)
                {
                    Console.WriteLine("First, create the matrices. (Use operation 1)");
                    continue;
                }

                int minValue, maxValue;

                Console.WriteLine("Enter minValue for random");
                input = Console.ReadLine();
                if (!int.TryParse(input, out minValue))
                {
                    Console.WriteLine("Input must be a number");
                    continue;
                }

                Console.WriteLine("Enter maxValue for random");
                input = Console.ReadLine();
                if (!int.TryParse(input, out maxValue))
                {
                    Console.WriteLine("Input must be a number");
                    continue;
                }

                bool AB = true;
                Console.WriteLine("Choose A or B matrix(Enter A for A and B for B):");
                AB = !(Console.ReadLine() == "B" && AB);

                Console.WriteLine("Values are entered from left to right and from top to bottom");
                try
                {
                    (AB ? A : B).RandValues(minValue, maxValue);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                Console.WriteLine("Values of " + (AB ? "A" : "B") + ":");
                (AB ? A : B).PrintValues();

            }
            else if (operation == 4)
            {
                Console.Clear();

                if (!flag)
                {
                    Console.WriteLine("First, create the matrices. (Use operation 1)");
                    continue;
                }

                Console.WriteLine("A values:");
                A.PrintValues();
                Console.WriteLine("B values:");
                B.PrintValues();

                Matrix result = new Matrix(1, 1);

                try
                {
                    result = A + B;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                Console.WriteLine("Result values:");
                result.PrintValues();
            }
            else if (operation == 5)
            {
                Console.Clear();

                if (!flag)
                {
                    Console.WriteLine("First, create the matrices. (Use operation 1)");
                    continue;
                }

                Console.WriteLine("A values:");
                A.PrintValues();
                Console.WriteLine("B values:");
                B.PrintValues();

                Matrix result = new Matrix(1, 1);

                try
                {
                    result = A * B;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                Console.WriteLine("Result values:");
                result.PrintValues();
            }
            else if (operation == 6)
            {
                Console.Clear();

                if (!flag)
                {
                    Console.WriteLine("First, create the matrices. (Use operation 1)");
                    continue;
                }

                bool AB = true;
                Console.WriteLine("Choose A or B matrix(Enter A for A and B for B):");
                AB = !(Console.ReadLine() == "B" && AB);

                Console.WriteLine("Matrix: ");
                (AB ? A : B).PrintValues();

                double det = 0;

                try
                {
                    det = (AB ? A : B).Det();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                Console.WriteLine($"The determinant: {det}");
            }
            else if (operation == 7)
            {
                Console.Clear();

                if (!flag)
                {
                    Console.WriteLine("First, create the matrices. (Use operation 1)");
                    continue;
                }

                bool AB = true;
                Console.WriteLine("Choose A or B matrix(Enter A for A and B for B):");
                AB = !(Console.ReadLine() == "B" && AB);

                Console.WriteLine("Original matrix:");
                (AB ? A : B).PrintValues();

                Matrix result = new Matrix(1, 1);

                try
                {
                    result = (AB ? A : B).Inverse();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                Console.WriteLine("Inverse matrix:");
                result.PrintValues();
            }
            else if (operation == 8)
            {
                Console.Clear();

                if (!flag)
                {
                    Console.WriteLine("First, create the matrices. (Use operation 1)");
                    continue;
                }

                bool AB = true;
                Console.WriteLine("Choose A or B matrix(Enter A for A and B for B):");
                AB = !(Console.ReadLine() == "B" && AB);

                Matrix result = new Matrix(1, 1);

                result = (AB ? A : B).Transpose();

                Console.WriteLine("Original matrix:");
                (AB ? A : B).PrintValues();
                Console.WriteLine("Transpose matrix:");
                result.PrintValues();

            }
            else if (operation == 9)
            {
                Console.Clear();

                if (!flag)
                {
                    Console.WriteLine("First, create the matrices. (Use operation 1)");
                    continue;
                }

                Console.WriteLine("A matrix:");
                A.PrintValues();
                Console.WriteLine("B matrix:");
                B.PrintValues();

                Matrix result = new Matrix(1, 1);

                try
                {
                    result = Matrix.SolveEqSys(A, B);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                Console.WriteLine("X:");
                result.PrintValues();
            }
        }

        Console.WriteLine("Thanks for using");
    }
}