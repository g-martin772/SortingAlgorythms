namespace SortingAlgorythms;
public class SelectionSort : ISorter
{
    public void Sort(int[] arr)
    {
        // We loop over each element in the collection (-1 because the last element can only be on the right spot anyways)
        for (int i = 0; i < arr.Length - 1; i++)
        {
            // We get the index of the smalles (not already sorted) value in the array
            var min = i;
            for(int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[min])
                    min = j;
            }

            (arr[i], arr[min]) = (arr[min], arr[i]);
        }
    }
}
