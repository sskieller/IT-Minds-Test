package com.itminds.whatthefind;

import java.util.function.Predicate;
import java.util.function.Function;

public class Extensions {
    /**
     * Find any node in an object graph that satisfy a given predicate and return it.
     * @param root The root node.
     * @param predicate The given condition to satisfy.
     * @param getChildren Child selector.
     * @param <T> Type of object.
     * @return Node satisfying the condition, else null.
     */
    public static <T> T findWhere(T root, Predicate<T> predicate, Function<T, Iterable<T>> getChildren) {
        // YOUR SOLUTION GOES HERE
        throw new UnsupportedOperationException();
    }
}