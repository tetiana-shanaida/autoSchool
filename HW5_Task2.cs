namespace HW5Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of elements in the column");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of elements in the row");
            int m = int.Parse(Console.ReadLine());


            int[,] nums = new int[n, m];
            Console.WriteLine($"test message");
            for (int i = 0; i < n; i++)
            {
                string [] temp = Console.ReadLine().Split();
                for (int j = 0; j < m; j++)
                {
                    nums[i, j] = int.Parse(temp[j]);
                }
            }
            int [] max = Maxel(nums);
            foreach (int i in max)
            {
                Console.Write($"{i} ");
            }
        }

        static int[] Maxel(int[,] nums)
        {
            int[] res = new int[nums.GetLength(0)];
            for(int i = 0; i < nums.GetLength(0); i++) 
            {
                int max = nums[i,0];
                for(int j = 1; j < nums.GetLength(1); j++)
                {
                    if(max < nums[i,j])
                    {
                        max = nums[i,j];
                    }
                }
                res[i] = max;
            }
            return res;
        }
    }
}