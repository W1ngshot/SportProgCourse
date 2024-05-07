namespace Tasks.Greedy.ExaminationTest;

public static class Task5
{
    public static void Solve()
    {
        var variables = Console.ReadLine()!.Split().Select(int.Parse).ToList();
        int n = variables[0], w = variables[1];
        var items = InputData(n);
        var sorted = items.OrderByDescending(x => x.Item2 / x.Item1).ToList();
        var priceSum = 0d;
        var weightSum = 0L;

        foreach (var item in sorted)
        {
            if (weightSum + item.Item1 < w)
            {
                weightSum += item.Item1;
                priceSum += item.Item2;
            }
            else if (w - weightSum > 0)
            {
                priceSum += (double)(w - weightSum) * item.Item2 / item.Item1;
                weightSum = w;
            }
        }

        Console.WriteLine(priceSum);
    }

    private static List<(int, int)> InputData(int n)
    {
        var items = new List<(int, int)>();
        for (var i = 0; i < n; i++)
        {
            var item = Console.ReadLine()!.Split().Select(int.Parse).ToList();
            items.Add((item[0], item[1]));
        }

        return items;
    }
}