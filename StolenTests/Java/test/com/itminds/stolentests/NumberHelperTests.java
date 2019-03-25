package com.itminds.stolentests;

import solution.NumberHelper;
import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class NumberHelperTests  {
    /*
     * This section contains a very basic test example
     * The test in this document should be re-written, as it does not represent best practices
     */
    @Test
    public void testExample() {
        // Arrange
        List<Integer> haystack = Arrays.asList(1,2,5,10,12);
        final int needle = 1;
        NumberHelper helper = new NumberHelper();
        // Act
        ArrayList results = makeCollection(helper.findClosestNumbers(needle, haystack, 1));

        // Assert
        //Assert.Equals(results.ElementAt(0), 1);
        Assert.assertEquals(results.get(0), 1);
    }

    /*
     * HELPER METHODS
    */
    private <E> ArrayList<E> makeCollection(Iterable<E> iter) {
        ArrayList<E> list = new ArrayList<E>();
        for (E item : iter) {
            list.add(item);
        }
        return list;
    }

}