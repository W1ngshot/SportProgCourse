namespace Tasks.BitMasks.PracticeTest;

public static class Task6
{
    public static void Solve()
    {
        var variables = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        int n = variables[0], m = variables[1], k = variables[2];
        if (n > m)
            (n, m) = (m, n);

        var d = new long[m + 1, 1 << n];
        d[0, 0] = 1;

        for (var i = 0; i < m; i++)
        for (var mask = 0; mask < (1 << n); mask++)
        {
            for (var newMask = 0; newMask < (1 << n); newMask++)
                if (Can(mask, newMask, n))
                    d[i + 1, newMask] = (d[i + 1, newMask] + d[i, mask]) % k;
        }

        Console.WriteLine(d[m, 0]);
    }

    private static bool Can(int mask, int newMask, int n)
    {
        if ((mask & newMask) != 0)
            return false;

        var orMask = mask | newMask;

        var i = 0;
        while ((1 << n) > (1 << i))
        {
            if ((orMask & (1 << i)) == 0)
            {
                if ((1 << n) <= (1 << (i + 1)) || (orMask & (1 << (i + 1))) != 0)
                    return false;
                i++;
            }
            i++;
        }

        return true;
    }
}