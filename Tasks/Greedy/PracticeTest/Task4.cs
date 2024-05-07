namespace Tasks.Greedy.PracticeTest;

public static class Task4
{
    public static void Solve()
    {
        var n = int.Parse(Console.ReadLine()!);
        var orders = InputData(n);
        var sorted = orders.OrderByDescending(x => x.Item2).ToList();   
        var sum = 0L;
        var used = new bool[n];

        foreach (var order in sorted)
        {
            var k = Math.Min(order.Item1, n - 1);
            while (k >= 1 && used[k])
            {
                k--;
            }
            if (k == 0)
                continue;
            used[k] = true;
            sum += order.Item2;
        }
        
        Console.WriteLine(sum);
    }

    private static List<(int, int)> InputData(int n)
    {
        var orders = new List<(int, int)>();
        for (var i = 0; i < n; i++)
        {
            var order = Console.ReadLine()!.Split().Select(int.Parse).ToList();
            orders.Add((order[0], order[1]));
        }

        return orders;
    }
}