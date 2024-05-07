namespace Tasks.BruteForce.PracticeTest;

public class Task4
{
    public void Solve(string s)
    {
        var isRight = IsRightString(s);
        Console.WriteLine(isRight);
    }

    private bool IsRightString(string s)
    {
        var balance = 0;
        foreach (var ch in s)
        {
            switch (ch)
            {
                case '(':
                    balance++;
                    break;
                case ')':
                    balance--;
                    break;
            }
            if (balance < 0)
                return false;
        }

        return balance == 0;
    }
}