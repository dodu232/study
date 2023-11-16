namespace bo
{
    class Program
    {
        static object arrLock = new object();
        static int arrayCnt = 0;
        static List<int[]> arrayQue = new List<int[]>();

        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;

            const int ThreadCnt = 8;
            const int ArrCnt = 50000;

            // 배열 생성
            for (int i = 0; i < ThreadCnt; i++)
            {
                int[] data = create(ArrCnt);
                Console.WriteLine("Array[{0}]: {1}", i, data.Length);

                Thread thread = new Thread(func);
                thread.Start(data);

                lock(arrLock)
                {
                    arrayCnt++;
                }
            }

           // 머지 전
            while(arrayCnt > 1)
            {
                lock(arrLock)
                {
                    if( arrayQue.Count >= 2)
                    {
                        Thread thread = new Thread(merge);
                        thread.Start(new ThreadParam(arrayQue[0], arrayQue[1]));
                        arrayQue.RemoveAt(0);
                        arrayQue.RemoveAt(0);
                    }
                }
                Thread.Sleep(10);
            }

            Console.WriteLine("Final");
            print(arrayQue[0]);

            TimeSpan ts = DateTime.Now - start;

            Console.WriteLine(ts.TotalMilliseconds);

            ///

            int[] arr = create(ThreadCnt * ArrCnt);
           
            start = DateTime.Now;
            bubbleSort(arr);

            ts = DateTime.Now - start;

            Console.WriteLine(ts.TotalMilliseconds);

        }
        private static void func(object o)
        {
            int[] arr = (int[])o;

            bubbleSort(arr);

        }

        public static void merge(object o)
        {
            ThreadParam tempParam = o as ThreadParam;
            int[] list1 = tempParam.param1;
            int[] list2 = tempParam.param2;

            int size = list1.Length + list2.Length;
            int[] arr = new int[size];

            int idx1 = 0;
            int idx2 = 0;
            int idx3 = 0;

            while (idx1 < list1.Length && idx2 < list2.Length)
            {
                if (list1[idx1] <= list2[idx2])
                {
                    arr[idx3++] = list1[idx1];
                    idx1++;
                }
                else
                {
                    arr[idx3++] = list2[idx2];
                    idx2++;
                }
            }

            while (idx1 < list1.Length)
            {
                arr[idx3++] = list1[idx1];
                idx1++;
            }

            while (idx2 < list2.Length)
            {
                arr[idx3++] = list2[idx2];
                idx2++;
            }

            lock (arrLock)
            {
                arrayQue.Add(arr);
                arrayCnt--;
            }
        }

        public static void bubbleSort(int[] arr)
        {
            for (int i = arr.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }

            lock(arrLock)
            {
                arrayQue.Add(arr);
            }
        }

        public static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public static int[] create(int n = 20)
        {
            int[] arr = new int[n];
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                arr[i] = r.Next(10, 100000);
            }

            return arr;
        }

        // 배열 출력하기
        public static void print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }

    class ThreadParam
    {
        public int[] param1;
        public int[] param2;
        public ThreadParam(int[] num1, int[] num2)
        {
            this.param1 = num1;
            this.param2 = num2;
        }


    }


}
