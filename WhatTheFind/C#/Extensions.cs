using System;
using System.Collections.Generic;

namespace WhatTheFind
{
    public static class Extensions
    {
        /// <summary>
        /// Find any node in an object graph that satisfy a given predicate and return it.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="root">The root node.</param>
        /// <param name="predicate">The given condition to satisfy.</param>
        /// <param name="getChildren">Child selector.</param>
        /// <returns>Node satisfying the condition, else null.</returns>
        public static T FindWhere<T>(this T root, Func<T, bool> predicate, Func<T, IEnumerable<T>> getChildren)
            where T : class
        {
            // YOUR SOLUTION GOES HERE
            // If value has been found, return value
            if (predicate(root))
            {
                return root;
            }

            // If no children exists for root return null
            if (getChildren(root) == null)
            {
                return null;
            }

            // Look through each child to 1. check for more children and 2. look for
            // the value that makes predicate true in the found child
            T foundChild = null;
            foreach (var child in getChildren(root))
            {
                Console.WriteLine("Checking of child commences");
                var returnedVar = FindWhere(child, predicate, getChildren);
                if (returnedVar != null)
                {
                    Console.WriteLine("Child found");
                    foundChild = returnedVar;
                }
                Console.WriteLine("Checking of child completed");
            }

            return foundChild;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var nodeBB = new Node { Value = 3 };
            var nodeBA = new Node { Value = 2 };
            var nodeB = new Node { Value = 1, Children = new List<Node> { nodeBA, nodeBB } };
            var nodeA = new Node { Value = 0, Children = new List<Node> { nodeB } };


            var found = nodeA.FindWhere(x => x.Value == 3, x => x.Children);
            Console.WriteLine($"Found element value: {found.Value}");

            try
            {
                found = nodeA.FindWhere(x => x.Value == 4, x => x.Children);
                Console.WriteLine($"Found element value: {found.Value}");
            }
            catch (Exception)
            {
                Console.WriteLine("Element not found");
            }

            Console.ReadLine();
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public IEnumerable<Node> Children { get; set; }
    }
}
