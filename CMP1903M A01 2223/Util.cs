using System;
using log4net;
using log4net.Appender;

namespace CMP1903M_A01_2223 {

    /**
     * A simple class for a Randmo Instance and a shorthand Print function.
     **/
    public class Util {
        public static readonly Random RANDOM = new Random();
        public static readonly ILog LOGGER = LogManager.GetLogger("CMP1903M_A01_2223");

        public static void EnsurePackCount(Pack pack) {
            if (pack.Count != 52) {
                LOGGER.Error("The Pack must have 52 Cards in order to shuffle!");
                throw new Exception("The Pack must have 52 cards in order to shuffle!");
            }
        }
        
    }
}