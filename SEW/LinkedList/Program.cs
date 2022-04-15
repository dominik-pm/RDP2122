// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Text;

Console.WriteLine("Following is an example of a Linked List with adding, inorder output, deleting, iterator pattern and indexer");
Console.WriteLine("If you find any mistakes or want to give feedback contact the author Gabriel Lugmayr.\n");


var llist = new MyLinkedList<int>();

Console.WriteLine("Adding 1, 2, 3, 4, 5\n");
llist.Add(1);
llist.Add(2);
llist.Add(3);
llist.Add(4);
llist.Add(5);

Console.WriteLine("Inorder Output:");
Console.WriteLine(llist + "\n");

Console.WriteLine("Delete 4:");
llist.Delete(4);
Console.WriteLine(llist);
Console.WriteLine("Delete 5:");
llist.Delete(5);
Console.WriteLine(llist);
Console.WriteLine("Delete 1:");
llist.Delete(1);
Console.WriteLine(llist + "\n");

Console.WriteLine("Iterating with foreach and Ienumerable:");
foreach (var item in llist)
{
    Console.Write(item + ", ");
}

Console.WriteLine("\n\nIndexer");
Console.WriteLine("get 0:");
Console.WriteLine(llist[0]);
Console.WriteLine("get 1:");
Console.WriteLine(llist[1]);

Console.WriteLine("set [0] to 10");
llist[0] = 10;
Console.WriteLine(llist);
Console.WriteLine("set [1] to 11");
llist[1] = 11;
Console.WriteLine(llist);


class MyLinkedList<T> : IEnumerable<T> where T : IComparable<T>
{
    ListElement<T> root;

    public T this[int index]
    {
        get {
            if (root == default) throw new NotImplementedException();
            var current = root;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
                if (current == default) throw new IndexOutOfRangeException();
            }
            return current.Value;
        }
        set {
            if (root == default) throw new NotImplementedException();
            var current = root;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
                if (current == default) throw new IndexOutOfRangeException();
            }
            current.Value = value;
        }
    }

    public void Add(T value)
    {
        if (root == default)
        {
            root = new ListElement<T>(value);
            return; 
        }
        ListElement<T> current = root;
        while(current.Next != null){
            current = current.Next;
        } 
        current.Next = new ListElement<T>(value);
    }

    /// <summary>
    /// Deletes the first occurency of a value
    /// </summary>
    /// <param name="value"></param>
    public void Delete(T value)
    {
        if (root == default) return; 
        if (root.Value.CompareTo(value) == 0)
        {
            root = root.Next;
            return;
        }

        ListElement<T> current = root;

        while(current.Next != default)
        {
            if(current.Next.Value.CompareTo(value) == 0)
            {
                current.Next = current.Next.Next;
                return;
            }
            current = current.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (root == default) yield break; 

        ListElement<T> current = root;
        while(current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        ListElement<T> current = root;
        while(current != default)
        {
            sb.Append(current.Value + ", ");
            current = current.Next;
        }
        return sb.ToString();
    }
}
class ListElement<T> where T : IComparable<T>
{
    public T Value;
    public ListElement<T> Next;

    public ListElement(T value)
    {
        Value = value;
    }
}