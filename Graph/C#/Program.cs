using System;



namespace Graph
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var currentCustomer = Customers
                .Create("Kim")
                .Previous("Hans")
                .Previous("Ole")
                .Previous("Peter");

            while (currentCustomer != null)
            {
                if (currentCustomer.Next != null)
                {
                    Console.Write(currentCustomer.Person + " -> ");
                }
                else
                {
                    Console.WriteLine(currentCustomer.Person);
                }

                currentCustomer = currentCustomer.Next;
            }

            currentCustomer = Customers
                .Create("Kim")
                .Previous("Hans")
                .Previous("Ole")
                .Previous("Peter");


            var finder = new Finder();

            Console.WriteLine(finder.FromRight(currentCustomer, 0));


            Console.ReadLine();
        }
    }
}
