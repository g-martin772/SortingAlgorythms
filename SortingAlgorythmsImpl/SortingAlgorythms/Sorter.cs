using System.Diagnostics;

namespace SortingAlgorythms;

public interface ISorter
{
    public void Sort(int[] arr);
}

public class SorterContext
{
    private ISorter _sorter;
    public void SetContext(ISorter sorter)
    {
        _sorter = sorter;
    }

    public long Sort(int[] arr)
    {
        var sw = new Stopwatch();
        sw.Start();
        _sorter.Sort(arr);
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }
}
