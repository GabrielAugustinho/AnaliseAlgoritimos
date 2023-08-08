using System;
using System.Diagnostics;
using System.Linq;

namespace AnaliseDeAlgoritimos
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var numeros = new int[320000];

            for (int i = 0; i < numeros.Length; i++)
            {
                var proximo = rnd.Next();

                if (i == 0)
                {
                    numeros[i] = proximo;
                }
                else if (proximo != numeros[i - 1])
                {
                    numeros[i] = proximo;
                }
            }

            //Array.Sort(numeros);
            //Array.Reverse(numeros);
            var sortArray = new SortArrays();

            //// BubbleSort
            //SortArrays.Comparisons = 0;
            //SortArrays.Swaps = 0;

            //var watch = Stopwatch.StartNew();
            //var sortedList = sortArray.BubbleSort(numeros.ToList());
            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;
            //Console.WriteLine($"\n\nBubbleSort:\n" +
            //                      $"Tempo(ms): {elapsedMs},\n" +
            //                      $"Comparações: {SortArrays.Comparisons},\n" +
            //                      $"Trocas: {SortArrays.Swaps}\n\n");

            // QuickSort
            SortArrays.Comparisons = 0;
            SortArrays.Swaps = 0;

            var watch = Stopwatch.StartNew();
            var sortedList = sortArray.QuickSort(numeros.ToList());
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"\n\nQuickSort:\n" +
                                  $"Tempo(ms): {elapsedMs},\n" +
                                  $"Comparações: {SortArrays.Comparisons},\n" +
                                  $"Trocas: {SortArrays.Swaps}\n\n");

            //// SelectSort
            //SortArrays.Comparisons = 0;
            //SortArrays.Swaps = 0;

            //watch = Stopwatch.StartNew();
            //sortedList = sortArray.SelectSort(numeros.ToList());
            //watch.Stop();
            //elapsedMs = watch.ElapsedMilliseconds;
            //Console.WriteLine("\n\nSelectSort:\n" +
            //                      $"Tempo(ms): {elapsedMs},\n" +
            //                      $"Comparações: {SortArrays.Comparisons},\n" +
            //                      $"Trocas: {SortArrays.Swaps}\n\n");

            // MergeSort
            SortArrays.Comparisons = 0;
            SortArrays.Swaps = 0;

            watch = Stopwatch.StartNew();
            sortedList = sortArray.MergeSort(numeros.ToList());
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"\n\nMergeSort:\n" +
                                  $"Tempo(ms): {elapsedMs},\n" +
                                  $"Comparações: {SortArrays.Comparisons},\n" +
                                  $"Trocas: {SortArrays.Swaps}\n\n");

            // HeapSort
            SortArrays.Comparisons = 0;
            SortArrays.Swaps = 0;

            watch = Stopwatch.StartNew();
            sortedList = sortArray.HeapSort(numeros.ToList());
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"\n\nHeapSort:\n" +
                                  $"Tempo(ms): {elapsedMs},\n" +
                                  $"Comparações: {SortArrays.Comparisons},\n" +
                                  $"Trocas: {SortArrays.Swaps}\n\n");

            //Array.Sort(numeros);
            //Array.Reverse(numeros);
        }
    }
}
