using System;

namespace CMP1903M_A01_2223 {
    interface Sort {
        bool Sort(Pack pack);
    }

    class NoShuffleSort : Sort {
        public bool Sort(Pack pack) {
            return true; // There is nothing to sort here
        }
    }

    class FisherYatesShuffleSort : Sort {
        public bool Sort(Pack pack) {
            throw NotImplementedException();
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