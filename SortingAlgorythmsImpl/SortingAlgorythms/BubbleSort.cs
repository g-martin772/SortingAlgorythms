using GenericDoubleLinkedListDLL;

namespace SortingAlgorythms;
public class BubbleSort : ISorter
{
    public void Sort(int[] arr)
    {
        // The outer loop iterates over the array
        for(int i = 0; i < arr.Length; i++)
            // While the inner loop compares the values
            for(int j = 0; j < arr.Length - i - 1; j++)
                if (arr[j] > arr[j + 1]) // If arr[j] is larger than arr[j + 1] then we swap them
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]); // This are tuples, you can figure out how to do it the simple way yourself ;)
    }
}

public class LinkedBubbleSort<T> : ILinkedListSorter<T> where T : IComparable<T>
{
    public void Sort(GenericLinkedList<T> list)
    {
        // The outer loop iterates over the array
        for(int i = 0; i < list.GetLenght(); i++)
            // While the inner loop compares the values
        for(int j = 0; j < list.GetLenght() - i - 1; j++)
            if (list[j].CompareTo(list[j + 1]) > 0) // If arr[j] is larger than arr[j + 1] then we swap them
                (list[j], list[j + 1]) = (list[j + 1], list[j]); // This are tuples, you can figure out how to do it the simple way yourself ;)
    }
}

