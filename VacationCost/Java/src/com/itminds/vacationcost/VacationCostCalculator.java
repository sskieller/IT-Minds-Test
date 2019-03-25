package com.itminds.vacationcost;

public class VacationCostCalculator  {
    private double distanceToDestination;

    public VacationCostCalculator(double distance) {
        distanceToDestination = distance;
    }

    public double costOfVacation(String transportMethod) {
        switch (transportMethod) {
            case "Car":
                return distanceToDestination * 1;
            case "Plane":
                return distanceToDestination * 2;
            default:
                throw new UnsupportedOperationException();
        }
    }

    public double getDistanceToDestination() {
        return distanceToDestination;
    }

    public void setDistanceToDestination(double distanceToDestination) {
        this.distanceToDestination = distanceToDestination;
    }
}