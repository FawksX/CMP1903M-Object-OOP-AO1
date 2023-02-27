using System.Collections.Generic;
using System.Linq;

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
            foreach (var card in pack.ToList()) {
                var index = pack.IndexOf(card);
                var randomIndex = Util.RANDOM.Next(index, pack.Count);
                (pack[index], pack[randomIndex]) = (pack[randomIndex], pack[index]);
            }

            return true;
        }
    }

    /**
     * Riffle shuffle is the traditional card shuffle where you split the deck in two and put each card in one
     * after another, taking it in turns from each side of the split deck (usually LR, LR, LR....)
     * So this sort we need to split the deck and rejoin it by taking one from each side of the deck
     */
    class RiffleShuffleSort : Sort {
        public bool Sort(Pack pack) {
            var halfDeckSize = pack.Count / 2;


            var left = pack.GetRange(0, halfDeckSize - 1);
            var right = pack.GetRange(halfDeckSize - 1, halfDeckSize - 1);

            var newDeck = new List<Card>();
            for (var i = 0; i < halfDeckSize -1; i++) {
                newDeck.Add(left[i]);
                newDeck.Add(right[i]);
            }

            pack.Clear();
            pack.AddRange(newDeck);

            return true;
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

        public static int GetSortId(Sort sort) {
            if (sort is FisherYatesShuffleSort) {
                return 1;
            }
            else if (sort is RiffleShuffleSort) {
                return 2;
            }
            else {
                return 3; // No Shuffle
            }
        }
    }
}