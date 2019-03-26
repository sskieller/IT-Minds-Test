using System;
using System.Collections.Generic;

namespace SecretAgent
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var agentFinder = new FindSecretAgent();

            IEnumerable<int> idEnumerable = new List<int>
            {
                1,3,5,6,7,8,22,34,56,60,65,77,80,6,5,200,355,999,2000,2,4,9,30,40,59,10,11,120,150,183,550,666
            };

            var id = agentFinder.StartSearch(idEnumerable);

            Console.WriteLine(id == -1 ? "No double id's found" : $"Secret id: {id}");
            Console.ReadKey();
        }
    }
}
