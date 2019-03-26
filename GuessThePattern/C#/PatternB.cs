namespace GuessThePattern
{
    public abstract class SomeObject
    {
    }

    public class ConcreteSomeObject : SomeObject
    {
    }

    public abstract class PatternB
    {
        public abstract SomeObject Create();
    }

    public class ConcretePatternB : PatternB
    {
        public override SomeObject Create()
        {
            return new ConcreteSomeObject();
        }
    }
}

/* Write your answers and comments below this line
    Pattern: Abstract class factory?

    Problems this pattern can solve:
        - Will remove the need for dependencies regarding the concrete type.
          The code calling the factory will only have to deal with the 
          abstract type even though the factory creates a concrete type.
        - If a system has multiple families of objects and the design 
          suggests these should be used together, this pattern can be used.

    Pros:
        - Allows for easy manageable code by allowing the addition of new
          concrete types just by altering the calling code to use a 
          different factory
        - If the calling code is unsure what type of object to create, this
          pattern can solve the problem by ensuring the correct object are
          created even though the calling code is only accessing the abstract
          factory/interface
    Cons:
        - Adding new objects can be challenging. Support for new types of
          objects requires you to change the AbstractFactory class and its'
          subclasses.
*/
