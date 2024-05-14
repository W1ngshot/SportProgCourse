namespace Tasks.Dynamic.ExaminationTest;

public static class Task6
{
    public static void Solve()
    {
        var input = GetInputData();

        var d = new int[input.N1 + 1][];
        var sequences = new (int, int)[input.N1 + 1][];
        for (var i = 0; i <= input.N1; i++)
        {
            d[i] = new int[input.N2 + 1];
            sequences[i] = new (int, int)[input.N2 + 1];
        }

        for (var i = 1; i <= input.N1; i++)
        {
            for (var j = 1; j <= input.N2; j++)
            {
                if (d[i - 1][j] > d[i][j - 1])
                {
                    d[i][j] = d[i - 1][j];
                    sequences[i][j] = (i - 1, j);
                }
                else
                {
                    d[i][j] = d[i][j - 1];
                    sequences[i][j] = (i, j - 1);
                }

                if (input.Data1[i - 1] == input.Data2[j - 1] && d[i - 1][j - 1] + 1 > d[i][j])
                {
                    d[i][j] = d[i - 1][j - 1] + 1;
                    sequences[i][j] = (i - 1, j - 1);
                }
            }
        }

        Console.WriteLine(d[input.N1][input.N2]);
        var sequence = new List<int>();
        int first = input.N1, second = input.N2;
        while (sequences[first][second] != (0, 0))
        {
            var (newFirst, newSecond) = sequences[first][second];
            if (first - newFirst == 1 && second - newSecond == 1)
                sequence.Add(input.Data2[newSecond]);
            (first, second) = (newFirst, newSecond);
        }

        sequence.Reverse();
        Console.WriteLine(string.Join(' ', sequence));
    }

    private static InputData GetInputData()
    {
        using var sr = new StreamReader("C:\\seq2.in");
        var n1 = int.Parse(sr.ReadLine()!);
        var data1 = sr.ReadLine()!.Split().Select(int.Parse).ToArray();
        var n2 = int.Parse(sr.ReadLine()!);
        var data2 = sr.ReadLine()!.Split().Select(int.Parse).ToArray();

        return new InputData
        {
            N1 = n1,
            Data1 = data1,
            N2 = n2,
            Data2 = data2
        };
    }

    private class InputData
    {
        public int N1 { get; set; }
        public int N2 { get; set; }
        public required int[] Data1 { get; set; }
        public required int[] Data2 { get; set; }
    }
}