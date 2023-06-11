using System;
using System.Collections.Generic;

namespace Convert_array_into_heap
{
    public class Program
    {
        static List<Tuple<int,int>> Swaps= new List<Tuple<int,int>>();
        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;

            Swaps.Add(new Tuple<int, int>(i, j));
        }
        static void SiftDown(int i , int[] arr)
        {
            int minIdenx = i;
            int leftIdenx = i * 2 + 1;

            if (leftIdenx < arr.Length && arr[leftIdenx] < arr[minIdenx])
            {
                minIdenx = leftIdenx;
            }

            int rightIndex = i * 2 + 2;

            if (rightIndex < arr.Length && arr[rightIndex] < arr[minIdenx])
            {
                minIdenx= rightIndex;
            }

            if (minIdenx != i)
            {
                Swap(arr, i, minIdenx);
                SiftDown(minIdenx, arr);
            }
        }

        static void ConvertToHeap(int[] arr)
        {
            int n = arr.Length;

            for (int i = n / 2; i >= 0; i--)
            {
                SiftDown(i, arr);
            }
        }
        static int[] GetArrayFromUser()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            string[] inputs = Console.ReadLine().Split(' ');

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(inputs[i]);
            }

            return arr;
        }
        static void Main(string[] args)
        {
            var inputArray = GetArrayFromUser();

            ConvertToHeap(inputArray);

            Console.WriteLine(Swaps.Count);

            foreach (var item in Swaps)
            {
                Console.WriteLine(item.Item1 + " " + item.Item2);
            }
        }
    }
}