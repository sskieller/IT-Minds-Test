using System.Collections.Generic;

namespace GuessThePattern
{
    public abstract class Foo
    {
        private readonly List<Bar> _list = new List<Bar>();

        public void Attach(Bar bar)
        {
            _list.Add(bar);
        }

        public void Detach(Bar bar)
        {
            _list.Remove(bar);
        }

        public void Notify()
        {
            foreach (var o in _list)
            {
                o.Update();
            }
        }
    }

    public abstract class Bar
    {
        protected readonly Foo Foo;

        protected Bar(Foo foo)
        {
            Foo = foo;
        }

        public abstract void Update();
    }
}

/* Write your answers and comments below this line
    Pattern: Observer pattern

    Problems this pattern can solve:
        - High Coupling: Allows implementation of distributed event handling 
          systems allowing decoupling across the application
        - Ensures that an undetermined number of objects are updated 
          automatically based on when once object changes states
        - Allows for MVC design in GUI applications by allowing events to
          send information between the layers instead of direct coupling
    Pros:
        - Allows for event handling without coupling
        - Allows for one object to notify an undetermined number of other
          objects
    Cons:
        - Can cause memory leaks if the subscribers fail to unsubscribe when
          they no longer need the information. This makes the subscriber
          unable to be garbage-collected and thus the amount of subscribers
          can increase uncontrolled
*/
