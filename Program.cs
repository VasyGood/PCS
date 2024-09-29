using System.Diagnostics;
using MyMatrix;

class Program
{
    static void Main()
    {
        int operation = 0;
        Matrix A = new Matrix(1, 1), B = new Matrix(1, 1);
        bool flag = false;
        int n = 0, m = 0;

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

            try
            {
                operation = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            if (operation == 1)
            {
                Console.Clear();



                Console.WriteLine("Enter N and M for first matrix");

                Console.WriteLine("Enter N:");
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Enter M:");
                try
                {
                    m = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    A = new Matrix(n, m);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Enter N and M for second matrix");

                Console.WriteLine("Enter N:");
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Enter N:");
                try
                {
                    m = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    B = new Matrix(n, m);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

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

                Console.WriteLine("Values are entered from left to right and from top to bottom");
                try
                {
                    Console.WriteLine("A values:");
                    A.ValuesFromKeyboard();
                    Console.WriteLine("B values");
                    B.ValuesFromKeyboard();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Display the values on the screen?(y/n)");
                if (Console.ReadLine() == "y")
                {
                    Console.WriteLine("First matrix:");
                    A.PrintValues();
                    Console.WriteLine("Second matrix:");
                    B.PrintValues();
                }
            }
            else if (operation == 3)
            {
                Console.Clear();

                if (!flag)
                {
                    Console.WriteLine("First, create the matrices. (Use operation 1)");
                    continue;
                }

                int minValue = 0, maxValue = 0;

                Console.WriteLine("Enter minValue for random");
                try
                {
                    minValue = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Enter minValue for random");
                try
                {
                    maxValue = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                try
                {
                    A.RandValues(minValue, maxValue);
                    B.RandValues(minValue, maxValue);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Display the values on the screen?(y/n)");
                if (Console.ReadLine() == "y")
                {
                    Console.WriteLine("First matrix:");
                    A.PrintValues();
                    Console.WriteLine("Second matrix:");
                    B.PrintValues();
                }
            }
            else if (operation == 4)
            {
                Console.Clear();

                if (!flag)
                {
                    Console.WriteLine("First, create the matrices. (Use operation 1)");
                    continue;
                }

                Console.WriteLine("Use existing values?(y/n)");

                if (Console.ReadLine() == "y")
                {
                    try
                    {
                        (A + B).PrintValues();
                        continue;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                Console.WriteLine("Enter new values");
                Console.WriteLine("Values are entered from left to right and from top to bottom");

                try
                {
                    Console.WriteLine("A values:");
                    A.ValuesFromKeyboard();
                    Console.WriteLine("B values");
                    B.ValuesFromKeyboard();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    (A + B).PrintValues();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (operation == 5)
            {
                Console.Clear();

                if (!flag)
                {
                    Console.WriteLine("First, create the matrices. (Use operation 1)");
                    continue;
                }

                Console.WriteLine("Use existing values?(y/n)");

                if (Console.ReadLine() == "y")
                {
                    try
                    {
                        (A * B).PrintValues();
                        continue;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                Console.WriteLine("Enter new values");
                Console.WriteLine("Values are entered from left to right and from top to bottom");

                try
                {
                    Console.WriteLine("A values:");
                    A.ValuesFromKeyboard();
                    Console.WriteLine("B values");
                    B.ValuesFromKeyboard();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    (A * B).PrintValues();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (operation == 6)
            {
                Console.Clear();

                Console.WriteLine("Enter N and M for matrix");

                Console.WriteLine("Enter N:");
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Enter M:");
                try
                {
                    m = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    A = new Matrix(n, m);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Enter matrix values");
                Console.WriteLine("Values are entered from left to right and from top to bottom");
                try
                {
                    A.ValuesFromKeyboard();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    Console.WriteLine($"Determinant: {A.Det()}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (operation == 7)
            {
                Console.Clear();

                Console.WriteLine("Enter N and M for matrix");

                Console.WriteLine("Enter N:");
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Enter M:");
                try
                {
                    m = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    A = new Matrix(n, m);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Enter matrix values");
                Console.WriteLine("Values are entered from left to right and from top to bottom");
                try
                {
                    A.ValuesFromKeyboard();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    A.Inverse().PrintValues();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (operation == 8)
            {
                Console.Clear();

                Console.WriteLine("Enter N and M for matrix");

                Console.WriteLine("Enter N:");
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Enter M:");
                try
                {
                    m = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    A = new Matrix(n, m);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Enter matrix values");
                Console.WriteLine("Values are entered from left to right and from top to bottom");
                try
                {
                    A.ValuesFromKeyboard();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    A.Transpose().PrintValues();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (operation == 9)
            {
                Console.Clear();

                if (!flag)
                {
                    Console.WriteLine("First, create the matrices. (Use operation 1)");
                    continue;
                }

                Console.WriteLine("Use existing values?(y/n)");

                if (Console.ReadLine() == "y")
                {
                    try
                    {
                        Matrix.SolveEqSys(A, B);
                        continue;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                Console.WriteLine("Enter new values");
                Console.WriteLine("Values are entered from left to right and from top to bottom");

                try
                {
                    Console.WriteLine("A values:");
                    A.ValuesFromKeyboard();
                    Console.WriteLine("B values");
                    B.ValuesFromKeyboard();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    Matrix.SolveEqSys(A, B);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}