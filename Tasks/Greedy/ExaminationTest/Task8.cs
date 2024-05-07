namespace Tasks.Greedy.ExaminationTest;

public static class Task8
{
    public static void Solve()
    {
        var variables = Console.ReadLine()!.Split().Select(int.Parse).ToList();
        int n = variables[0], t = variables[1];
        var tasksTimes = InputData();
        var sorted = tasksTimes.OrderBy(x => x).ToList();
        var counter = 0;
        var penaltySum = 0L;
        var timeSum = 0L;

        foreach (var taskTime in sorted)
        {
            if (taskTime + timeSum > t)
                break;
            timeSum += taskTime;
            counter++;
            penaltySum += timeSum;
        }

        Console.WriteLine($"{counter} {penaltySum}");
    }

    private static List<int> InputData()
    {
        using var  sr = new StreamReader("C:\\contest.in");
        var line = sr.ReadLine();
        var secondLine = sr.ReadLine();
        return secondLine!.Split().Select(int.Parse).ToList();  
    }
}