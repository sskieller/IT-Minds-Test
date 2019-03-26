using System;

namespace GuessThePattern
{
    public class PatternA
    {
        private static PatternA _instance;
        private PatternA()
        {
        }

        public static PatternA GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PatternA();
            }

            return _instance;
        }

        public void DoWork()
        {
            throw new NotImplementedException();
        }
    }
}

/* Write your answers and comments below this line
    Pattern: Singleton

    Problems this pattern can solve:
        - If you have a network implementation and only want one class
          to connect out of the network, you can make it using the 
          singleton pattern and let all other classes connect to this one
          i.e. making sure only one instance of the class is created
        - This pattern will enable you to easily access the only instance
          that is created and it controls its instantiation
        - Making sure there's only one DB connection
        - Allows for only one logger instance at any time for an application
    Pros:
        - Allows for lazy initialization
        - Makes sure only one instance is created
        - Will have control over its' own instantiation
        - Allows for easy access to the one instance created
    Cons:
        - Needs to be created thread safe since it's accessed from
          multiple sources
        - Doesn't follow the Single Responsibility Principle since the 
          class itself does both creation and other business responsibilities
          (Can be delegated to a factory object)    
        - Can hide dependencies thus making it harder to test. 
*/
