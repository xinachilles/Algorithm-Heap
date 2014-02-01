using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_Heap
{
    public class Heap<T> where T : IComparable<T>
    {

        //for every node i other than the root
        //A[ Parent( i ) ] ≥ A[ i ]
        private List<T> data;   
        
        private void MaxHeapify(int i)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest;
            // check its children value, put the maximu value in the parent
            if ((left < data.Count) && (data[left].CompareTo(data[i]) == 1))
            {
                largest = left;
            }
            else
            {

                largest = i;

            }

            if ((right < data.Count) && (data[right].CompareTo(data[largest]) == 1))
            {

                largest = right;
            }

            if (largest != i)
            {
                MySwitch(i, largest);
                MaxHeapify(largest);
            }



        }

        private void MinHeapify(int i)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int smallest;
            // check its children value, put the maximu value in the parent
            if ((left < data.Count) && (data[left].CompareTo(data[i]) == -1))
            {
                smallest = left;
            }
            else
            {

                smallest = i;

            }

            if ((right < data.Count) && (data[right].CompareTo(data[smallest]) == -1))
            {

                smallest = right;
            }

            if (smallest != i)
            {
                MySwitch(i, smallest);
                MinHeapify(smallest);
            }



        }

        public int Count {

            get { return data.Count; }
            
        }

        public void Remove(T d)
        {
            data.Remove(d);
        }

        public bool Contains(T d)
        {
            if (data != null)
            {
                return data.Contains(d);
            }
            else {

                return false;
            }
            
        }
        public Heap(T[] a, bool maxHeap)
        {

            data = new List<T>();


            foreach (T item in a)
            {
                data.Add(item);
            }


            if (maxHeap == true)
            {
                BuildMaxHeap();
            }
            else
            {
                BuildMinHeap();

            }

        }

        private void BuildMaxHeap()
        {
            // elements a[n/2 ...n] are all leaves
            // elemens a[0] is root ... 


            for (int i = (int)Math.Ceiling((double)data.Count / 2); i >= 0; i--)
            {
                MaxHeapify(i);
            }

        }

        public void BuildMinHeap()
        {
            // elements a[n/2 ...n] are all leaves
            // elemens a[0] is root ... 


            for (int i = (int)Math.Ceiling((double)data.Count / 2); i >= 0; i--)
            {
                MinHeapify(i);
            }

        }


        private void MySwitch(int first, int second)
        {
            if ((data.Count > 0) && (data.Count >= first) && (data.Count >= second))
            {
                T temp = data[first];
                data[first] = data[second];
                data[second] = temp;

            }
        }

        public void PrintResult(int[] array)
        {

            foreach (var item in array)
            {
                Console.Write(item.ToString());
            }

        }

        public void Insert(T d) {
            
            data.Add(d);
        }

        public void HeapSort()
        {
            BuildMaxHeap();
            for (int i = data.Count - 1; i > 0; i--)
            {
                List<T> b = new List<T>();

                MySwitch(0, i);

                for (int j = 0; j < i; j++)
                {
                    b.Add(data[j]);
                }



                MaxHeapify(0);

                for (int j = 0; j < i; j++)
                {
                    data[j] = b[j];
                }


            }
        }
        public T ExtractMin()
        {
            T smallest = default(T);

            if (data.Count > 0)
            {
                BuildMinHeap();
                smallest = data[0];
                data.RemoveAt(0);
           }

            return smallest;

        }



    }
}
