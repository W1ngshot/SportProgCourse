namespace Tasks.BitMasks.ExaminationTest;

public static class Task7
{
    public static void Solve()
    {
        var input = GetInputData();
        var dict = new Dictionary<long, int>();
        var results = new HashSet<long>();

        for (long mask = 0; mask < (1 << input.N); mask++)
        {
            dict[mask] = 0;
            var isAns = true;
            for (var i = 0; i < input.N; i++)
            {
                if ((mask & (1 << i)) == (1 << i))
                    dict[mask]++;
                else
                    continue;

                for (var j = i + 1; j < input.N; j++)
                {
                    if ((mask & (1 << j)) != (1 << j))
                        continue;

                    if (input.Data[i, j] != 1)
                    {
                        isAns = false;
                        break;
                    }
                }
                
                if (!isAns)
                    break;
            }

            if (isAns)
                results.Add(mask);
        }

        var max = results.Max(result => dict[result]);
        Console.WriteLine(max);
    }

    private static InputData GetInputData()
    {
        using var sr = new StreamReader("C:\\friends2.in");
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