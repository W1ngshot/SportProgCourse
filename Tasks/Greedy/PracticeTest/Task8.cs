namespace Tasks.Greedy.PracticeTest;

public static class Task8
{
    public static void Solve()
    {
        var variables = Console.ReadLine()!.Split().Select(int.Parse).ToList();
        int n = variables[0], total = variables[1], maxDist = variables[2];
        var distances = InputData();
        distances.Insert(0, 0);
        var counter = 0L;
        var prevStop = total;

        for (int i = n - 1; i >= 0; i--)
        {
            if (prevStop - distances[i] > maxDist)
            {
                counter++;
                prevStop = distances[i + 1];
            }
        }
        
        Console.WriteLine(counter);
    }

    private static List<int> InputData()
    {
        using var  sr = new StreamReader("C:\\petrol2.in");
        var line = sr.ReadLine();
        var secondLine = sr.ReadLine();
        return secondLine!.Split().Select(int.Parse).ToList();   
    }
}