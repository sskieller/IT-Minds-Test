namespace VacationCost
{
    // Template Pattern
    // 1. Calculator
    public abstract class VacationCostCalculator
    {
        public abstract double DistanceToDestination { get; set; }

        public abstract decimal CostOfVacation();
    }

    // 2. ConcreteCalculator
    public class CarCostCalculator : VacationCostCalculator
    {
        public override double DistanceToDestination { get; set; }

        public override decimal CostOfVacation()
        {
            return (decimal)DistanceToDestination * 1;
        }

    }

    public class PlaneCostCalculator : VacationCostCalculator
    {
        public override double DistanceToDestination { get; set; }

        public override decimal CostOfVacation()
        {
            return (decimal)DistanceToDestination * 2;
        }
    }

    // Factory Pattern
    // 3. Creator
    public abstract class VacationCostCalculatorFactory
    {
        public abstract VacationCostCalculator VacationCostCalculator();
    }

    // 4. ConcreteCreator
    internal class CarCostCalculatorFactory : VacationCostCalculatorFactory
    {
        public override VacationCostCalculator VacationCostCalculator()
        {
            return new CarCostCalculator();
        }
    }

    internal class PlaneCostCalculatorFactory : VacationCostCalculatorFactory
    {
        public override VacationCostCalculator VacationCostCalculator()
        {
            return new PlaneCostCalculator();
        }
    }
}