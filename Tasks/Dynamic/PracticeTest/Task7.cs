namespace Tasks.Dynamic.PracticeTest;

public static class Task7
{
    public static void Solve()
    {
        var n = int.Parse(Console.ReadLine()!);
        var arr = InputData();
        var res = new long[n];
        var counter = new (long, long)[n];

        for (var i = 0; i < n; i++)
        {
            res[i] = 1;
            counter[i] = (1, 1);
            for (var j = 0; j < i; j++)
            {
                if (arr[i] > arr[j] && res[i] <= res[j] + 1)
                {
                    if (res[i] == res[j] + 1)
                    {
                        counter[i].Item2 += counter[j].Item2;
                    }
                    else
                    {
                        counter[i] = (res[j] + 1, counter[j].Item2);
                    }

                    res[i] = res[j] + 1;
                }
            }
        }

        var max = res.Max();
        Console.WriteLine(max);
        var sum = counter.Where(x => x.Item1 == max).Sum(x => x.Item2);
        Console.WriteLine(sum);
    }

    private static long[] InputData()
    {
        using var sr = new StreamReader("C:\\petrol2.in");
        var line = sr.ReadLine();
        var secondLine = sr.ReadLine();
        return secondLine!.Split().Select(long.Parse).ToArray();
    }
}