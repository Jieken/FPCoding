using System;
using System.Linq.Expressions;

namespace ConsoleApp1
{
    public class TreeNode<T>

    {
        public TreeNode(T value, TreeNode<T> left, TreeNode<T> right)
        {
            this.Value = value;

            this.Left = left;

            this.Right = right;
        }

        public T Value { get; private set; }
        public TreeNode<T> Left { get; private set; }
        public TreeNode<T> Right { get; private set; }
    }



    class Program
    {
        public static void PreOrderTraversal<T>(TreeNode<T> root)
        {
            if (root == null) return;
            Console.WriteLine(root.Value);
            PreOrderTraversal(root.Left);
            PreOrderTraversal(root.Right);
        }

        public static void InOrderTraversal<T>(TreeNode<T> root)
        {
            if (root == null) return;
            InOrderTraversal(root.Left);
            Console.WriteLine(root.Value);
            InOrderTraversal(root.Right);
        }
        public static void PostOrderTraversal<T>(TreeNode<T> root)
        {
            if (root == null) return;
            PostOrderTraversal(root.Left);
            PostOrderTraversal(root.Right);
            Console.WriteLine(root.Value);
        }

        public static void PreOrderTraversal<T>(TreeNode<T> root, Action<TreeNode<T>,int> continuation)
        {
            if (root == null)
            {
                continuation(null,0);
                return;
            }
            Console.WriteLine(root.Value);
            PreOrderTraversal(root.Left, 
                (left , x )=>PreOrderTraversal(root.Right, (right,y )=> continuation(right, x +y + 1)));
        }
        public static void InOrderTraversal<T>(TreeNode<T> root, Action<TreeNode<T>, int> continuation)
        {
            if (root == null)
            {
                continuation(null, 0);
                return;
            }

            InOrderTraversal(root.Left,
                (left, x) => { Console.WriteLine(root.Value); InOrderTraversal(root.Right, (right, y) => continuation(right, x + y + 1)); });
        }

        public static void PostOrderTraversal<T>(TreeNode<T> root, Action<TreeNode<T>, int> continuation)
        {
            if (root == null)
            {
                continuation(null, 0);
                return;
            }
            PostOrderTraversal(root.Left,
                (left, x) => PostOrderTraversal(root.Right, (right, y) => { Console.WriteLine(root.Value); continuation(right, x + y + 1);  }));
        }
        static void Main(string[] args)
        {
            #region
            TreeNode<string> four1 = new TreeNode<string>("4.1", null, null);
            TreeNode<string> four2 = new TreeNode<string>("4.2", null, null);
            TreeNode<string> four3 = new TreeNode<string>("4.3", null, null);
            TreeNode<string> four4 = new TreeNode<string>("4.4", null, null);
            TreeNode<string> four5 = new TreeNode<string>("4.5", null, null);
            TreeNode<string> four6 = new TreeNode<string>("4.6", null, null);
            TreeNode<string> four7 = new TreeNode<string>("4.7", null, null);
            TreeNode<string> four8 = new TreeNode<string>("4.8", null, null);

            TreeNode<string> three1 = new TreeNode<string>("3.1", four1, four2);
            TreeNode<string> three2 = new TreeNode<string>("3.2", four3, four4);
            TreeNode<string> three3 = new TreeNode<string>("3.3", four5, four6);
            TreeNode<string> three4 = new TreeNode<string>("3.4", four7, four8);

            TreeNode<string> sec1 = new TreeNode<string>("2.1", three1, three2);
            TreeNode<string> sec2 = new TreeNode<string>("2.2", three3, three4);

            TreeNode<string> tree = new TreeNode<string>("1", sec1, sec2);
            #endregion
            Console.WriteLine("前序遍历");
            PreOrderTraversal(tree);
            Console.WriteLine("--------------------------------------");
            PreOrderTraversal(tree,
               (x, b) =>
               {
                   Console.WriteLine("节点个数：" + b);
                   Console.WriteLine("遍历结束");
               });
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("中序遍历");
            InOrderTraversal(tree);
            Console.WriteLine("--------------------------------------");
            InOrderTraversal(tree,
               (x, b) =>
               {
                   Console.WriteLine("节点个数：" + b);
                   Console.WriteLine("遍历结束");
               });
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("后序遍历");
            PostOrderTraversal(tree);
            Console.WriteLine("--------------------------------------");
            PostOrderTraversal(tree,
               (x, b) =>
               {
                   Console.WriteLine("节点个数：" + b);
                   Console.WriteLine("遍历结束");
               });
            Console.WriteLine("--------------------------------------");
        }
    }
}
