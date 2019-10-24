using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 构造数组的MaxTree
{
    public class Node 
    {
        public int value;
        public Node left;
        public Node right;
        public Node(int data)
        {
            this.value = data;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 4, 5, 1, 2 };
            Node head = getMaxTree(arr);
            PreOrderTraverse(head);
            InOrderTraverse(head);
            PostOrderTraverse(head);

            Console.ReadKey();

        }
        //二叉树前序遍历
        public static void PreOrderTraverse(Node n)
        {
            if (n == null)
            {
                return;
            }
            Console.WriteLine("{0}", n.value);
            PreOrderTraverse(n.left);
            PreOrderTraverse(n.right);
        }
        //二叉树中序遍历
        public static void InOrderTraverse(Node n)
        {
            if (n == null)
            {
                return;
            }
            InOrderTraverse(n.left);
            Console.WriteLine("{0}",n.value);
            InOrderTraverse(n.right);
        }
        //二叉树后序遍历
        public static void PostOrderTraverse(Node n)
        {
            if (n == null)
            {
                return;
            }
            PostOrderTraverse(n.left);
            PostOrderTraverse(n.right);
            Console.WriteLine("{0}",n.value);
        }

        public static Node getMaxTree(int[] arr)
        {
            Node[] nArr = new Node[arr.Length];
            for (int i = 0; i != arr.Length; i++)
            {
                nArr[i] = new Node(arr[i]);
            }
            Stack<Node> stack = new Stack<Node>();
            Dictionary<Node, Node> lBigMap = new Dictionary<Node, Node>();
            Dictionary<Node, Node> rBigMap = new Dictionary<Node, Node>();
            for (int i = 0; i != nArr.Length; i++)
            {
                Node Curcode = nArr[i];
                while ((stack.Count != 0) && stack.Peek().value < Curcode.value)
                {
                    popStackSetMap(stack, lBigMap);
                }
                stack.Push(Curcode);
            }
            while (stack.Count != 0)
            {
                popStackSetMap(stack, lBigMap);
            }
            for(int i=nArr.Length-1;i!=-1;i--)
            {
                Node Curcode = nArr[i];
                while ((stack.Count != 0) && stack.Peek().value < Curcode.value)
                {
                    popStackSetMap(stack, rBigMap);
                }
                stack.Push(Curcode);
            }
            while (stack.Count != 0)
            {
                popStackSetMap(stack, rBigMap);
            }
            Node head = null;
            for (int i = 0; i != nArr.Length; i++)
            {
                Node curNode = nArr[i];
                Node left = lBigMap[curNode];
                Node right = rBigMap[curNode];
                if (left == null && right == null)
                {
                    head = curNode;
                }
                else if (left == null)
                {
                    if (right.left == null)
                    {
                        right.left = curNode;
                    }
                    else
                    {
                        right.right = curNode;
                    }
                }
                else if (right == null)
                {
                    if (left.left == null)
                    {
                        left.left = curNode;
                    }
                    else
                    {
                        left.right = curNode;
                    }
                }
                else
                {
                    Node parent = left.value < right.value ? left : right;
                    if (parent.left == null)
                    {
                        parent.left = curNode;
                    }
                    else 
                    {
                        parent.right = curNode;
                    }
                }
            }
            return head;
        }

        public static void popStackSetMap(Stack<Node> stack, Dictionary<Node, Node> map)
        {
            Node popNode = stack.Pop();
            if (stack.Count == 0)
            {
                map.Add(popNode, null);
            }
            else 
            {
                map.Add(popNode, stack.Peek());
            }
        }
    }
}
