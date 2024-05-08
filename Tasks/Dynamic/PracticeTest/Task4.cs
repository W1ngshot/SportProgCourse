namespace Tasks.Dynamic.PracticeTest;

public class Task4
{
    public static void Solve()
    {
        var variables = Console.ReadLine()!.Split().Select(int.Parse).ToList();
        int n = variables[0], m = variables[1];

        var field = InputField(n, m);
        var sumField = new int[n, m];
        var moveField = new bool[n, m];

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < m; j++)
            {
                sumField[i, j] = field[i, j];
                if (i > 0 && sumField[i - 1, j] + field[i, j] > sumField[i, j])
                {
                    sumField[i, j] = sumField[i - 1, j] + field[i, j];
                    moveField[i, j] = false;
                }

                if (j > 0 && sumField[i, j - 1] + field[i, j] > sumField[i, j])
                {
                    sumField[i, j] = sumField[i, j - 1] + field[i, j];
                    moveField[i, j] = true;
                }
            }
        }
        
        Console.WriteLine(sumField[n - 1, m - 1]);
        WritePath(moveField, n - 1, m - 1);
    }

    private static void WritePath(bool[,] moveField, int i, int j)
    {
        if (i == 0 && j == 0)
            return;
        if (!moveField[i, j])
        {
            WritePath(moveField, i - 1, j);
            Console.Write('D');
        }

        if (moveField[i, j])
        {
            WritePath(moveField, i, j - 1);
            Console.Write('R');
        }
    }

    private static int[,] InputField(int n, int m)
    {
        var field = new int[n, m];

        for (var i = 0; i < n; i++)
        {
            var row = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            for (var j = 0; j < m; j++)
            {
                field[i, j] = row[j];
            }
        }

        return field;
    }
}