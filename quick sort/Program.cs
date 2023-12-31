﻿namespace quickSort
{
    class Sort
    {
        public int[] arr;

        public Sort(int n = 20)
        {
            arr = new int[n];
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                this.arr[i] = r.Next(1, 1000);
            }
        }

        public Sort(Sort s)
        {
            arr = new int[s.arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                this.arr[i] = s.arr[i];
            }
        }

        public void bubbleSort()
        {
            for(int i=arr.Length-1; i>0; i--)
            {
                for(int j=0; j<i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        swap(j, j + 1);
                    }
                }
            }
        }

        public void quickSort(int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            // 통 정렬
            int pivot = partition(start, end);

            // 오른쪽 정렬
            quickSort(start, pivot - 1);

            // 왼쪽 정렬
            quickSort(pivot + 1, end);

        }

        // 정렬
        public int partition(int start, int end)
        {
            //  피벗 값 지정
            int pivot = start;

            // 피벗 다음 수 부터 탐색 시작
            start++;

            // 반복 정렬
            while (true)
            {
                // 큰 수 탐색
                while (arr[pivot] >= arr[start] && start < end)
                {
                    start++;
                }

                // 작은 수 탐색
                while (arr[pivot] < arr[end] && end >= start)
                {
                    end--;
                }

                // 교차되면 피벗과 작은 값 교환 후 반복문 종료
                if (start >= end)
                {
                    swap(pivot, end);
                    return end; // 피봇 리턴
                }
                else // 아니면 큰 값과 작은 값 교환
                {
                    swap(start, end);
                }
            }

        }

        // 자리 바꾸기
        public void swap(int a, int b)
        {
            int temp = this.arr[a];
            this.arr[a] = this.arr[b];
            this.arr[b] = temp;
        }

        // 배열 출력하기
        public void print()
        {
            for (int i = 0; i < this.arr.Length; i++)
            {
                Console.Write(this.arr[i] + " ");
            }
            Console.WriteLine();
        }

    }
    class MainApp
    {
        public static void Main(string[] args)
        {
            Sort arr = new Sort(10000);
            Sort arr2 = new Sort(arr);

            Console.WriteLine("퀵소트");
            //arr.print();
            //arr2.print();

            DateTime time = DateTime.Now;

            arr.quickSort(0, arr.arr.Length - 1);

            arr.print();

            DateTime time2 = DateTime.Now;
            TimeSpan timer = time2 - time;
            Console.WriteLine("버블");


            time = DateTime.Now;

            arr2.bubbleSort();

            arr2.print();

            time2 = DateTime.Now;
            TimeSpan timer2 = time2 - time;

            Console.WriteLine($"퀵소트 걸린 시간: {timer.TotalMilliseconds}");
            Console.WriteLine($"버블 걸린 시간: {timer2.TotalMilliseconds}");

        }
    }
}