using System.Diagnostics;
using SortingAlgorythms;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using GenericDoubleLinkedListDLL;

namespace Test;

public static class Program
{
    static void Main(string[] args)
    {
        var summary1 = BenchmarkRunner.Run<SortingBenchmark>();
        Console.WriteLine(summary1);
    }
    
    [MemoryDiagnoser]
    [ThreadingDiagnoser]
    [ExceptionDiagnoser]  
    public class SortingBenchmark
    {
        [Params(10, 100, 1000)]
        public int N;
        
        public GenericLinkedList<int> list;
        
        [GlobalSetup]
        public void Setup()
        {
            list = new GenericLinkedList<int>();
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                list.Append(rnd.Next(1, 100));
            }
        }

        [Benchmark]
        public void MergeSort()
        {
            list.SetSortBehaviour(new LinkedMergeSort<int>());
            list.Sort();
        }
        
        [Benchmark]
        public void QuickSort()
        {
            list.SetSortBehaviour(new LinkedQuciksort<int>());
            list.Sort();
        }
    }
    
   
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    private static void TestSorting()
    {
        SorterContext context = new();

        int[] test = new int[(long)Math.Pow(10, 5)];

        Random rnd = new Random();
        for (int i = 0; i < test.Length; i++)
        {
            test[i] = rnd.Next(-10000000, 10000000);
        }

        context.SetContext(new Quicksort());
        var t1 = (int[])test.Clone();
        Console.WriteLine("Starting Quicksort");
        var elapsed1 = context.Sort(t1);
        Console.WriteLine("Quicksort Done");

        context.SetContext(new SelectionSort());
        var t2 = (int[])test.Clone();
        Console.WriteLine("Starting Selectionsort");
        var elapsed2 = context.Sort(t2);
        Console.WriteLine("Selectionsort Done");

        context.SetContext(new InsertionSort());
        var t3 = (int[])test.Clone();
        Console.WriteLine("Starting InsertionSort");
        var elapsed3 = context.Sort(t3);
        Console.WriteLine("InsertionSort Done");

        context.SetContext(new BubbleSort());
        var t4 = (int[])test.Clone();
        Console.WriteLine("Starting BubbleSort");
        var elapsed4 = context.Sort(t4);
        Console.WriteLine("BubbleSort Done");


        context.SetContext(new MergeSort());
        var t5 = (int[])test.Clone();
        Console.WriteLine("Starting MergeSort");
        var elapsed5 = context.Sort(t5);
        Console.WriteLine("MergeSort Done");

        context.SetContext(new ShellSort());
        var t6 = (int[])test.Clone();
        Console.WriteLine("Starting ShellSort");
        var elapsed6 = context.Sort(t6);
        Console.WriteLine("ShellSort Done");

        context.SetContext(new HeapSort());
        var t7 = (int[])test.Clone();
        Console.WriteLine("Starting HeapSort");
        var elapsed7 = context.Sort(t7);
        Console.WriteLine("HeapSort Done");

        t2.ToList().ForEach(s => Console.WriteLine(s));
        Console.WriteLine($"Quicksort: {elapsed1}ms have passed");
        Console.WriteLine($"SelectionSort: {elapsed2}ms have passed");
        Console.WriteLine($"InsertionSort: {elapsed3}ms have passed");
        Console.WriteLine($"BubbleSort: {elapsed4}ms have passed");
        Console.WriteLine($"MergeSort: {elapsed5}ms have passed");
        Console.WriteLine($"ShellSort: {elapsed6}ms have passed");
        Console.WriteLine($"HeapSort: {elapsed7}ms have passed");
    }

    public static int SequentialSearch(this int[] arr, int e)
    {
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == e) return i;
        return -1;
    }

    static int BinarySearch(this int[] arr, int i)
    {
        int low = 0, high = arr.Length - 1, mid;

        while (low <= high)
        {
            mid = (low + high) / 2;

            if (i < arr[mid])
                high = mid - 1;

            else if (i > arr[mid])
                low = mid + 1;

            else
                return mid;
        }
        return -1;
    }
}
