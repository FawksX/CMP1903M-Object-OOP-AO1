using System;

namespace CMP1903M_A01_2223 {
    interface Sort {
        Pack Sort(Pack pack);
    }

    class NoShuffleSort : Sort {
        public Pack Sort(Pack pack) {
            return pack;
        }
    }

    class FisherYatesShuffleSort : Sort {
        public Pack Sort(Pack pack) {
            throw NotImplementedException();
        }
    }

    class RiffleShuffleSort : Sort {
        public Pack Sort(Pack pack) {
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