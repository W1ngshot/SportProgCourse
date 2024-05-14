namespace Tasks.BitMasks.ExaminationTest;

public static class Task5
{
    public static void Solve()
    {
        var input = GetInputData();

        var res = new int[1 << input.N][];
        var path = new (int, int)[1 << input.N][];
        for (var i = 0; i < (1 << input.N); i++)
        {
            var arr = new int[input.N];
            var pathArr = new (int, int)[input.N];
            for (var j = 0; j < input.N; j++)
            {
                arr[j] = int.MaxValue;
            }

            res[i] = arr;
            path[i] = pathArr;
        }

        res[0][0] = 0;
        for (var mask = 0; mask < (1 << input.N); mask++)
        {
            for (var i = 0; i < input.N; i++)
            {
                if (res[mask][i] == int.MaxValue)
                    continue;
                for (var j = 0; j < input.N; j++)
                {
                    if ((mask & (1 << j)) != (1 << j) && res[mask | (1 << j)][j] > res[mask][i] + input.Data[i][j])
                    {
                        res[mask | (1 << j)][j] = res[mask][i] + input.Data[i][j];
                        path[mask | (1 << j)][j] = (mask, i);
                    }
                }
            }
        }

        Console.WriteLine(res[(1 << input.N) - 1][0]);
        var pathList = new List<int>();
        int a = (1 << input.N) - 1, b = 0;
        while (a != 0 || b != 0)
        {
            pathList.Add(b);
            (a, b) = path[a][b];
        }

        if (pathList.Count <= 1)
        {
            Console.WriteLine(string.Join(' ', pathList));
            return;
        }

        var reversePathList = new List<int> {0};
        for (var i = pathList.Count - 1; i > 0; i--)
        {
            reversePathList.Add(pathList[i]);
        }

        Console.WriteLine(pathList[1] < reversePathList[1]
            ? string.Join(' ', pathList)
            : string.Join(' ', reversePathList));
    }

    private static InputData GetInputData()
    {
        using var sr = new StreamReader("C:\\salesman2.in");
        var n = int.Parse(sr.ReadLine()!);
        var arr = new int[n][];
        for (var i = 0; i < n; i++)
        {
            var line = sr.ReadLine()!.Split().Select(int.Parse).ToArray();
            arr[i] = line;
        }

        return new InputData
        {
            N = n,
            Data = arr
        };
    }

    private class InputData
    {
        public int N { get; set; }
        public required int[][] Data { get; set; }
    }
}