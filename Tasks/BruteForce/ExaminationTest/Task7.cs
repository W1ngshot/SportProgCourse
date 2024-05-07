namespace Tasks.BruteForce.ExaminationTest;

public class Task7
{
    public void Solve(List<string> strings)
    {
        foreach (var isRight in strings.Select(IsRightString))
        {
            Console.WriteLine(isRight);
        }
    }

    private bool IsRightString(string s)
    {
        var stack = new Stack<char>();

        foreach (var ch in s)
        {
            switch (ch)
            {
                case '(':
                    stack.Push('(');
                    break;
                case '[':
                    stack.Push('[');
                    break;
                case ')':
                    if (!stack.TryPop(out var element) || element != '(')
                        return false;
                    break;
                case ']':
                    if (!stack.TryPop(out var element2) || element2 != '[')
                        return false;
                    break;
            }
        }

        return stack.Count == 0;
    }
}