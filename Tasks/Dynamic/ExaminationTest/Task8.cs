namespace Tasks.Dynamic.ExaminationTest;

public static class Task8
{
    public static void Solve()
    {
        var input = GetInputData();
        var arr = new Dictionary<int, bool>[input.N];

        for (var i = 0; i < input.N; i++)
        {
            var num = input.Data[i];
            arr[i] = new Dictionary<int, bool>();
            if (i == 0)
            {
                arr[i][num] = false;
            }
            else
            {
                foreach (var key in arr[i - 1].Keys)
                {
                    arr[i][key + num] = true;
                    arr[i][key - num] = false;
                }
            }
        }

        var list = new string[2 * input.N - 1];
        var next = input.X;
        for (var i = input.N - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                list[i] = input.Data[i].ToString();
            }
            else
            {
                list[i * 2] = input.Data[i].ToString();
                list[i * 2 - 1] = arr[i][next] ? "+" : "-";
                
                if (arr[i][next])
                {
                    next -= input.Data[i];
                }
                else
                {
                    next += input.Data[i];
                }
            }
        }

        Console.WriteLine(string.Join("", list));
    }

    private static InputData GetInputData()
    {
        using var sr = new StreamReader("C:\\arithm2.in");
        var variables = sr.ReadLine()!.Split().Select(int.Parse).ToArray();
        var data = sr.ReadLine()!.Split().Select(int.Parse).ToArray();

        return new InputData
        {
            N = variables[0],
            X = variables[1],
            Data = data,
        };
    }

    private class InputData
    {
        public int N { get; set; }
        public int X { get; set; }
        public required int[] Data { get; set; }
    }
}