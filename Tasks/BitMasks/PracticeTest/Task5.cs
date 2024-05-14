namespace Tasks.BitMasks.PracticeTest;

public static class Task5
{
    public static void Solve()
    {
        var n = int.Parse(Console.ReadLine()!);
        var search = int.Parse(Console.ReadLine()!);

        var arr = new long[1 << n];

        for (var i = 0; i < 1 << n; i++)
        {
            arr[i] = (1 << n) - 1 - i;
        }

        var result = arr[search - 1];
        var numbers = new List<int>();
        
        for (var i = n - 1; i >= 0; i--)
        {
            if ((result & (1 << i)) == (1 << i))
                numbers.Add(n - i);
        }
        
        Console.WriteLine('{' + string.Join(',', numbers) + '}');
    }
}