using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH6
{
    class Node
    {
        public int Data;
        public Node Left, Right;

        public Node(int item)
        {
            Data = item;
            Left = Right = null;
        }
    }
    class BinarySearchTree
    {
        public Node Root;

        public void Insert(int data)
        {
            Root = InsertRec(Root, data);
        }

        private Node InsertRec(Node root, int data)
        {
            if (root == null)
            {
                root = new Node(data);
                return root;
            }
            if (data < root.Data)
                root.Left = InsertRec(root.Left, data);
            else if (data > root.Data)
                root.Right = InsertRec(root.Right, data);
            return root;
        }

        public void Inorder(Node root)
        {
            if (root != null)
            {
                Inorder(root.Left);
                Console.Write(root.Data + " ");
                Inorder(root.Right);
            }
        }
        public void Preorder(Node root)
        {
            if (root != null)
            {
                Console.Write(root.Data + " ");
                Preorder(root.Left);
                Preorder(root.Right);
            }
        }
        public void Postorder(Node root)
        {
            if (root != null)
            {
                Postorder(root.Left);
                Postorder(root.Right);
                Console.Write(root.Data + " ");
            }
        }

        public Node Delete(Node root, int key)
        {
            if (root == null) return root;

            if (key < root.Data)
                root.Left = Delete(root.Left, key);
            else if (key > root.Data)
                root.Right = Delete(root.Right, key);
            else
            {
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                root.Data = MinValue(root.Right);
                root.Right = Delete(root.Right, root.Data);
            }
            return root;
        }
        private int MinValue(Node root)
        {
            int minv = root.Data;
            while (root.Left != null)
            {
                minv = root.Left.Data;
                root = root.Left;
            }
            return minv;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            BinarySearchTree tree = new BinarySearchTree();


            int[] elements = { 50, 30, 70, 20, 40, 60, 80, 55 };
            foreach (var item in elements)
            {
                tree.Insert(item);
            }


            Console.WriteLine("Duyệt trung tự:");
            tree.Inorder(tree.Root);
            Console.WriteLine();

            Console.WriteLine("Duyệt tiền tự:");
            tree.Preorder(tree.Root);
            Console.WriteLine();

            Console.WriteLine("Duyệt hậu tự:");
            tree.Postorder(tree.Root);
            Console.WriteLine();

            int[] toDelete = { 80, 70, 50 };
            foreach (var key in toDelete)
            {
                tree.Root = tree.Delete(tree.Root, key);
            }
            Console.WriteLine("Duyệt trung tự sau khi xóa:");
            tree.Inorder(tree.Root);
            Console.WriteLine();

            Console.WriteLine("Duyệt tiền tự sau khi xóa:");
            tree.Preorder(tree.Root);
            Console.WriteLine();

            Console.WriteLine("Duyệt hậu tự sau khi xóa:");
            tree.Postorder(tree.Root);
            Console.WriteLine();
        }
    }
}

