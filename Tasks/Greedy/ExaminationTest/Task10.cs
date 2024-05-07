namespace Tasks.Greedy.ExaminationTest;

public class Task10
{
    public static void Solve()
    {
        var n = int.Parse(Console.ReadLine()!);
        var items = InputData(n);
        var set = new HashSet<string>();
        var counter = 1;

        foreach (var item in items)
        {
            if (set.Contains(item))
            {
                counter++;
                set.Clear();
            }
            set.Add(item);
        }

        Console.WriteLine(counter);
    }

    private static List<string> InputData(int n)
    {
        var items = new List<string>();
        for (var i = 0; i < n; i++)
        {
            var item = Console.ReadLine()!;
            items.Add(item);
        }

        return items;
    }
}