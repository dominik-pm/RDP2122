using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeView
{    class BinaryTree<T> where T : IComparable<T>
    {
        public TreeElement<T> Root;

        public void Add(T value)
        {
            Add(ref Root, value);
        }

        private void Add(ref TreeElement<T> current, T value)
        {
            if (current == default)
            {
                current = new TreeElement<T>(value);
                return;
            }

            if (value.CompareTo(current.Value) <= 0) //if value is smaller or equal
            {
                Add(ref current.Left, value);
            }
            else
            {
                Add(ref current.Right, value);
            }
        }

        public void InOrderOutput()
        {
            InOrderOutput(Root);
        }
        private void InOrderOutput(TreeElement<T> current)
        {
            if (current == default) return;
            InOrderOutput(current.Left);
            Console.Write(current + ", ");
            InOrderOutput(current.Right);
        }

        public void ReverseOrderOutput()
        {
            ReverseOrderOutput(Root);
        }
        private void ReverseOrderOutput(TreeElement<T> current)
        {
            if (current == default) return;
            ReverseOrderOutput(current.Right);
            Console.Write(current + ", ");
            ReverseOrderOutput(current.Left);
        }

        public void Delete(T value)
        {
            Delete(Root, value);
        }
        private TreeElement<T> findMin(TreeElement<T> curr)
        {
            if (curr.Left == null) return curr;
            return findMin(curr.Left);
        }
        private TreeElement<T> Delete(TreeElement<T> curr, T value)
        {
            if (curr == default) return default;

            //Search for the right TreeNode
            if (value.CompareTo(curr.Value) < 0)
            {
                curr.Left = Delete(curr.Left, value);
                return curr;
            }
            if (value.CompareTo(curr.Value) > 0)
            {
                curr.Right = Delete(curr.Right, value);
                return curr;
            }

            //if it is the correct Node:

            //3 cases: no child -> just delete node, 1 child -> replace node with child, or 2 childs -> find nearest successor or precessor, delete this successor/precessor
            if (curr.Left == default) //if one is default, return the other Node, if right is also default it will return default and therfor is also correct
            {
                return curr.Right;
            }
            if (curr.Right == default) //both are default, so return default
            {
                return curr.Left;
            }
            //has 2 childs:
            TreeElement<T> minSuccessor = findMin(curr.Right);
            curr.Value = minSuccessor.Value; //set current Value to minSuccessor

            curr.Right = Delete(curr.Right, curr.Right.Value); //Delete this minSuccessor

            return curr;
        }

    }
    class TreeElement<T> where T : IComparable<T>
    {
        public T Value;
        public TreeElement<T> Left;
        public TreeElement<T> Right;

        public TreeElement(T value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
