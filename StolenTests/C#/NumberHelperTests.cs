using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StolenTests
{
    public class NumberHelperTests
    {
        /*
        * This section contains a very basic test example.
        * The test in this document should be re-written, as it does not represent best practices
        */

        /// <summary>
        /// Find a node that satisfy a given predicate and return it.
        /// </summary>
        /// <param name="needle">Number that is searched for</param>
        /// <param name="haystack">Collection of numbers that are searched through</param>
        /// <param name="n">The amount of numbers close to needle that should be returned</param>
        /// <returns>A collection with the n numbers in haystack closest to needle</returns>
        

        [Fact]
        public void NumberHelper_ListEmpty_ExpectedResult_ArgumentException()
        {
            // Arrange
            var haystackExample = new List<int>{1,2,3};

            const int needle = 3;
            const int n = 2;

            var helper = new NumberHelper();

            // Act
            helper.FindClosestNumbers(needle, haystackExample, n);

            // Assert
            Assert.Throws<ArgumentException>(() => "Empty list");
        }

        [Theory]
        [InlineData(null,1)]
        [InlineData(2,null)]
        //[InlineData(2, "a")] This should be tested for as well but is not directly allowed from InlineData
        //[InlineData("2",2)] This should be tested for as well but is not directly allowed from InlineData
        public void NumberHelper_ArgumentOfWrongTypeOrNotInitialized_ExpectedResult_ArgumentException(int needle, int n)
        {
            // Arrange
            var haystackExample = new List<int> {1, 2, 3};
            
            var helper = new NumberHelper();

            // Act
            helper.FindClosestNumbers(needle, haystackExample, n);

            // Assert
            Assert.Throws<ArgumentException>(() => "Argument of wrong type or not initialized");
        }

        [Fact]
        public void NumberHelper_nBiggerThanListCount_ExpectedResult_ArgumentException()
        {
            // Arrange
            var haystackExample = new List<int> {1,2,3};

            const int needle = 2;
            const int n = 4;

            var helper = new NumberHelper();

            // Act
            helper.FindClosestNumbers(needle, haystackExample, n);

            // Assert
            Assert.Throws<ArgumentException>(() => "n bigger than size of list");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void NumberHelper_ListContainsNumberOfNeedle_ExpectedResult_NeedleReturnedFirst(int n)
        {
            // Arrange
            var haystackExample = new List<int>{1,2,3};

            const int needle = 2;
            var helper = new NumberHelper();

            // Act
            var results = helper.FindClosestNumbers(needle, haystackExample, n);

            // Assert
            Assert.Equal(2, results.First());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void NumberHelper_NonOrderedListContainsNumberOfNeedle_ExpectedResult_NeedleReturnedFirst(int n)
        {
            // Arrange
            var haystackExample = new List<int> { 1, 3, 5, 7, 2, 4, 1, 6 };

            const int needle = 2;
            var helper = new NumberHelper();

            // Act
            var results = helper.FindClosestNumbers(needle, haystackExample, n);

            // Assert
            Assert.Equal(2, results.First());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void NumberHelper_TwoNumbersEquallyCloseToNeedle_ExpectedResult_RoundedDownFirst(int n)
        {
            // Arrange
            var haystackExample = new List<int>{3,5};

            const int needle = 4;
            var helper = new NumberHelper();

            // Act
            var results = helper.FindClosestNumbers(needle, haystackExample, n);

            // Assert
            Assert.Equal(3, results.First());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void NumberHelper_NeedleNumberInListTwice_ExpectedResult_NeedleNumberReturnedFirst(int n)
        {
            // Arrange
            var haystackExample = new List<int> {3,4,4,5};

            const int needle = 4;
            var helper = new NumberHelper();
            
            // Act
            var results = helper.FindClosestNumbers(needle, haystackExample, n);

            // Assert
            var enumerable = results.ToList();

            Assert.Equal(4, n > 1 ? enumerable.ElementAt(1) : enumerable.First());
        }
    }
}
