using System;

namespace BinarySearchTree
{
    public class BinarySearchTree
    {

        public class Node
        {
            public int Data;
            public Node Left;
            public Node Right;
            public void DisplayNode()
            {
                Console.Write(Data + " ");
            }
        }
        public Node root;
        public BinarySearchTree()
        {
            root = null;
        }
        public void Insert(int i)
        {
            Node newNode = new Node();
            newNode.Data = i;
            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (i < current.Data)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }

                        else
                        {
                            current = current.Right;
                            if (current == null)
                            {
                                parent.Right = newNode;
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void Main()
        {
            BinarySearchTree nums = new BinarySearchTree();

            nums.Insert(7);
            nums.Insert(5);
            nums.Insert(1);
            nums.Insert(8);
            nums.Insert(3);
            nums.Insert(6);
            nums.Insert(9);
            nums.Insert(0);
            nums.Insert(9);
            nums.Insert(4);
            nums.Insert(2);

            Console.Read();
        }
    }
}
