using System;
using System.Collections.Generic;

namespace SecretAgent
{
    public class FindSecretAgent : IFindSecretAgent
    {
        public int StartSearch(IEnumerable<int> ids)
        {
            // Since there is a chance that all the ids will start from
            // 1 and then ascend from there, we would get a problem with
            // implementing a binary search tree, since it would quickly
            // increase in height what with having a 1 in the top. 
            // To avoid this problem the solution can be to implement an
            // AVL Tree which will shift itself according to the height of
            // the tree so that there will never be a case of the tree 
            // ending up similar to a linked list. 

            // Using an AVL tree means that more performance is spent
            // because we need to balance the tree but will counteract the
            // worst-case scenario of a normal Binary Search Tree
            // This will means this solution has a time-complexity for Space
            // at O(n) and Insert at O(log n) at all times.

            // YOUR SOLUTION GOES HERE

            var tree = new Avl();
            foreach (var id in ids)
            {
                tree.AddNode(id);
            }

            tree.PrintTree();

            return tree.DoubleId;
        }
    }

    // Creates avl tree
    public class Avl
    {
        public Node Root;

        public int DoubleId = -1;

        // Creates the nodes used throughout the tree
        public class Node
        {
            // Data for the node
            public int Data;
            // The pointers for the leaves of the node
            public Node LeftNode;
            public Node RightNode;
            // Constructor for the node - saves data to parameter
            public Node(int data)
            {
                Data = data;
            }
        }

        public void AddNode(int nodeData)
        {
            var newNode = new Node(nodeData);
            // if the root is null, just add the newnode as root
            // else do recursive insert with current node set at root
            Root = Root == null ? newNode : RecursiveInsert(Root, newNode);
        }

        private Node RecursiveInsert(Node currentNode, Node newNode)
        {
            // If it has reached end of tree, insert newNode as the node
            if (currentNode == null)
            {
                currentNode = newNode;
                return currentNode;
            }
            // If newNode equals the currentNode, i.e. same ID, throw exception 
            if (newNode.Data == currentNode.Data)
            {
                DoubleId = newNode.Data;
            }
            // If newNode data value is lower than currentNode, place in LeftNode
            // pointer slot and do RecursiveInsert again to find correct insertion slot
            if (newNode.Data < currentNode.Data)
            {
                currentNode.LeftNode = RecursiveInsert(currentNode.LeftNode, newNode);
                currentNode = BalanceTree(currentNode);
            }
            // If newNode data value is higher than currentNode, place in RightNode pointer
            // slot and do RecursiveInsert again
            else if (newNode.Data > currentNode.Data)
            {
                currentNode.RightNode = RecursiveInsert(currentNode.RightNode, newNode);
                currentNode = BalanceTree(currentNode);
            }
            // Allows for recursion to balance the tree all the way up from the last
            // leaf to the root
            return currentNode;
        }

        private Node BalanceTree(Node currentNode)
        {
            // Calculate balance factor of the current node and leaves based on their height
            // The balance is calculated as BF = left - right

            var balanceFactor = BalanceFactor(currentNode);
            // So the case is for a Left child of parent where left is bigger than right thus
            // giving a positive value
            if (balanceFactor > 1)
            {
                // If the tree for the leftNode is still left-heavy there is a Left-Left case
                if (BalanceFactor(currentNode.LeftNode) > 0)
                {
                    currentNode = RotateLeftLeft(currentNode);
                }
                // If the tree for the leftNode is right-heavy there is a Left-Right case
                else
                {
                    currentNode = RotateLeftRight(currentNode);
                }
            }
            // Case for a Right child of parent where right is bigger than left thus giving a 
            // negative score
            else if (balanceFactor < -1)
            {
                // If tree for the rightNode is left-heavy there is a Right-Left case
                if (BalanceFactor(currentNode.RightNode) > 0)
                {
                    currentNode = RotateRightLeft(currentNode);
                }
                // If tree for the rightNode is right-heavy, there is a Right-Right case
                else
                {
                    currentNode = RotateRightRight(currentNode);
                }
            }

            return currentNode;
        }

        #region Rotators

        // Rotates twice to the left (to make up for imbalance)
        private static Node RotateRightRight(Node parentNode)
        {
            // PivotNode is set to the right child of parent
            var pivotNode = parentNode.RightNode;
            // The parent node has the leftNode of the pivot transferred to it
            parentNode.RightNode = pivotNode.LeftNode;
            // The pivotNode will then replace its' current leftNode with the parentNode
            // thus moving the elements around
            pivotNode.LeftNode = parentNode;
            // The new pivotNode is now the parent with the old parentNode as the LeftNode
            // and the rightNode of the old parentNode as the new rightNode
            return pivotNode;
        }

        // Rotates twice to the right (to make up for imbalance)
        private static Node RotateLeftLeft(Node parentNode)
        {
            var pivotNode = parentNode.LeftNode;

            parentNode.LeftNode = pivotNode.RightNode;

            pivotNode.RightNode = parentNode;
            return pivotNode;
        }

        private static Node RotateRightLeft(Node parentNode)
        {
            // Here is a double rotation where the pivotNode first takes the rightNode of
            // the parent
            var pivotNode = parentNode.RightNode;

            // The rightNode is then moved to the right twice, needing an LL-rotation
            parentNode.RightNode = RotateLeftLeft(pivotNode);

            // The parentNode is then moved to the left twice, needing an RR-rotation
            return RotateRightRight(parentNode);
        }

        private static Node RotateLeftRight(Node parentNode)
        {
            var pivotNode = parentNode.LeftNode;

            parentNode.LeftNode = RotateRightRight(pivotNode);

            return RotateLeftLeft(parentNode);
        }

        #endregion

        #region Balance & Height calculation

        public int BalanceFactor(Node currentNode)
        {
            // Getting height of the left and right leaves
            var left = GetHeightOfNode(currentNode.LeftNode);
            var right = GetHeightOfNode(currentNode.RightNode);
            // Creates the balance factor depending on its' nodes. If any height reaches
            // 2 or more the tree is balanced
            var balanceFactor = left - right;

            return balanceFactor;
        }

        public int GetHeightOfNode(Node currentNode)
        {
            var height = 0;

            // If the recursion has reached the end of the tree return height
            if (currentNode == null)
            {
                return height;
            }

            // Recursively accesses the leaves until it reaches a null and
            // then goes back through the tree
            var left = GetHeightOfNode(currentNode.LeftNode);
            var right = GetHeightOfNode(currentNode.RightNode);

            // Picks the biggest number to find out where the imbalance are, if any
            var max = Math.Max(left, right);
            // Adds one to height since a tree of height 0 can have 1 element
            height = max + 1;

            return height;
        }

        #endregion

        #region Printing

        public void PrintTree()
        {
            if (Root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            PrintRestOfTree(Root);
            Console.WriteLine();
        }

        private static void PrintRestOfTree(Node currentNode)
        {
            while (true)
            {
                if (currentNode == null)
                {
                    return;
                }

                PrintRestOfTree(currentNode.LeftNode);
                Console.WriteLine($"({currentNode.Data})");
                currentNode = currentNode.RightNode;
            }
        }

        #endregion
    }
}