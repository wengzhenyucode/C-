using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 生成窗口最大值数组
{
    //C#中LinkList<T>是一个双向链表，它的元素指向的前一个元素与后一个元素
    //C#中常用容器Array ArrayList List LinkedList
    //这个问题关键是利用双端队列实现窗口最大值的更新，首先生成双端队列qmax，qmax中存放数组arr中下标
    //假设遍历到arr[i],qmax存放规则为
    //1.如果qmax为空，直接把下标i放进qmanx，放入过程结束
    //2.如果qmax不为空，取出当前qmax队尾存放的下标，假设为j
    //3.如果arr[i]<arr[j],直接把下标放入qmax的队尾，放入过程结束
    //4.如果arr[i]>arr[j],把j从qmax弹出，继续qmax的放入过程
    //假设遍历到arr[i],qmax的弹出规则为：
    //如果qmax队头的下边等于i-w，则说明qmax的队头已经过期，弹出当前对头的下边即可

    class Program
    {
        static void Main(string[] args)
        {
            int[] test = { 2, 3, 7, 3, 6, 4, 8, 1, 3, 5, 0, 4, 6, 8 };
            int[] result = getMaxWindow(test,3);
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("{0}",result[i]);
            }
            Console.ReadKey();
        }
        public static int[] getMaxWindow(int[] arr, int w)
        {
            if (arr == null || w < 1 || arr.Length < w)
            {
                return null;
            }
            LinkedList<int> qmax = new LinkedList<int>();
            int []res = new int[arr.Length - w + 1];
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                while (qmax.Count!=0 && arr[qmax.Last()] < arr[i])
                {
                    qmax.RemoveLast();
                }
                qmax.AddLast(i);
                if (qmax.First() == i - w)
                {
                    qmax.RemoveFirst();
                }
                if (i >= w - 1)
                {
                    res[index++] = arr[qmax.First()];
                }
            }
            return res;
        
        }
    }
}
