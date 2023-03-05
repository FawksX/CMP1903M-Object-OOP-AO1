using System;

namespace CMP1903M_A01_2223 {

    /**
     * A simple class for a Randmo Instance and a shorthand Print function.
     **/
    public class Util {
        public static readonly Random RANDOM = new Random();

        public static void Print(string message) {
            Console.WriteLine(message);
        }
        
    }
}