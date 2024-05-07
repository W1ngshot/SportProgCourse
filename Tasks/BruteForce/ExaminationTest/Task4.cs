namespace Tasks.BruteForce.ExaminationTest;

public class Task4
{
    private int _counter;
    private int _findIndex;
    private int _n;

    public void Solve(int n)
    {
        ResetIndexAndCounter();
        var arr = new char[2 * n + 1];
        _n = n;
        Recursion(1, arr, 0);
    }

    private void Recursion(int index, char[] seq, int leftCount = 0, int balance = 0)
    {
        if (index > 2 * _n)
        {
            if (leftCount == _n)
                WriteSequence(seq);
            return;
        }

        for (var i = 0; i < 2; i++)
        {
            if (balance < 0)
                return;

            var ch = ')';
            if (i == 0)
            {
                if (leftCount < _n)
                    ch = '(';
                else
                    continue;
            }

            var leftInc = ch == '(' ? 1 : 0;
            var balanceInc = ch == '(' ? 1 : -1;

            seq[index] = ch;
            Recursion(index + 1, seq, leftCount + leftInc, balance + balanceInc);
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

    public void FindIndexElement(int n, int findIndex)
    {
        ResetIndexAndCounter();
        _findIndex = findIndex;
        var arr = new char[2 * n + 1];
        _n = n;
        Recursion(1, arr, 0);
    }

    private void ResetIndexAndCounter()
    {
        _counter = 0;
        _findIndex = 0;
    }
}