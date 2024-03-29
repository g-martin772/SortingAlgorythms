﻿using GenericDoubleLinkedListDLL;

namespace SortingAlgorythms;
public class Quicksort : ISorter
{
    public int[] Sort(int[] arr, int left, int right)
    {
        // We set our starting index to the left and right end of the array
        var i = left;
        var j = right;
        // We select a pivot, in our case the first one
        var pivot = arr[left];

        // We loop until left and right hit each other
        while (i <= j)
        {

            // As long as the element left to the pivot is smaller we skip it
            while (arr[i] < pivot)
                i++;
            
            // And the same in the other direction
            while (arr[j] > pivot)
                j--;
            
            // Now we are at the part where the action happens
            // If an element in the left subtree is greater than the pivot or vice verca, we swap them
            if (i <= j)
            {
                (arr[j], arr[i]) = (arr[i], arr[j]);
                i++;
                j--;
            }
        }

        // Since quicksort is recursive we pass down the left and right subtrees to be sorted
        if (left < j)
            Sort(arr, left, j);
        if (i < right)
            Sort(arr, i, right);

        // And finally we return the sulult
        return arr;
    }

    public void Sort(int[] arr)
    {
        // We start the recursive sort, on the entire array
        Sort(arr, 0, arr.Length-1);
    }
}

public class LinkedQuciksort<T> : ILinkedListSorter<T> where T : IComparable<T>
{
    public GenericLinkedList<T> Sort(GenericLinkedList<T>  list, int left, int right)
    {
        // We set our starting index to the left and right end of the array
        var i = left;
        var j = right;
        // We select a pivot, in our case the first one
        var pivot = list[left];

        // We loop until left and right hit each other
        while (i <= j)
        {

            // As long as the element left to the pivot is smaller we skip it
            while (list[i].CompareTo(pivot) < 0)
                i++;
            
            // And the same in the other direction
            while (list[j].CompareTo(pivot) > 0)
                j--;
            
            // Now we are at the part where the action happens
            // If an element in the left subtree is greater than the pivot or vice verca, we swap them
            if (i <= j)
            {
                (list[j], list[i]) = (list[i], list[j]);
                i++;
                j--;
            }
        }

        // Since quicksort is recursive we pass down the left and right subtrees to be sorted
        if (left < j)
            Sort(list, left, j);
        if (i < right)
            Sort(list, i, right);

        // And finally we return the sulult
        return list;
    }

    public void Sort(GenericLinkedList<T> list)
    {
        Sort(list, 0, list.GetLenght());
    }
}

