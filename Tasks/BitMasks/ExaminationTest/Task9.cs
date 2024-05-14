namespace Tasks.BitMasks.ExaminationTest;

public static class Task9
{
    public static void Solve()
    {
        var input = GetInputData();
        var dict = new Dictionary<long, int>();
        var results = new HashSet<long>();

        for (long mask = 0; mask < (1 << input.N); mask++)
        {
            dict[mask] = 0;
            var ans = 0;
            for (var i = 0; i < input.N; i++)
            {
                if ((mask & (1 << i)) == (1 << i))
                {
                    dict[mask]++;
                    for (var j = 0; j < input.N; j++)
                    {
                        if (i == j || input.Data[i, j] == 1)
                            ans |= (1 << j);
                    }
                }
            }

            if (ans == (1 << input.N) - 1)
                results.Add(mask);
        }

        var min = results.Min(result => dict[result]);
        Console.WriteLine(min);
    }

    private static InputData GetInputData()
    {
        using var sr = new StreamReader("C:\\new2.in");
        var variables = sr.ReadLine()!.Split().Select(int.Parse).ToArray();
        int n = variables[0], m = variables[1];
        var arr = new int[n, n];
        for (var i = 0; i < m; i++)
        {
            var pair = sr.ReadLine()!.Split().Select(int.Parse).ToArray();
            arr[pair[0] - 1, pair[1] - 1] = 1;
            arr[pair[1] - 1, pair[0] - 1] = 1;
        }

        return new InputData
        {
            N = n,
            M = m,
            Data = arr
        };
    }

    private class InputData
    {
        public int N { get; set; }
        public int M { get; set; }
        public required int[,] Data { get; set; }
    }
}