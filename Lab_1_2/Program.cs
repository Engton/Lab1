using System;

namespace Lab_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class MyDictionary<Tkey, Tval>
    {

        private int counter = 0;
        private Tkey[] keysArray = null;
        private Tval[] valsArray = null;

        public int Counter
        {
            get { return this.counter; }
        }

        public void Add(Tkey key, Tval val)
        {
            this.counter++;

            Array.Resize(ref keysArray, counter);
            keysArray[counter - 1] = key;

            Array.Resize(ref valsArray, counter);
            valsArray[counter - 1] = val;
        }

        public Tval this[Tkey key]
        {
            get
            {
                int ind = 0;
                for (int i = 0; i < keysArray.Length; i++)
                {
                    if (key.Equals(keysArray[i]))
                        ind = i;
                }
                return valsArray[ind];
            }
        }
    }
}
