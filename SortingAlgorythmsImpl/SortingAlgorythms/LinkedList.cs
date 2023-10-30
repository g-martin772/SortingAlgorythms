using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Xml;
using SortingAlgorythms;

namespace GenericDoubleLinkedListDLL;

public class Node<T> where T : IComparable<T> 
{
    public Node<T>? Prev, Next;
    public T Data;
}

public class GenericLinkedList<T> where T : IComparable<T> 
{
    public Node<T>? Head { get; set; }
    public Node<T>? Tail { get; set; }

    private ILinkedListSorter<T> sortBeh;

    public void SetSortBehaviour(ILinkedListSorter<T> beh)
    {
        this.sortBeh = beh;
    }

    public void Sort()
    {
        sortBeh.Sort(this);
    }

    public void Override(GenericLinkedList<T> list)
    {
        this.Head = list.Head;
        this.Tail = list.Tail;
    }

    public void InsertFront(T value)
    {
        InsertFront(new Node<T>(){Data = value});
    }
    
    public void InsertFront(Node<T> newNode)
    {
        if (Head==null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
        }
    }
    public void Append(Node<T> newNode)
    {
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Prev = Tail;
            Tail.Next = newNode;
            Tail = newNode;
        }
    }

    public void InsertSorted(Node<T> newNode)
    {
        newNode.Next = null;
        newNode.Prev = null;
        if (Head == null && Tail == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else if(IsSorted())
        {
            if (Head.Data.CompareTo(newNode.Data) >= 0)
            {
                InsertFront(newNode);
            }
            else if(Tail.Data.CompareTo(newNode.Data) <= 0)
            {
                Append(newNode);
            }
            else
            {
                Node<T> temp = Head;
                while (temp.Next != null && 
                       temp.Next.Data.CompareTo(newNode.Data) <= 0)
                {temp = temp.Next;}

                newNode.Next = temp.Next;
                temp.Next = newNode;
                newNode.Next.Prev = newNode;
                newNode.Prev = temp;
            }
        }
        else
        {
            throw new Exception();
        }
    }

    public void InsertSortedRec(Node<T> newNode)
    {
        throw new NotImplementedException();
    }
    

    public void Append(T value)
    {
        Node<T> node = new Node<T>(){Data = value};
        Append(node);
    }

    public void InsertSorted(T value)
    {
        Node<T> n = new Node<T>() { Data = value };
        InsertSorted(n);
    }

    public void InsertSortedRec(T value)
    {
        throw new NotImplementedException();
    }

    public void PrintList()
    {
        if (Head != null)
        {
            Node<T> temp = Head;
            while (temp != null)
            {
                Console.WriteLine($"{temp.Data}, ");
                temp = temp.Next;
            }

            Console.WriteLine();
        }
    }

    public void PrintListReverse()
    {
        if (Head != null)
        {
            Node<T> temp = Tail;
            while (temp != null)
            {
                Console.WriteLine($"{temp.Data}, ");
                temp = temp.Prev;
            }

            Console.WriteLine();
        }
    }

    public bool Contains(T value)
    {
        return Find(value) == null ? false : true;
    }
    public Node<T> Find(T value)
    {
        return Find(Head, value);
    }
    public Node<T> Find(Node<T> start, T value)
    {
        while (start != null)
        {
            if (value.CompareTo(start.Data) == 0)
            {
                return start;
            }
            start = start.Next;
        }
        return null;
    }
    

    public Node<T> Remove(T value)
    {
        return Remove(Find(value));
    }
    public Node<T>? Remove(Node<T> value)
    {
        if (Head == null)
            return null;
        
        for (var temp = Head; temp != null; temp = temp.Next)
        {
            if (value != temp) continue;

            if (Head == value) Head = Head.Next;
            if (Tail == value) Tail = Tail.Prev;

            if (temp.Prev != null) temp.Prev.Next = temp.Next;
            if (temp.Next != null) temp.Next.Prev = temp.Prev;

            value.Next = null;
            value.Prev = null;
            return value;
        }

        return null;
    }

    public bool IsSorted()
    {
        for (Node<T> temp = Head; temp != null; temp = temp.Next)
        {
            if (temp.Next != null)
            {
                if (temp.Data.CompareTo(temp.Next.Data) > 0)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public bool IsSortedRec()
    {
        return IsSortedRec(Head);
    }

    public bool IsSortedRec(Node<T> temp)
    {
        if (Head == null)
        {
            return false;
        }
        if (temp.Next != null)
        {
            if (temp.Data.CompareTo(temp.Next.Data) < 0)
            {
                return false;
            }

            return IsSortedRec(temp.Next); // Hier den Rückgabewert des rekursiven Aufrufs verwenden
        }

        return true;
    }


    public void Swap(Node<T> n1, Node<T> n2)
    {
        if (n1 == Head || n1 == Tail || n2 == Head || n2 == Tail)
        {
            if (n1 == Head && n2 == Tail)
            {
                (n1.Next.Prev, n2.Prev.Next) = (n2, n1);
                (n1.Prev, n2.Prev) = (n2.Prev, null);
                (n1.Next, n2.Next) = (null, n1.Next);
                Head = n2;
                Tail = n1;
            }
            else if (n2 == Head && n1 == Tail)
            {
                (n1.Prev.Next, n2.Prev.Next) = (n2, n1);
                (n1.Prev, n2.Prev) = (n2.Prev, null);
                (n1.Next, n2.Next) = (n2.Next, null);
                Head = n1;
                Tail = n2;
            }
            else if (n1 == Head)
            {
                (n1.Next.Prev, n2.Prev.Next, n2.Next.Prev) = (n2, n1, n1);
                (n1.Prev, n2.Prev) = (n2.Prev, null);
                (n1.Next, n2.Next) = (n2.Next, n1.Next);
                Head = n2;
            }
            else if (n2 == Head)
            {
                (n1.Prev.Next, n2.Next.Prev, n2.Next.Prev) = (n2, n2, n1);
                (n1.Prev, n2.Prev) = (null, n1.Prev);
                (n1.Next, n2.Next) = (n2.Next, null);
                Head = n1;
            }
            else if (n1 == Tail)
            {
                (n1.Prev.Next, n2.Prev.Next, n2.Next.Prev) = (n2, n1, n1);
                (n1.Prev, n2.Prev) = (n2.Prev, n1.Prev);
                (n1.Next, n2.Next) = (n2.Next, null);
                Tail = n2;
            }
            else if (n2 == Tail)
            {
                (n1.Prev.Next, n1.Next.Prev, n2.Prev.Next) = (n2, n1, n1);
                (n1.Prev, n2.Prev) = (n2.Prev, n1.Prev);
                (n1.Next, n2.Next) = (null, n1.Next);
                Tail = n1;
            }
            else
            {
                
            }
        }
        else
        {
            (n1.Prev.Next, n1.Next.Prev, n2.Prev.Next, n2.Next.Prev) = (n2, n2, n1, n1);
            (n1.Prev, n2.Prev) = (n2.Prev, n1.Prev);
            (n1.Next, n2.Next) = (n2.Next, n1.Next);
        }
    }


    public Node<T> FindMinRec(Node<T> temp, Node<T> min)
    {
        if (temp != null)
        {
            if (temp.Data.CompareTo(min.Data) <= 0)
            {
                min = temp;
            }

           return FindMinRec(temp.Next, min);
        }

        return min;
    }

    public Node<T> FindMinRec()
    {
        return FindMinRec(Head, Head);
    }

    public Node<T> FindMaxRec()
    {
        return FindMaxRec(Head, Head);
    }

    public Node<T> FindMaxRec(Node<T> temp, Node<T> max)
    {
        if (temp != null)
        {
            if (temp.Data.CompareTo(max.Data) > 0)
            {
                max = temp;
            }

            return FindMaxRec(temp.Next, max);
        }

        return max;
        
    }

    
    public string GetList()
    {
        Node<T> temp = Head;
        string output = "";
        while (temp != null)
        {
            output += String.Format(temp.Data + " | ");
            temp = temp.Next;
        }

        return output;
    }

    public string GetListRev()
    {
        Node<T> temp = Tail;
        string output = "";
        while (temp != null)
        {
            output += String.Format(temp.Data + " | ");
            temp = temp.Prev;
        }

        return output;
    }

    public string GetListRec(Node<T> temp, string output)
    {
        if (temp != null)
        {
            output += String.Format(temp.Data + " | ");
            return GetListRec(temp.Next, output);
        }
        return output; 
    }

    public string GetListRec()
    {
        Node<T> temp = Head;
        string output = "";
        return GetListRec(temp, output);
    }

    public string GetListRevRec(Node<T> temp, string output)
    {
        if (temp != null)
        {
            output += String.Format(temp.Data + " | ");
            GetListRec(temp.Prev, output);
        }
        return output; 
    }

    public void PrintListRec(Node<T> temp)
    {
        if (temp!=null)
        {
            Console.WriteLine(temp.Data.ToString()+" | ");
            PrintListRec(temp.Prev);
        }
    }
    public void PrintListRec()
    {
        PrintListRec(Tail);
    }
    public void PrintListReverseRec(Node<T> temp)
    {
        if (temp!=null)
        {
            Console.WriteLine(temp.Data.ToString()+" | ");
            PrintListRec(temp.Prev);
        }
    }
    public void PrintListReverseRec()
    {
        PrintListReverseRec(Tail);
    }

    public static GenericLinkedList<T> CreateListWithRandomNumbers(int size, int min, int max)
    {
        GenericLinkedList<T> list = new GenericLinkedList<T>();
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            T value = (T)(object)random.Next(min, max);
            Node<T> newNode = new Node<T>() { Data = value };
            if (list.Head == null)
            {
                list.Head = newNode;
                list.Tail = newNode;
            }
            else
            {
                newNode.Prev = list.Tail;
                list.Tail.Next = newNode;
                list.Tail = newNode;
            }
        }

        return list;
    }

    public int GetLenght()
    {
        if (Head is null)
            return 0;
        
        int count = 0;
        for (Node<T> temp = Head; temp.Next != null; temp = temp.Next)
            count++;
        return count;
    }

    public T this[int i]
    {
        get
        {
            Node<T> temp = Head;
            for (int j = 0; j < i; j++)
            {
                temp = temp.Next;
            }

            return temp.Data;
        }
        set
        {
            Node<T> temp = Head;
            for (int j = 0; j < i; j++)
            {
                temp = temp.Next;
            }

            temp.Data = value;
        }
    }

    public override string ToString()
    {
        if (Head is null)
            return "";
        
        var output = new StringBuilder();
        for (Node<T> temp = Head; temp.Next != null; temp = temp.Next)
            output.AppendLine(temp.Data.ToString());
        return output.ToString();
    }
    
    private Node<T>? SearchRec(Node<T>? current, T data)
    {
        return current is null ? null : current.Data.CompareTo(data) == 0 ? current : SearchRec(current.Next, data);
    }

    public Node<T>? Search(T data)
    {
        return SearchRec(Head, data);
    }
}