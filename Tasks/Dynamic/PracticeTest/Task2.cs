namespace Tasks.Dynamic.PracticeTest;

public static class Task2
{
    public static void Solve()
    {
        var variables = Console.ReadLine()!.Split().Select(int.Parse).ToList();
        int n = variables[0], m = variables[1];

        var arr = new long[n + 1];
        arr[0] = 1;
        arr[1] = 1;

        for (var i = 2; i <= n; i++)
        {
            arr[i] = (arr[i - 2] + arr[i - 1]) % m;
        }
        
        Console.WriteLine(arr[n]);
    }
}