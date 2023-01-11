namespace SortingAlgorythms;
public class HeapSort : ISorter
{
    public void Sort(int[] arr)
    {
        if (arr.Length <= 1) return;

        // We are building the max heap
        for (int i = arr.Length / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, arr.Length, i);
        }

        // We swapt the last element of the max heap with the first element and then rebuild the heap again
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            (arr[0], arr[i]) = (arr[i], arr[0]);
            Heapify(arr, i, 0);
        }

        // Now the collection should be sorted correctly
    }

    void Heapify(int[] arr, int size, int i)
    {
        // First of all we set the maxIndex and the previous and next children (also refered to as left and right)
        var maxIndex = i;
        var prevChild = i * 2 + 1;
        var nextChild = i * 2 + 2;

        // Next we check if the previous child is greater than the root node, if so we swap their positions
        if(prevChild < size && arr[prevChild] > arr[maxIndex])
            maxIndex = prevChild;

        // Same thing for the nextChild
        if(nextChild < size && arr[nextChild] > arr[maxIndex])
            maxIndex = nextChild;

        // If the maximumm index of the array is equal to the current index, we can just return
        if(maxIndex == i)
            return;

        // Else we swap the alement at the current index with the element at the max index
        (arr[i], arr[maxIndex]) = (arr[maxIndex], arr[i]);
        // And we recursivly call Heapyfi until we built the max heap
        Heapify(arr, size, maxIndex);
    }
}
