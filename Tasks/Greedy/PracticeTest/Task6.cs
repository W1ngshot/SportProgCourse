namespace Tasks.Greedy.PracticeTest;

public static class Task6
{
    public static void Solve()
    {
        var n = int.Parse(Console.ReadLine()!);
        var orders = InputData(n);
        var sorted = orders.OrderBy(x => x.Item2).ToList();
        var prevRight = 0;
        var counter = 0L;

        foreach (var order in sorted)
        {
            if (order.Item1 >= prevRight)
            {
                counter++;
                prevRight = order.Item2;
            }
        }
        
        Console.WriteLine(counter);
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