namespace SortingAlgorythms;
public class ShellSort : ISorter
{
    public void Sort(int[] arr)
    {
        // We use Shell's original sequnce as the outer loop and we keep dividing the gap by 2 until it matches 1
        for (int interval = arr.Length / 2; interval > 0; interval /= 2)
        {
            // For every interval we use insertion sort to compare and swap the elements
            for (int i = interval; i < arr.Length; i++)
            {
                var key = arr[i];
                var temp = i;

                while (temp >= interval && arr[temp - interval] > key)
                {
                    arr[temp] = arr[temp - interval];
                    temp -= interval;
                }
                
                arr[temp] = key;
            }
        }
    }
}
