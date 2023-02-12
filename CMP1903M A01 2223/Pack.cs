﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CMP1903M_A01_2223 {
    class Pack : List<Card> {
        private static Pack PACK = Builder().Build();

        private Pack(List<Card> initialCards) : base(54) {
            AddRange(initialCards);
        }

        public Pack() {
            PACK = Builder().Build();
        }

        public static bool shuffleCardPack(int typeOfShuffle) {
            var sort = Sorts.GetSort(typeOfShuffle);
            return sort.Sort(PACK);
        }

        public static Card deal() {
            if (PACK.Count < 1) {
                throw new Exception("There is not enough cards in the deck to deal!");
            }

            var card = PACK.First();
            PACK.Remove(card);
            return card;
        }

        public static List<Card> dealCard(int amount) {
            if (PACK.Count < amount) {
                throw new Exception("There is not enough cards in the deck to deal!");
            }

            var cards = PACK.GetRange(0, amount);
            PACK.RemoveRange(0, amount);
            return cards;
        }

        public static PackBuilder Builder() {
            return new PackBuilder();
        }

        public class PackBuilder {
            private SuitType[] suits = {
                SuitType.Clubs,
                SuitType.Diamonds,
                SuitType.Heart,
                SuitType.Spades
            };

            private Sort sort = Sorts.NO_SHUFFLE;

            public PackBuilder Suits(params SuitType[] suits) {
                this.suits = suits;
                return this;
            }

            public PackBuilder Sort(Sort sort) {
                this.sort = sort;
                return this;
            }

            public Pack Build() {
                var cards = new List<Card>();
                foreach (var suitType in suits) {
                    for (var i = 1; i <= 13; i++) {
                        cards.Add(new Card(suitType, i));
                    }
                }

                Pack pack = new Pack();
                sort.Sort(pack);

                return pack;
            }
        }
    }
}