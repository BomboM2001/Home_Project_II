using System;
using System.Collections.Generic;
using System.Text;

namespace Batman_JR0LDJ
{
    class Node
    {
        public Tools data;
        public Node left;
        public Node right;

        public Node(Tools data)
        {
            this.data = data;
        }

        public void Insert(Tools value)
        {
            if (value.Cost >= data.Cost)
            {
                if (right == null)
                {
                    right = new Node(value);
                }
                else right.Insert(value);
            }
            else
            {
                if (left == null)
                {
                    left = new Node(value);
                }
                else left.Insert(value);
            }
        }
    }
     
        class BinarySearchTree
        {
            public Node root;
            public BinarySearchTree()
            {
                this.root = null;
            }

            public void Store(Tools value)
            {
                if (root == null)
                {
                    root = new Node(value);
                }
                else
                    root.Insert(value);
            }
        }
    }

