namespace Tasks.Dynamic.ExaminationTest;

public static class Task3
{
    public static void Solve()
    {
        var variables = Console.ReadLine()!.Split().Select(int.Parse).ToList();
        int n = variables[0], k = variables[1];

        var arr = new long[n + 1][];
        for (var i = 1; i <= n; i++)
        {
            var len = Math.Min(k, i) + 1;
            arr[i] = new long[len];
            for (var j = 0; j < len; j++)
            {
                if (j == 0 || j == i)
                    arr[i][j] = 1;
                else
                    arr[i][j] = arr[i - 1][j] + arr[i - 1][j - 1];
            }
        }
        Console.WriteLine(arr[n][k]);
    }
}