namespace RectArea
{
    class MainApp
    {

        public static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            dia(num);

        }
        public static void print(int n, char c)
        {
            for(int i=0; i<n; i++)
            {
                Console.Write(c);
            }
            
        }

        public static void dia(int n)
        {
            for(int i=0; i<n; i++)
            {
                print(n - i - 1, ' ');
                print(i*2+1, '*');
                Console.WriteLine();
            }

            for(int i=0; i<n; i++)
            {
                print(i+1, ' ');
                print((n - i - 1) * 2 - 1, '*');
                Console.WriteLine();
            }
        }
    }
      
}