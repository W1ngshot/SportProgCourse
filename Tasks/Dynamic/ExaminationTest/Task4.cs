namespace Tasks.Dynamic.ExaminationTest;

public static class Task4
{
    public static void Solve()
    {
        var input = GetInputData();
        var res = new long[input.N + 1][];
        var path = new (int, int, bool)[input.N + 1][];
        for (var i = 0; i <= input.N; i++)
        {
            res[i] = new long[input.W + 1];
            path[i] = new (int, int, bool)[input.W + 1];
        }

        for (var i = 0; i < input.N; i++)
        {
            for (var j = 0; j < input.W; j++)
            {
                if (j + input.Data[i + 1].Item1 <= input.W)
                {
                    if (res[i + 1][j + input.Data[i + 1].Item1] < res[i][j] + input.Data[i + 1].Item2)
                    {
                        res[i + 1][j + input.Data[i + 1].Item1] = res[i][j] + input.Data[i + 1].Item2;
                        path[i + 1][j + input.Data[i + 1].Item1] = (i, j, true);
                    }
                }

                if (res[i + 1][j] < res[i][j])
                {
                    res[i + 1][j] = res[i][j];
                    path[i + 1][j] = (i, j, false);
                }
            }
        }

        var max = res.Max(x => x[input.W]);
        Console.WriteLine(max);
        for (var i = input.N; i >= 1; i--)
        {
            if (res[i][input.W] == max)
            {
                var items = new List<int>();
                int first = i, second = input.W;
                var isAdd = false;
                var sum = 0L;
                while (path[first][second] != (0, 0, false) || isAdd)
                {
                    if (isAdd)
                    {
                        items.Add(first + 1);
                    }

                    (first, second, isAdd) = path[first][second];
                }

                foreach (var item in items)
                {
                    sum += input.Data[item].Item2;
                }

                Console.WriteLine(string.Join(' ', items.OrderBy(x => x)));
                Console.WriteLine(sum);
                break;
            }
        }
    }

    private static InputData GetInputData()
    {
        using var sr = new StreamReader("C:\\rucksack.in");
        var firstLine = sr.ReadLine();
        var variables = firstLine!.Split().Select(int.Parse).ToList();
        int n = variables[0], w = variables[1];
        var dataArray = new (long, long)[n + 1];

        for (var i = 1; i <= n; i++)
        {
            var line = sr.ReadLine();
            var data = line!.Split().Select(int.Parse).ToArray();
            dataArray[i] = (data[0], data[1]);
        }

        return new InputData
        {
            N = n,
            W = w,
            Data = dataArray,
        };
    }

    private class InputData
    {
        public int N { get; set; }
        public int W { get; set; }
        public required (long, long)[] Data { get; set; }
    }
}