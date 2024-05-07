namespace Tasks.Greedy.ExaminationTest;

public static class Task7
{
    public static void Solve()
    {
        var n = int.Parse(Console.ReadLine()!);
        var requests = InputData(n);
        var sorted = requests.OrderBy(x => x.Item1).ToList();
        var queue = new PriorityQueue<(int, int), int>();
        var counter = 0;

        foreach (var request in sorted)
        {
            while (queue.TryPeek(out _, out var priority) && priority <= request.Item1)
            {
                queue.Dequeue();
            }

            if (counter <= queue.Count) 
                counter++;

            queue.Enqueue((request.Item1, request.Item2), request.Item2);
        }

        Console.WriteLine(counter);
    }

    private static List<(int, int)> InputData(int n)
    {
        var requests = new List<(int, int)>();
        for (var i = 0; i < n; i++)
        {
            var request = Console.ReadLine()!.Split().Select(int.Parse).ToList();
            requests.Add((request[0], request[1]));
        }

        return requests;
    }
}