package com.itminds.guessthepattern.a;
public class PatternA {
    private static PatternA instance;
    private PatternA() {
    }

    public static PatternA getInstance()    {
        if (instance == null)
            instance = new PatternA();

        return instance;
    }

    public void doWork()
    {
        throw new UnsupportedOperationException();
    }
}

/* Write your answers and comments below this line

*/