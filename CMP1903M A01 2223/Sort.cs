using System;

namespace CMP1903M_A01_2223 {
    interface Sort {
        bool Sort(Pack pack);
    }

    class NoShuffleSort : Sort {
        public bool Sort(Pack pack) {
            // In this case, the bool represents if the pack has ACTUALLY been sorted,
            // So in this case it has not been sorted as it remains the same.
            return false;
        }
    }

    
    /**
     * A Fisher-Yates Shuffle is simple:
     * forEach card in the collection:
     *   - Pick a random Index
     *   - Flip the index1 card with the random index card
     */
    class FisherYatesShuffleSort : Sort {
        public bool Sort(Pack pack) {

            foreach (var card in pack) {
                var index = pack.IndexOf(card);
                var randomIndex = Util.RANDOM.Next(index, pack.Count);
                (pack[index], pack[randomIndex]) = (pack[randomIndex], pack[index]);
            }

            return true;
        }
    }

    class RiffleShuffleSort : Sort {
        public bool Sort(Pack pack) {
            throw NotImplementedException();
        }
    }

    class Sorts {
        public static readonly Sort NO_SHUFFLE = new NoShuffleSort();
        public static readonly Sort FISHER_YATES_SHUFFLE = new FisherYatesShuffleSort();
        public static readonly Sort RIFFLE_SHUFFLE = new RiffleShuffleSort();

        public static Sort GetSort(int sortId) {
            return GetSortOrDefault(sortId, NO_SHUFFLE);
        }
        
        public static Sort GetSortOrDefault(int sortId, Sort defaultSort) {
            switch (sortId) {
                case 1:
                    return FISHER_YATES_SHUFFLE;
                case 2:
                    return RIFFLE_SHUFFLE;
                case 3:
                    return NO_SHUFFLE;
                default:
                    return defaultSort;
            }
        }
    }
}