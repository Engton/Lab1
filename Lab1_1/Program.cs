using System;

namespace Lab1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class List<T>
    {
        private T[] source;

        private void ThrowIfInvalid(int index)
        {
            if ((index < 0) || (index >= Count))
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private void TryResize()
        {
            Count++;
            if (source.Length < Count)
            {
                Array.Resize(ref source, source.Length == 0 ? 1 : source.Length * 2);
            }
        }

        private void Insert(int index, T x)
        {
            TryResize();
            for (var i = Count - 1; i > index; i--)
            {
                source[i] = source[i - 1];
            }
            source[index] = x;
        }

        public T this[int i]
        {
            get
            {
                ThrowIfInvalid(i);
                return source[i];
            }
            set
            {
                ThrowIfInvalid(i);
                source[i] = value;
            }
        }

        public int Capacity => source.Length;
        public int Count { get; private set; }

        public List()
        {
            source = new T[1];
        }

        public string GetStringRepresentation()
        {
            string representation = "[";
            for (var i = 0; i < Count; i++)
            {
                representation += source[i].ToString();
                if (i < Count - 1)
                {
                    representation += ", ";
                }
            }
            representation += "]";
            return representation;
        }

        public void Print() => Console.Write(GetStringRepresentation());

        public void Println() => Console.WriteLine(GetStringRepresentation());

        public List<T> CloneAs()
        {
            List<T> list = new List<T>();
            for (var i = 0; i < Count; i++)
            {
                list.AddLast(source[i]);
            }
            return list;
        }

        public object Clone() => CloneAs();

        public void TrimExcess() => Array.Resize(ref source, Count);

        public int IndexOf(T x)
        {
            int i = 0;
            while ((i < Count) && (!source[i].Equals(x)))
            {
                i++;
            }
            if (i == Count)
            {
                return -1;
            }
            return i;
        }

        public void InsertAt(int index, T x)
        {
            ThrowIfInvalid(index);
            Insert(index, x);
        }

        public void RemoveAt(int index)
        {
            ThrowIfInvalid(index);
            for (var i = index; i < Count - 1; i++)
            {
                source[i] = source[i + 1];
            }
            source[Count - 1] = default(T);
            Count--;
        }

        public void AddFirst(T x) => Insert(0, x);

        public void AddLast(T x) => Insert(Count, x);

        public void AddBefore(T target, T x) => InsertAt(IndexOf(target) - 1, x);

        public void Add(T target, T x) => InsertAt(IndexOf(target), x);

        public void AddAfter(T target, T x) => InsertAt(IndexOf(target) + 1, x);

        public void RemoveFirst() => RemoveAt(0);

        public void RemoveLast() => RemoveAt(Count - 1);

        public void RemoveBefore(T x) => RemoveAt(IndexOf(x) - 1);

        public void Remove(T x) => RemoveAt(IndexOf(x));

        public void RemoveAfter(T x) => RemoveAt(IndexOf(x) + 1);
    }
}
