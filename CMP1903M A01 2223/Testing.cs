﻿using static CMP1903M_A01_2223.Util;

namespace CMP1903M_A01_2223 {
    public class Testing {
        public static void Test() {
            /**
             * First Sort: No Shuffle
             */
            Print("############ No Shuffle Test: ############");
            Pack.Reset();
            var oldPackNoShuffle = Pack.Copy();
            Pack.shuffleCardPack(Sorts.GetSortId(Sorts.NO_SHUFFLE));
            foreach (var cardNoShuffle in Pack.PACK) {
                if (Pack.PACK.IndexOf(cardNoShuffle) != oldPackNoShuffle.IndexOf(cardNoShuffle)) {
                    Print("The Shuffle sort has not completed properly");
                }
            }

            var dealNoShuffle = Pack.deal();
            Print("Deal; No Shuffle:");
            Print(dealNoShuffle.ToString());

            /**
             * Second Shuffle: Fisher-Yates Shuffle
             */
            Print("############ Fisher-Yates Shuffle Test: ############");
            Pack.Reset();
            var oldPackFisher = Pack.Copy();
            Pack.shuffleCardPack(Sorts.GetSortId(Sorts.FISHER_YATES_SHUFFLE));
            var sameCard = 0;

            foreach (var cardFisher in Pack.PACK) {
                if (Pack.PACK.IndexOf(cardFisher) == oldPackFisher.IndexOf(cardFisher)) {
                    sameCard++;
                }
            }

            float similarityPercentFisher = (sameCard / 54f) * 100f;
            Print("The deck is " + similarityPercentFisher.ToString("n2") + "% similar to the original deck");

            var dealFisher = Pack.deal();
            Print("Deal; Fisher:");
            Print(dealFisher.ToString());

            /**
             * Third Shuffle: Riffle Shuffle
             **/
            Print("############ Riffle Shuffle Test: ############");
            Pack.Reset();
            var oldPackRiffle = Pack.Copy();
            Pack.shuffleCardPack(Sorts.GetSortId(Sorts.RIFFLE_SHUFFLE));
            float sameCardRiffle = 0;
            foreach (var cardRiffle in Pack.PACK) {
                if (Pack.PACK.IndexOf(cardRiffle) == oldPackRiffle.IndexOf(cardRiffle)) {
                    sameCardRiffle++;
                }
            }

            float similarityRiffle = (sameCardRiffle / 54f) * 100f;
            Print("The deck is " + similarityRiffle.ToString("n2") + "% similar to the original deck");

            var dealRiffle = Pack.deal();
            Print("Deal; Riffle:");
            Print(dealRiffle.ToString());
        }
    }
}