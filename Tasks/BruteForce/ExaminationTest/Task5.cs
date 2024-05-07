namespace Tasks.BruteForce.ExaminationTest;

public class Task5
{
    private int _n;
    private int[][] _paths;
    private int _minSum = int.MaxValue;
    private bool[] _visited;
    private int[] _resultSequence;

    public void Solve(int n, int[][] paths)
    {
        _visited = new bool[n];
        _n = n;
        _paths = paths;
        _resultSequence = new int[n];
        var seq = new int[n];
        seq[0] = 0;
        Recursion(1, seq);
        WriteAnswer();
    }

    private void Recursion(int index, int[] seq, int prevIndex = 0, int sum = 0)
    {
        if (index >= _n)
        {
            if (sum + _paths[prevIndex][0] > _minSum)
                return;

            if (_minSum > sum + _paths[prevIndex][0] ||
                _minSum == sum + _paths[prevIndex][0] && _resultSequence[1] > seq[1])
                seq.CopyTo(_resultSequence, 0);
            _minSum = sum + _paths[prevIndex][0];
            return;
        }

        for (var i = 1; i < _n; i++)
        {
            if (_visited[i])
                continue;

            _visited[i] = true;
            seq[index] = i;
            Recursion(index + 1, seq, i, sum + _paths[prevIndex][i]);
            _visited[i] = false;
        }
    }

    private void WriteAnswer()
    {
        Console.WriteLine(_minSum);
        Console.WriteLine(string.Join(' ', _resultSequence));
    }

    public int[][] ParseToPaths(string s)
    {
        return s
            .Split('\n')
            .Select(x => x.Split(' ').Select(int.Parse).ToArray())
            .ToArray();
    }
}