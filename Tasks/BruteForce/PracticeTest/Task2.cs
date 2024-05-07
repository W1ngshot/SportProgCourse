namespace Tasks.BruteForce.PracticeTest;

public class Task2
{
    private int _counter;
    private int _findIndex;
    
    public void Solve(int n, int m)
    {
        ResetIndexAndCounter();
        var arr = new int[n + 1];
        Recursion(1, arr, n, m);
    }

    private void Recursion(int index, int[] seq, int n, int m)
    {
        if (index > n)
        {
            WriteSequence(seq);
            return;
        }

        for (var i = 1; i <= m; i++)
        {
            seq[index] = i;
            Recursion(index + 1, seq, n, m);
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

    public void FindIndexElement(int n, int m, int findIndex)
    {
        ResetIndexAndCounter();
        _findIndex = findIndex;
        var arr = new int[n + 1];
        Recursion(1, arr, n, m);
    }

    private void ResetIndexAndCounter()
    {
        _counter = 0;
        _findIndex = 0;
    }
}