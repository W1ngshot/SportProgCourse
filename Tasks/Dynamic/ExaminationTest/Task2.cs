namespace Tasks.Dynamic.ExaminationTest;

public static class Task2
{
    public static void Solve()
    {
        var input = GetInputData();

        var sumArray = new long[input.N][];

        for (var i = 0; i < input.N; i++)
        {
            sumArray[i] = new long[input.M];
            for (var j = 0; j < input.M; j++)
            {
                sumArray[i][j] += input.Data[i][j];
                if (i != 0)
                    sumArray[i][j] += sumArray[i - 1][j];
                if (j != 0)
                    sumArray[i][j] += sumArray[i][j - 1];
                if (i != 0 && j != 0)
                    sumArray[i][j] -= sumArray[i - 1][j - 1];
            }
        }

        var sum = 0L;
        for (var i = 0; i < input.Q; i++)
        {
            int x1 = input.Queries[i][0] - 1,
                x2 = input.Queries[i][1] - 1,
                y1 = input.Queries[i][2] - 1,
                y2 = input.Queries[i][3] - 1;

            sum += sumArray[x2][y2];
            if (x1 != 0)
                sum -= sumArray[x1 - 1][y2];
            if (y1 != 0)
                sum -= sumArray[x2][y1 - 1];
            if (x1 != 0 && y1 != 0)
                sum += sumArray[x1 - 1][y1 - 1];
        }

        Console.WriteLine(sum);
    }

    private static InputData GetInputData()
    {
        using var sr = new StreamReader("C:\\rectangle.in");
        var firstLine = sr.ReadLine();
        var variables = firstLine!.Split().Select(int.Parse).ToList();
        int n = variables[0], m = variables[1];
        var dataArray = new int[n][];

        for (var i = 0; i < n; i++)
        {
            var line = sr.ReadLine();
            var data = line!.Split().Select(int.Parse).ToArray();
            dataArray[i] = data;
        }

        var q = int.Parse(sr.ReadLine()!);
        var queries = new int[q][];

        for (var i = 0; i < q; i++)
        {
            var line = sr.ReadLine();
            var query = line!.Split().Select(int.Parse).ToArray();
            queries[i] = query;
        }

        return new InputData
        {
            N = n,
            M = m,
            Data = dataArray,
            Q = q,
            Queries = queries
        };
    }

    private class InputData
    {
        public int N { get; set; }
        public int M { get; set; }
        public required int[][] Data { get; set; }
        public int Q { get; set; }
        public required int[][] Queries { get; set; }
    }
}