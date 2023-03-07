using static CMP1903M_A01_2223.Util;

namespace CMP1903M_A01_2223 {
    
    /**
     * <summary>
     * Testing Class
     * This runs through all the tests to ensure they work correctly. With the exception of
     * No-Shuffle (which should be 100% similarity), the similarity reports should not be high numbers.
     *
     * As this is a utility class, the entrypoint is <see cref="Testing.Test"/>
     * </summary>
     */
    public class Testing {
        
        /**
         * Runs the Test
         */
        public static void Test() {
            HandleSort(Sorts.NO_SHUFFLE);
            HandleSort(Sorts.FISHER_YATES_SHUFFLE);
            HandleSort(Sorts.RIFFLE_SHUFFLE);
        }

        /**
         * A simple method to reset the pack, find a similarity score and deal a random card from the deck.
         * This is used for all sorts - The only one with a high similarity should be <see cref="Sorts.NO_SHUFFLE"/>
         */
        private static void HandleSort(Sort sort) {
            LOGGER.Info("##### HANDLING TEST: " + sort.Name());
            Pack.Reset();
            var oldPack = Pack.Copy();
            Pack.ShuffleCardPack(sort);

            var similarity = GetSimilarity(oldPack);
            LOGGER.Info("The deck is " + similarity + "% similar to the original deck");

            var deal = Pack.deal();
            LOGGER.Info("Deal; " + sort.Name());
            LOGGER.Info(deal.ToString());
        }
        
        /**
         * Gets a similarity score by checking how many cards are in the same index as pre-sort as a percentage
         * This is formatted to 2dp
         */
        private static string GetSimilarity(Pack oldPack) {
            float sameCards = 0;
            foreach (var card in Pack.PACK) {
                if (Pack.PACK.IndexOf(card) == oldPack.IndexOf(card)) {
                    sameCards++;
                }
            }

            float similarity = (sameCards / 52f) * 100;
            return similarity.ToString("n2");
        }
    }
}