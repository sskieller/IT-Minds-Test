package com.itminds.vacationcost;

public class Program  {
    public static void main(String[] args)
    {
        if(args.length < 2)
        {
            System.out.println("Not enough input arguments to run this program");
        }
        else
        {
            String transportMethod = args[0];
            String distance = args[1];
            VacationCostCalculator calculator = new VacationCostCalculator(Double.parseDouble(distance));
            double result = calculator.costOfVacation(transportMethod);
            System.out.println(result);
        }
    }
}