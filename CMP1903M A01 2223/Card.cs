using System;

namespace CMP1903M_A01_2223 {

    /**
     * Simple Card Object
     * A card has two pieces of important information; the Suit and the Value of the card (A, 2-10, J, Q, K).
     * In this case, A = 1, J = 11, Q = 12, K = 13 - This is information we know when working with cards.
     * As there is only four suits we have made this an Enum for simplicity.
    **/
    public class Card {
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

        public override int GetHashCode() {
            return (int) suitType ^ value;
        }
    }
}