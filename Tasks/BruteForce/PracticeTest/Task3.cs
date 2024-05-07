namespace Tasks.BruteForce.PracticeTest;

public class Task3
{
    private int _counter;
    private int _findIndex;
    
    public void Solve(int n)
    {
        ResetIndexAndCounter();
        var arr = new int[n + 1];
        var used = new bool[n + 1];
        Recursion(1, arr, used, n);
    }

    private void Recursion(int index, int[] seq, bool[] used, int n)
    {
        if (index > n)
        {
            WriteSequence(seq);
            return;
        }

        for (var i = 1; i <= n; i++)
        {
            if (used[i])
                continue;

            used[i] = true;
            seq[index] = i;
            Recursion(index + 1, seq, used, n);
            used[i] = false;
        }
    }

    private void WriteSequence(int[] seq)
    {
        if (_findIndex != 0)
        {
            if (++_counter == _findIndex)
                Console.WriteLine(string.Join(' ', seq.Skip(1)));
        }
        else
        {
            Console.WriteLine(string.Join(' ', seq.Skip(1)));
        }
    }

    public void FindIndexElement(int n, int findIndex)
    {
        ResetIndexAndCounter();
        _findIndex = findIndex;
        var arr = new int[n + 1];
        var used = new bool[n + 1];
        Recursion(1, arr, used, n);
    }

    private void ResetIndexAndCounter()
    {
        _counter = 0;
        _findIndex = 0;
    }
}