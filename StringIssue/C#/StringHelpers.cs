using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StringIssue
{
    public static class StringHelpers
    {
        /// <summary>
        /// Method that does not perform well.
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string MergeStrings(IEnumerable<string> strs)
        {
            var concurrentBag = new ConcurrentBag<string>();

            Parallel.ForEach(strs, str =>
            {
                concurrentBag.Add(str);
            });

            return string.Join(null, concurrentBag);
        }

        // Delete me when done
        public static string OldMergeStrings(IEnumerable<string> strs)
        {
            var toReturn = "";

            foreach (var str in strs)
            {
                toReturn += str;
            }

            return toReturn;
        }
    }
}
/* Explain why your solution is faster below this line
    Per statistics gathered when running the old implementation compared to the new one
    the parallel MergeStrings is approximately 35000% faster than OldMergeStrings.

    This is due to the fact that this problem can be solved using parallel tasks.
    Instead of one task doing all the concatenation in a row, a bunch of tasks get
    a smaller set of the complete source and then concatenates these together first.
    When they are done concatenating their smaller subset, the final product is 
    all the subsets concatenated.

    OldMergeStrings: Concat => Concat => Concat => Concat => Concat => Concat => Concat => Concat => Concat

    MergeStrings:  / Concat => Concat => Concat \
            Source - Concat => Concat => Concat - Joined
                   \ Concat => Concat => Concat /
*/
