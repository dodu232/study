namespace temp
{
    internal class Program
    {
        static void swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }


        static void quickSort(int left, int right, int[] data)
        {
            int pivot = left;
            int j = pivot;
            int i = left + 1;

            if (left < right)
            {
                for (; i <= right; i++)
                {
                    if (data[i] < data[pivot])
                    {
                        j++;
                        swap(ref data[j], ref data[i]);
                    }
                }
                swap(ref data[left], ref data[j]);
                pivot = j;

                quickSort(left, pivot - 1, data);
                quickSort(pivot + 1, right, data);
            }

        }

        static void Main(string[] args)
        {
            int[] arr = { 22, 27, 8, 17, 8, 22, 12, 12, 26, 2 };
            quickSort(0, 9, arr);
            for (int i = 0; i < 10; i++) Console.Write($"{arr[i]} ");

        }
    }
}