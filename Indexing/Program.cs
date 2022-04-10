using System;
using System.Collections;
using System.Collections.Generic;

namespace Indexing
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            for (int i = 0; i <= list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }

    public class MyList<T> : IEnumerable<T>
    {
        T[] array;
        int count = 0;

        public MyList()
        {
            array = new T[100];
        }

        public void Enlarge()
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            if (count == array.Length)
                Enlarge();
            array[count] = item;
            count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return array[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();
                return array[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();
                array[index] = value;
            }
        }

        public int Count { get { return count; } }
    }
}
