using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 求最大子矩阵的大小
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] map = new int[3][];
            Console.WriteLine("{0}",map.Length);
            Console.ReadKey();
            
        }
        public int maxRecSize(int[][] map)
        {
            if (map == null || map.Count() == 0 || map[0].Count() == 0)
            {
                return 0;
            }
            int maxArea = 0;
            int[] height = new int[map[0].Length];
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[0].Length; j++)
                {
                    height[j] = map[i][j] == 0 ? 0 : height[j] + 1;
                }
                maxArea = Math.Max(maxRecFromBottom(height),maxArea);
            }
            return maxArea;
        }
        public int maxRecFromBottom(int[] height)
        {
            if (height == null || height.Length == 0)
            {
                return 0;
            }
            int maxArea = 0;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < height.Length; i++)
            {
                while (stack.Count() != 0 && height[i] <= height[stack.Peek()])
                {
                    int j = stack.Pop();
                    int k = stack.Count() == 0 ? -1 : stack.Peek();
                    int curArea = (i - k - 1) * height[j];
                    maxArea = Math.Max(maxArea, curArea);
                }
                stack.Push(i);
            }
            while (stack.Count() != 0)
            {
                int j = stack.Pop();
                int k = stack.Count() == 0 ? -1 : stack.Peek();
                int curArea = (height.Length - k - 1) * height[j];
                maxArea = Math.Max(maxArea, curArea);
            }
            return maxArea;

        }
    }
}
