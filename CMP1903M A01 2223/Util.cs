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

        public static void EnsurePackCount() {
            if (Pack.PACK.Count != 52) {
                throw new Exception("The Pack must have 52 cards in order to shuffle!");
            }
        }
        
    }
}