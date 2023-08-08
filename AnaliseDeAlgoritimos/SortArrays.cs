using System.Collections.Generic;

namespace AnaliseDeAlgoritimos
{
    public class SortArrays
    {
        public static int Comparisons = 0;
        public static int Swaps = 0;

        public List<int> BubbleSort(List<int> array)
        {
            int size = array.Count;

            if (size < 2)
                return array;

            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < size - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;

                        Swaps++; // incrementa o contador de trocas
                        swapped = true;
                    }

                    Comparisons++; // incrementa o contador de comparações
                }
                size--;
            } while (swapped);

            return array;
        }

        public List<int> QuickSort(List<int> array)
        {
            // Caso base: array vazio ou com um único elemento
            if (array.Count <= 1)
            {
                return array;
            }

            // Seleciona o pivot como o valor mediano entre o primeiro, o último e o elemento central da lista
            int pivotIndex = array.Count / 2;
            int pivot = array[pivotIndex];

            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();

            int swaps = 0; // contador local de trocas

            for (int i = 0; i < array.Count; i++)
            {
                if (i == pivotIndex)
                {
                    continue;
                }

                Comparisons++;

                if (array[i] <= pivot)
                {
                    leftList.Add(array[i]);
                }
                else
                {
                    rightList.Add(array[i]);
                    swaps++; // incrementa o contador local de trocas
                }
            }

            List<int> sortedList = new List<int>();
            sortedList.AddRange(QuickSort(leftList));
            sortedList.Add(pivot);
            sortedList.AddRange(QuickSort(rightList));

            Swaps += swaps; // adiciona o contador local de trocas ao contador global de trocas

            return sortedList;
        }

        public List<int> SelectSort(List<int> array)
        {
            int n = array.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    Comparisons++; // incrementa a contagem de comparações

                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    int temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                    Swaps++; // incrementa a contagem de trocas
                }
            }

            return array;
        }

        public List<int> MergeSort(List<int> array)
        {
            if (array.Count <= 1)
                return array;

            int middle = array.Count / 2;
            List<int> left = array.GetRange(0, middle);
            List<int> right = array.GetRange(middle, array.Count - middle);

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            int i = 0, j = 0;

            while (i < left.Count && j < right.Count)
            {
                Comparisons++; // Incrementa a comparação
                if (left[i] <= right[j])
                {
                    Swaps++; // Incrementa a troca
                    result.Add(left[i]);
                    i++;
                }
                else
                {
                    Swaps++; // Incrementa a troca
                    result.Add(right[j]);
                    j++;
                }
            }

            while (i < left.Count)
            {
                Swaps++; // Incrementa a troca
                result.Add(left[i]);
                i++;
            }

            while (j < right.Count)
            {
                Swaps++; // Incrementa a troca
                result.Add(right[j]);
                j++;
            }

            return result;
        }

        public List<int> HeapSort(List<int> array)
        {
            int heapSize = array.Count;

            // Construindo o heap
            for (int i = heapSize / 2 - 1; i >= 0; i--)
            {
                Heapify(array, heapSize, i, ref Comparisons, ref Swaps);
            }

            // Retirando os elementos do heap
            for (int i = heapSize - 1; i >= 1; i--)
            {
                // Coloca o maior elemento na posição correta
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                Swaps++;

                // Mantém a propriedade de heap
                Heapify(array, i, 0, ref Comparisons, ref Swaps);
            }

            return array;
        }

        private void Heapify(List<int> array, int heapSize, int root, ref int comparisons, ref int swaps)
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            // Encontra o maior elemento entre o pai e os filhos
            if (left < heapSize && array[left] > array[largest])
            {
                largest = left;
            }
            comparisons++;

            if (right < heapSize && array[right] > array[largest])
            {
                largest = right;
            }
            comparisons++;

            // Se o maior elemento não for o pai, troca-os
            if (largest != root)
            {
                int temp = array[root];
                array[root] = array[largest];
                array[largest] = temp;
                swaps++;

                // Mantém a propriedade de heap recursivamente
                Heapify(array, heapSize, largest, ref comparisons, ref swaps);
            }
        }
    }
}
