package com.itminds.stolentests;

public interface NumberHelperStrategy {

    /** Find a node that satisfy a given predicate and return it.
     * @param needle Number that is searched for
     * @param haystack Collection of numbers that are searched through
     * @param n The amount of numbers close to needle that should be returned
     * @return A collection with the n numbers in haystack closest to needle
     */
    Iterable<Integer> findClosestNumbers(int needle, Iterable<Integer> haystack, int n);
}