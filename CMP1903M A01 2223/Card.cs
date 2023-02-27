using System;

namespace CMP1903M_A01_2223 {
    class Card {
        public readonly SuitType suitType;
        public readonly int value;

        public Card(SuitType suitType, int value) {
            this.suitType = suitType;

            if (value <= 0 || value > 13) {
                throw new ArgumentOutOfRangeException(nameof(value), "Card value must be > 0 and < 13!");
            }

            this.value = value;
        }

        public override string ToString() {
            return "Card; Suit: " + suitType + " Value: " + value;
        }
    }
}