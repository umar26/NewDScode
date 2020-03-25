using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSConsoleApp2
{
    public class Heap
    {
        #region heap with array representation
        public static void BuildHeap(int[] array)
        {
            int n = array.Length;
            int lastParNodeIndex = (n / 2) - 1; // last node index which is not leaf
            for (int i = lastParNodeIndex; i >= 0; i--)
            {
                Heapify(array, n, i);

            }
        }




        public static void Heapify(int[] array, int n, int i)
        {
            //top to bottom approach O(n) complexity in best case generally O(logn)
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            if (l < n && array[l] > array[largest])
                largest = l;
            if (r < n && array[r] > array[largest])
                largest = r;

            //swapping if parent node is less than children
            if (largest != i)
            {
                var temp = array[i];
                array[i] = array[largest];
                array[largest] = temp;
                Heapify(array, n, largest);
            }

        }

        public static void HeapifyNode(Node[] nodearray, int n, int i)
        {
            //top to bottom approach O(n) complexity in best case generally O(logn)
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            if (l < n && nodearray[l].Value > nodearray[largest].Value)
                largest = l;
            if (r < n && nodearray[r].Value > nodearray[largest].Value)
                largest = r;

            int lVal = 0, lPri = 0, rVal = 0, rPri = 0;
            if (l < n)
            {
                lVal = nodearray[l].Value;
                lPri = nodearray[l].Priority;
            }
            if (r < n)
            {
                rVal = nodearray[r].Value;
                rPri = nodearray[r].Priority;
            }
            int larVal = nodearray[largest].Value;
            int larPri = nodearray[largest].Priority;

            //swapping if parent node is less than children
            if (largest != i)
            {
                int indextoswap = largest;
                if(lVal==rVal)
                {
                    indextoswap = lPri < rPri ? l : r;
                }
                var temp = nodearray[i];
                nodearray[i] = nodearray[indextoswap];
                nodearray[indextoswap] = temp;
                HeapifyNode(nodearray, n, indextoswap);
            }
            else
            {
                

                if (larVal == lVal && larVal == rVal)
                {
                    int indexfromswap = lPri < larPri ? l : (rPri<larPri? r:-1);
                    if (indexfromswap >= 0)
                    {
                        var temp = nodearray[indexfromswap];
                        nodearray[indexfromswap] = nodearray[largest];
                        nodearray[largest] = temp;
                        HeapifyNode(nodearray, n, largest);
                    }
                }
                else if(larVal==lVal)
                {
                    var temp = nodearray[l];
                    nodearray[l] = nodearray[largest];
                    nodearray[largest] = temp;
                    HeapifyNode(nodearray, n, largest);
                }
                else if(larVal==rVal)
                {
                    var temp = nodearray[r];
                    nodearray[r] = nodearray[largest];
                    nodearray[largest] = temp;
                    HeapifyNode(nodearray, n, largest);
                }
            }

        }

        public static int[] AddNode(int[] array, int ele, int curArrayLength)
        {
            // complexity O(log (n)) or O(h)
            Array.Resize<int>(ref array, curArrayLength + 1);

            array[curArrayLength] = ele;
            //  int parentindex = (array.Length/2)-1;
            HeapifyBottomUp(array, array.Length, curArrayLength);

            return array;

        }

        public static void HeapifyBottomUp(int[] array, int n, int index)
        {

            int parent = ((index - 1) / 2);
            if (parent >= 0)
            {
                if (array[index] > array[parent])
                {
                    //swap
                    int temp = array[parent];
                    array[parent] = array[index];
                    array[index] = temp;
                    HeapifyBottomUp(array, n, parent);
                }
            }
        }

        public static void PrinHeap(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        public static void PrinNodeHeap(Node[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($" value: {array[i].Value} Priority:{array[i].Priority}");
            }
            Console.WriteLine();
        }

        public static int FindHeight(int n, string[] arr, int rootIndex, int timescount = 0)
        {
            ++timescount;
            Console.WriteLine($" visited count {timescount}");
            if (rootIndex >= n || arr[rootIndex] == "N")
                return 0;

            int l = 2 * rootIndex + 1;
            int r = 2 * rootIndex + 2;
            Console.WriteLine($" current visited node value {arr[rootIndex]} current left index {l}, current right index {r}");
            int leftHeight = FindHeight(n, arr, l, timescount);
            int rightHeight = FindHeight(n, arr, r, timescount);
            // left height
            if (leftHeight > rightHeight)
                return leftHeight + 1;
            else
                return rightHeight + 1;
        }

        public static int DeleteNode(int[] array, int n)
        {
            int deleteditem = array[0];
            array[0] = array[n - 1];
            array[n - 1] = deleteditem;
            Heapify(array, n - 1, 0);
            return deleteditem;
        }


        //O(nlogn)
        public static void Sort(int[] arr)
        {
            Heap.BuildHeap(arr);
            for (int i = 0; i < arr.Length; i++) // n *
            {
                int itemremoved = Heap.DeleteNode(arr, arr.Length - i); // logn
                Console.WriteLine($"removed item {itemremoved}");
            }
        }

        #endregion

        #region Heap with Node representation
        public static Node[] BuildPriorityHeap(int[] array)
        {

            int n = array.Length;
            Node[] nodearray = new Node[n];
            for (int i = 0; i < array.Length; i++)
            {
                nodearray[i] = new Node(i, array[i]);
            }

            int lastParNodeIndex = (n / 2) - 1; // last node index which is not leaf
            for (int i = lastParNodeIndex; i >= 0; i--)
            {
                HeapifyNode(nodearray, n, i);

            }

            return nodearray;

        }

        public static Node DecreaseMaxNodeValue(Node[] nodearray, int n)
        {

            Node decreaseitem = nodearray[0];
            if (decreaseitem.Value > 0)
            {
                nodearray[0].Value = nodearray[0].Value - 1;
                // array[n - 1] = deleteditem;
                HeapifyNode(nodearray, n, 0);
            }
            return decreaseitem;
        }


        #endregion

    }




    public class Node
    {
        public int Priority;
        public int Value;
        public Node()
        {
            Priority = 0;
            Value = 0;
        }
        public Node(int priority, int value)
        {
            this.Priority = priority;
            this.Value = value;

        }

    }
}
