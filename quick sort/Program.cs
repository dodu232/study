namespace quickSort
{
    class MainApp
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[10];

            rand(arr);

            Console.Write("퀵소트 0: ");
            print(arr);

            quickSort(arr);

            Console.Write("퀵소트 후: ");
            print(arr);
        }
        public static void quickSort(int[] arr)
        {
            int pivot = 0;
            for (int i = 0; i<arr.Length; i++)
            {
                int idx1=0, idx2=0;
                for (int j = 0; j<arr.Length; j++)
                {
                    if (arr[pivot] < arr[j])
                    {
                        idx1 = j;
                        break;
                    }
                }

                for (int j = arr.Length - 1; j>0; j--)
                {
                    if (arr[pivot] > arr[j])
                    {
                        idx2 = j;
                        break;
                    }
                }

                if (idx1 + 1 == idx2)
                {
                    int temp = arr[idx1];
                    arr[idx1] = arr[pivot];
                    arr[pivot] = temp;
                }
                else
                {
                    int temp = arr[idx1];
                    arr[idx1] = arr[idx2];
                    arr[idx2] = temp;

                }
                    Console.Write($"퀵소트 {i+1}: ");
                    print(arr);

            }

        }

        public static void print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        public static void rand(int[] arr)
        {
            Random r = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(10, 30);
            }
        }

    }
}