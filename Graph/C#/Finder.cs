namespace Graph
{
    public class Finder : IFinder
    {
        public string FromRight(Customers customers, int numberFromRight)
        {
            //You are given a directed graph of `Customer`s, where one `Customer` has exactly one reference to the next `Customer` or `null` if it is the last `Customer`.
            //An example of such a graph can be seen in the diagram below.
            //For instance in the graph above the result for `FromRight(peter, 3)` is Ole.
            //For instance, is it possible to iterate the graph only once while only using a constant number of extra pointers?

            // Customer.Previous: Creates first element. The element "before" is then created and a pointer to the first element is given to the new element
            // FromRight is then given the last-created element, which has access to the rest of the list
            // Element: 5th   4th   3rd   2nd   1st
            //          x4 -> x3 -> x2 -> x1 -> x0

            // YOUR SOLUTION GOES HERE
            var firstCustomerPointer = customers;
            Customers lastCustomerPointer = null;

            var flag = 0;

            while (firstCustomerPointer != null)
            {
                if (flag < numberFromRight - 1)
                {
                    flag++;
                    firstCustomerPointer = firstCustomerPointer.Next;
                }
                else if (flag == numberFromRight - 1)
                {
                    flag++;
                    firstCustomerPointer = firstCustomerPointer.Next;
                    lastCustomerPointer = customers;
                }
                else
                {
                    firstCustomerPointer = firstCustomerPointer.Next;
                    lastCustomerPointer = lastCustomerPointer?.Next;
                }

            }

            return lastCustomerPointer == null ? "Person non-existing" : lastCustomerPointer.Person;
        }
    }
}