namespace Tasks.BruteForce.ExaminationTest;

public class Task8
{
    private int _counter;
    private int _findIndex;
    private int _n;

    public void Solve(int n)
    {
        ResetIndexAndCounter();
        var seq = new char[2 * n];
        _n = n;
        var opened = new Stack<char>();
        Recursion(0, seq, opened);
    }

    private void Recursion(int index, char[] seq, Stack<char> opened, int balance1 = 0,
        int balance2 = 0)
    {
        if (index >= 2 * _n)
        {
            if (balance1 == 0 && balance2 == 0)
                WriteSequence(seq);
            return;
        }

        for (var i = 0; i < 4; i++)
        {
            var ch = i switch
            {
                0 => '(',
                1 => ')',
                2 => '[',
                3 => ']',
                _ => ' '
            };

            seq[index] = ch;

            var newBalance1 = balance1 + ch switch
            {
                '(' => 1,
                ')' => -1,
                _ => 0
            };

            var newBalance2 = balance2 + ch switch
            {
                '[' => 1,
                ']' => -1,
                _ => 0
            };

            if (newBalance1 > _n || newBalance1 < 0 || newBalance2 > _n || newBalance2 < 0)
                continue;

            var newOpened = new Stack<char>(opened);
            switch (ch)
            {
                case '(' or '[':
                    newOpened.Push(ch);
                    break;
                case ')' when !newOpened.TryPop(out var el1) || el1 != '(':
                case ']' when !newOpened.TryPop(out var el2) || el2 != '[':
                    continue;
            }

            Recursion(index + 1, seq, new Stack<char>(newOpened), newBalance1, newBalance2);
        }
    }

    private void WriteSequence(char[] seq)
    {
        if (_findIndex != 0)
        {
            if (++_counter == _findIndex)
                Console.WriteLine(string.Join("", seq));
        }
        else
        {
            Console.WriteLine(string.Join("", seq));
        }
    }

    public void FindIndexElement(int n, int findIndex)
    {
        ResetIndexAndCounter();
        _findIndex = findIndex;
        var seq = new char[2 * n];
        _n = n;
        var opened = new Stack<char>();
        Recursion(0, seq, opened);
    }

    private void ResetIndexAndCounter()
    {
        _counter = 0;
        _findIndex = 0;
    }
}