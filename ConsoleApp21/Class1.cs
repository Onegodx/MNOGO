using System;
using System.Threading.Tasks;

class Program
{
    static bool Expression1(bool X, bool Y, bool Z)
    {
        return !(!X && Y) || (X && !Z);
    }

    static bool Expression2(bool X, bool Y, bool Z)
    {
        return X && !(!Y || Z) || Y;
    }

    static void Main()
    {
        // Последовательные вычисления
        var startTime = DateTime.Now;
        TableOfTruth();
        var endTime = DateTime.Now;
        Console.WriteLine($"Последовательные вычисления: {endTime - startTime}");

        // Параллельные вычисления
        startTime = DateTime.Now;
        ParallelTableOfTruth();
        endTime = DateTime.Now;
        Console.WriteLine($"Параллельные вычисления: {endTime - startTime}");
    }

    static void TableOfTruth()
    {
        Console.WriteLine("X Y Z | Expression1 | Expression2");
        for (int x = 0; x <= 1; x++)
        {
            for (int y = 0; y <= 1; y++)
            {
                for (int z = 0; z <= 1; z++)
                {
                    Console.WriteLine($"{x} {y} {z} | {Expression1(x == 1, y == 1, z == 1)} | {Expression2(x == 1, y == 1, z == 1)}");
                }
            }
        }
    }

    static void ParallelTableOfTruth()
    {
        Console.WriteLine("X Y Z | Expression1 | Expression2");
        Parallel.For(0, 2, x =>
        {
            Parallel.For(0, 2, y =>
            {
                Parallel.For(0, 2, z =>
                {
                    Console.WriteLine($"{x} {y} {z} | {Expression1(x == 1, y == 1, z == 1)} | {Expression2(x == 1, y == 1, z == 1)}");
                });
            });
        });
    }
}
