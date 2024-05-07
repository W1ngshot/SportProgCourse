namespace Tasks.BruteForce.PracticeTest;

public class Task7
{
    private int _counter;
    private int _findIndex;
    private int _n;
    private int _m;

    public void Solve(int n, int m)
    {
        ResetIndexAndCounter();
        var arr = new char[n + 1];
        _n = n;
        _m = m;
        Recursion(1, arr, 0);
    }

    private void Recursion(int index, char[] seq, int currentSum)
    {
        if (index > _n)
        {
            if (currentSum == _m)
                WriteSequence(seq);
            return;
        }

        for (var i = 0; i < 2; i++)
        {
            var ch = '.';
            if (i == 0)
            {
                if (index == 1 || currentSum < _m && seq[index - 1] == '.')
                    ch = '*';
                else
                    continue;
            }
            seq[index] = ch;
            Recursion(index + 1, seq, currentSum + (ch == '*' ? 1 : 0));
        }
    }

    private void WriteSequence(char[] seq)
    {
        if (_findIndex != 0)
        {
            if (++_counter == _findIndex)
                Console.WriteLine(string.Join("", seq.Skip(1)));
        }
        else
        {
            Console.WriteLine(string.Join("", seq.Skip(1)));
        }
    }

    public void FindIndexElement(int n, int m, int findIndex)
    {
        ResetIndexAndCounter();
        _findIndex = findIndex;
        var arr = new char[n + 1];
        _n = n;
        _m = m;
        Recursion(1, arr, 0);
    }

    private void ResetIndexAndCounter()
    {
        _counter = 0;
        _findIndex = 0;
    }
}