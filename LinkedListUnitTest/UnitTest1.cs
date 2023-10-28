using GenericDoubleLinkedListDLL;
using NUnit.Framework;
using SortingAlgorythms;

namespace LinkedListUnitTest;

public class TestSorting
{
    public GenericLinkedList<int> list;
    
    [Test]
    public void TestQuickSort()
    {
        list.SetSortBehaviour(new LinkedQuciksort<int>());
        list.Sort();

        Console.WriteLine(list);
        Assert.That(list.IsSorted, Is.True);
    }
    
    [Test]
    public void TestMergeSort()
    {
        list.SetSortBehaviour(new LinkedMergeSort<int>());
        list.Sort();
       
        Assert.That(list.IsSorted, Is.True); 
    }
    
    [Test]
    public void TestBubbleSort()
    {
        list.SetSortBehaviour(new LinkedBubbleSort<int>());
        list.Sort();

        Console.WriteLine(list);
        Assert.That(list.IsSorted, Is.True);
    }
    
    [Test]
    public void TestInsertionSort()
    {
        list.SetSortBehaviour(new LinkedQuciksort<int>());
        list.Sort();
       
        Assert.That(list.IsSorted, Is.True);
    }
    
    [Test]
    public void TestSelectionSort()
    {
        list.SetSortBehaviour(new LinkedQuciksort<int>());
        list.Sort();
       
        Assert.That(list.IsSorted, Is.True);
    }
}

[TestFixture]
public class Test100 : TestSorting
{
    [SetUp]
    public void Setup()
    {
        list = new GenericLinkedList<int>();
        Random rnd = new Random();
        for (int i = 0; i < 100; i++)
        {
            list.Append(rnd.Next(1, 100));
        }
    }
}

[TestFixture]
public class Test1000 : TestSorting
{
    [SetUp]
    public void Setup()
    {
        list = new GenericLinkedList<int>();
        Random rnd = new Random();
        for (int i = 0; i < 1000; i++)
        {
            list.Append(rnd.Next(1, 10000));
        }
    }
}

[TestFixture]
public class Test10000 : TestSorting
{
    [SetUp]
    public void Setup()
    {
        list = new GenericLinkedList<int>();
        Random rnd = new Random();
        for (int i = 0; i < 10000; i++)
        {
            list.Append(rnd.Next(1, 1000000));
        }
    }
}