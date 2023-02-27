using System;
using System.Collections.Generic;
using System.Linq;

namespace CMP1903M_A01_2223 {

    /**
     * <summary>
     * Pack Object
     * As our Pack only ever has a set number of elements, we can make this object extend List. This means that all List
     * functions can be accessed directly rather than being nested inside of the object.
     * </summary>
     **/
    class Pack : List<Card> {
        public static Pack PACK = Builder().Build();

        private Pack(List<Card> initialCards) : base(54) {
            AddRange(initialCards);
        }

        private Pack() {

        }

        /**
         * <summary>
         * Shuffles the Pack to the desired type. These are:
         * 1 - Fisher Yates Shuffle (<see cref="Sorts.FISHER_YATES_SHUFFLE"/>
         * 2 - Riffle Shuffle (<see cref="Sorts.RIFFLE_SHUFFLE"/>
         * 3 - No Shuffle (<see cref="Sorts.NO_SHUFFLE"/>
         * 
         * This method should not be the preferred method for accessing the code and should be used only
         * by pre-existing software. Instead, we recommend the Method <see cref="ShuffleCardPack(CMP1903M_A01_2223.Sort)"/>
         * instead as it does not rely on magic numbers.
         * </summary>
         * <returns>
         * If the pack has successfully been shuffled
         * </returns>
         **/
        [Obsolete("shuffleCardPack has been replaced by ShuffleCardPack(CMP1903M_A01_2223.Sort)")]
        public static bool shuffleCardPack(int typeOfShuffle) {
            var sort = Sorts.GetSort(typeOfShuffle);
            return sort.Sort(PACK);
        }

        /**
         * <summary>
         * Shuffles the Pack to any <see cref="Sort"/> given. By default, three sorts are supplied in
         * <see cref="Sorts"/> currently:
         * - Fisher Yates Shuffle (<see cref="Sorts.FISHER_YATES_SHUFFLE"/>
         * - Riffle Shuffle (<see cref="Sorts.RIFFLE_SHUFFLE"/>
         * - No Shuffle (<see cref="Sorts.NO_SHUFFLE"/>
         * </summary>
         * <returns>
         * If the pack has successfully been shuffled
         * </returns>
         **/
        public static bool ShuffleCardPack(Sort sort) {
            return sort.Sort(PACK);
        }

        /**
         * <summary>
         * Deals a card from the top of the Deck, assuming that the deck has atleast one card in it.
         * </summary>
         * <returns>
         * The card which was taken from the top of the deck
         * </returns>
         **/
        public static Card deal() {
            if (PACK.Count < 1) {
                throw new Exception("There is not enough cards in the deck to deal!");
            }

            var card = PACK.First();
            PACK.Remove(card);
            return card;
        }

        /**
         * <summary>
         * Deals a number of cards from the top of the Deck, assuming the deck has the number which are to be dealt.
         * </summary>
         * <returns>
         * A list of cards which have been taken from the top of the deck
         * </returns>
         **/
        public static List<Card> dealCard(int amount) {
            if (PACK.Count < amount) {
                throw new Exception("There is not enough cards in the deck to deal!");
            }

            var cards = PACK.GetRange(0, amount);
            PACK.RemoveRange(0, amount);
            return cards;
        }

        /**
         * <summary>
         * Resets the Pack Singleton and creates a fresh, unsorted deck.
         * </summary>
         **/
        public static void Reset() {
            PACK = Builder().Build();
        }

         /**
         * <summary>
         * Creates a snapshot of the current Pack and returns it as a new instance
         * </summary>
         * <returns>
         * A copy of the current Pack.
         * </returns>
         **/
        public static Pack Copy() {
            // We want all the cards currently in the deck, so the predication can just always be true
            return new Pack(PACK.FindAll(card => { return true; }));
        }

         /**
         * <summary>
         * Creates a new PackBuilder which is used to make a new Pack using the Builder Pattern
         * </summary>
         * <returns>
         * A new PackBuilder instance
         * </returns>
         **/
        public static PackBuilder Builder() {
            return new PackBuilder();
        }

        /**
         * <summary>
         * PackBuilder Object
         * 
         * A simple Builder Pattern for instantiating Pack Objects if the codebase ever requires more than
         * one at a time. By default, it will return an unsorted Pack, with the option to have a pack of only
         * certain suits or sorted by a certain sort.
         * </summary>
         **/
        public class PackBuilder {

            private SuitType[] suits = {
                SuitType.Clubs,
                SuitType.Diamonds,
                SuitType.Heart,
                SuitType.Spades
            };

            private Sort sort = Sorts.NO_SHUFFLE;

            /**
             * <summary>
             * Allows the user to specify a number of suits to use when creating the new
             * Pack. By default, it is all 4 suits
             * </summary>
             * <returns>
             * The existing PackBuilder Object
             * </returns>
             **/
            public PackBuilder Suits(params SuitType[] suits) {
                this.suits = suits;
                return this;
            }

             /**
             * <summary>
             * Allows the user to specify a sort when creating the pack so they are not ordered
             * </summary>
             * <returns>
             * The existing PackBuilder Object
             * </returns>
             **/
            public PackBuilder Sort(Sort sort) {
                this.sort = sort;
                return this;
            }

             /**
             * <summary>
             * Builds the pack object using the defaults or specified parameters
             * </summary>
             * <returns>
             * The new Pack Object
             * </returns>
             **/
            public Pack Build() {
                var cards = new List<Card>();
                foreach (var suitType in suits) {
                    for (var i = 1; i <= 13; i++) {
                        cards.Add(new Card(suitType, i));
                    }
                }

                Pack pack = new Pack(cards);
                sort.Sort(pack);

                return pack;
            }
        }
    }
}