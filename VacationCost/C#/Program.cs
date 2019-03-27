using System;

namespace VacationCost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Not enough input arguments to run this program");
                Console.ReadLine();

                return;
            }

            VacationCostCalculatorFactory factory = null;

            var transportMethod = args[0];
            var distance = args[1];

            switch (transportMethod.ToLower())
            {
                case "car":
                    factory = new CarCostCalculatorFactory();
                    break;
                case "plane":
                    factory = new PlaneCostCalculatorFactory();
                    break;
            }

            if (factory != null)
            {
                var vacationCostCalculator = factory.VacationCostCalculator();

                vacationCostCalculator.DistanceToDestination = double.Parse(distance);
                var result = vacationCostCalculator.CostOfVacation();

                Console.WriteLine(result);
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }
}