using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223 {
    class Card {

        private readonly SuitType suitType;
        private readonly int value;
        
        public Card(SuitType suitType, int value) {
            this.suitType = suitType;

            if (value <= 0 || value > 13) {
                throw new ArgumentOutOfRangeException(nameof(value), "Card value must be > 0 and < 13!");
            }
            this.value = value;
        }
        
    }
}