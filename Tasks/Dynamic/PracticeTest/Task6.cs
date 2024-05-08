namespace Tasks.Dynamic.PracticeTest;

public static class Task6
{
    public static void Solve()
    {
        var variables = Console.ReadLine()!.Split().Select(int.Parse).ToList();
        int n = variables[0], s = variables[1];

        var arr = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

        var result = new int[s + 1];
        for (var i = 0; i < n; i++)
        {
            result[arr[i]] = 1;
        }
        

        for (var i = 1; i <= s; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (i - arr[j] > 0 && result[i - arr[j]] > 0)
                {
                    if (result[i] == 0 || result[i] > result[i - arr[j]] + 1)
                    {
                        result[i] = result[i - arr[j]] + 1;
                    }
                }
            }
        }
        
        Console.WriteLine(result[s]);
    }
}