package com.itminds.stringissue;

public class StringHelpers {
    /** Method that does not perform well.
     * @param strs An iterable of strings
     * @return The merged string
     */
    public static String mergeStrings(Iterable<String> strs) {
        String toReturn = "";
        for (String str : strs) {
            toReturn += str;
        }
        return toReturn;
    }
}