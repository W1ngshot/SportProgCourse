namespace Tasks.BruteForce.PracticeTest;

public class Task5
{
    private int _counter;
    private int _findIndex;
    private int _n;

    public void Solve(int n)
    {
        ResetIndexAndCounter();
        var arr = new int[n + 1];
        _n = n;
        Recursion(1, arr, 0);
    }

    private void Recursion(int index, int[] seq, int currentSum, int prev = 0)
    {
        if (currentSum >= _n)
        {
            if (currentSum == _n)
                WriteSequence(seq, index);
            return;
        }

        for (var i = Math.Max(prev, 1); i <= _n; i++)
        {
            seq[index] = i;
            Recursion(index + 1, seq, currentSum + i, i);
        }
    }

    private void WriteSequence(int[] seq, int index)
    {
        if (_findIndex != 0)
        {
            if (++_counter == _findIndex)
                Console.WriteLine(string.Join('+', seq.Skip(1).Take(index - 1)));
        }
        else
        {
            Console.WriteLine(string.Join('+', seq.Skip(1).Take(index - 1)));
        }
    }

    public void FindIndexElement(int n, int findIndex)
    {
        ResetIndexAndCounter();
        _findIndex = findIndex;
        var arr = new int[n + 1];
        _n = n;
        Recursion(1, arr, 0);
    }

    private void ResetIndexAndCounter()
    {
        _counter = 0;
        _findIndex = 0;
    }
}