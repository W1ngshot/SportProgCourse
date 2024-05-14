namespace Tasks.BitMasks.ExaminationTest;

public static class Task4
{
    public static void Solve()
    {
        var n = int.Parse(Console.ReadLine()!);
        var numbers = InputData();

        var result = new int[n];

        for (var i = 0; i < n; i++)
        {
            var j = 0;
            while ((1 << j) <= numbers[i])
            {
                if (((1 << j) & numbers[i]) == (1 << j))
                    result[i]++;
                j++;
            }
        }
        
        Console.WriteLine(string.Join(' ', result));
    }

    private static int[] InputData()
    {
        using var sr = new StreamReader("C:\\ones.in ");
        var line = sr.ReadLine();
        var secondLine = sr.ReadLine();
        return secondLine!.Split().Select(int.Parse).ToArray();
    }
}