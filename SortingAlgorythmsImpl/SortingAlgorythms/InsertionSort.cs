namespace SortingAlgorythms;
public class InsertionSort : ISorter
{
    public void Sort(int[] arr)
    {
        // The simplest of them all, we just iterate over the array begin inserting at the beginning
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j >= 0)
            {
                // If the correct location is found we break
                if (key >= arr[j])
                    break;

                // Otherwise we shift and insert the new element one further until the correct location is found
                arr[j + 1] = arr[j];
                j--;
                arr[j + 1] = key;
            }
        }
    }
}
