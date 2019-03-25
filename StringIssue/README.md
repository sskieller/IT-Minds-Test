# Performance issue

During profiling of a system that does not perform well it is discovered that the bottleneck is this function:

\[ C# \]
```csharp
public static class StringHelpers
{
	public static string MergeStrings(IEnumerable<string> strs)
}
```
\[ Java \]
```java
public class StringHelpers
{
    public static String mergeStrings(Iterable<String> strs)
}
```

It's executing very slowly.

# Solution

Your task is to refactor the `StringHelpers.MergeStrings` function and explain why its execution time is improved.

You're not allowed to change the prototype of the function.

## What you'll be evaluated on

You'll be evaluated on the efficiency of your solution and the ability to explain why your code is more efficient.
Note that the right solution without an explanation gives no points.
