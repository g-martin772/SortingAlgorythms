namespace SortingAlgorythms;

public class MergeSort : ISorter
{
    public void Sort(int[] arr)
    {
        Sort(arr, 0, arr.Length - 1);
    }

    void Sort(int[] arr, int left, int right)
    {
        // Here we divide the array into subarrays by calling this function recursivly until the right element is bigger than the left one
        if(left >= right)
            return;

        int middle = left + (right - left) / 2;
        Sort(arr, left, middle);
        Sort(arr, middle + 1, right);
        Merge(arr, left, middle, right);
    }

    void Merge(int[] arr, int left, int middle, int right)
    {
        // We copy the temporary data into two now temporary arrays
        // Note that leftArr and rightArr are just temporary and will get copied into the merged array at the end
        var leftLengh = middle - left + 1;
        var rightLengh = right - middle;
        var leftArr = new int[leftLengh];
        var rightArr = new int[rightLengh];

        for(int i = 0; i < leftLengh; ++i)
            leftArr[i] = arr[left + i];
        for(int i = 0; i < rightLengh; ++i)
            rightArr[i] = arr[middle + i + 1];


        // Now we can merge by comparing leftArr and rightArr and store the result at arr[temp] in the merged array
        int temp = left;

        int a = 0, b = 0;
        while(a < leftLengh && b < rightLengh)
        {
            if (leftArr[a] <= rightArr[b])
                arr[temp++] = leftArr[a++];
            else
                arr[temp++] = rightArr[b++];
        }

        // At the end we will copy any remaining elements from both temporary arrays
        while (a < leftLengh)
            arr[temp++] = leftArr[a++];

        while(b < rightLengh)
            arr[temp++] = rightArr[b++];
    }
}
