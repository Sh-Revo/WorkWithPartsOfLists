using System;
using System.Collections;
using System.Collections.Generic;

namespace Indexing
{
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

        public bool Contains(T element)
        {
            foreach (var e in this)
            {
                if (e.Equals(element)) return true;
            }
            return false;
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Point)) return false;
            var p = obj as Point;
            return X == p.X && Y == p.Y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var list = new MyList<int>();
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);

            //for (int i = 0; i <= list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}
            var pList = new List<Point>();
            pList.Add(new Point { X = 1, Y = 1 });
            Console.WriteLine(pList.Contains(new Point { X = 1, Y = 1 }));
        }
    }
}
