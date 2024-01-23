namespace AdventOfCode.day7;

public class Hand : IComparable<Hand> {
    public string Cards { get; init; }
    public int Bid { get; init; }
    
    public bool JacksWild { get; init; }

    private static readonly Dictionary<char, int> CardStrengths = new() {
        {'2', 2},
        {'3', 3},
        {'4', 4},
        {'5', 5},
        {'6', 6},
        {'7', 7},
        {'8', 8},
        {'9', 9},
        {'T', 10},
        {'J', 11},
        {'Q', 12},
        {'K', 13},
        {'A', 14},
    };
    
    private static readonly Dictionary<char, int> CardStrengthsJacksWild = new() {
        {'2', 2},
        {'3', 3},
        {'4', 4},
        {'5', 5},
        {'6', 6},
        {'7', 7},
        {'8', 8},
        {'9', 9},
        {'T', 10},
        {'J', 1},
        {'Q', 12},
        {'K', 13},
        {'A', 14},
    };
    
    private int Strength => JacksWild ? StrengthJacksWild : StrengthBase;

    private int StrengthBase {
        get {
            var counts = new Dictionary<char, int>();
            foreach (var ch in Cards) {
                counts[ch] = counts.GetValueOrDefault(ch, 0) + 1;
            }

            var pairCount = 0;
            var threeOfAKind = 0;
            foreach (var count in counts.Values) {
                if (count == 2) pairCount++;
                else if (count == 3) threeOfAKind++;
                else if (count == 4) return 5;
                else if (count == 5) return 6;
            }

            if (pairCount == 2) return 2;
            if (pairCount == 1 && threeOfAKind == 1) return 4;
            if (threeOfAKind == 1) return 3;
            if (pairCount == 1) return 1;
            return 0;            
        }
    }
    
    
    private int StrengthJacksWild {
        get {
            var counts = new Dictionary<char, int>();
            foreach (var ch in Cards) {
                counts[ch] = counts.GetValueOrDefault(ch, 0) + 1;
            }

            var wildCards = 0;
            var pairCount = 0;
            var threeOfAKind = 0;
            var fourOfAKind = 0;
            foreach (var (ch, count) in counts) {
                if (count == 5) return 6;
                
                if (ch == 'J') wildCards = count;
                else if (count == 2) pairCount++;
                else if (count == 3) threeOfAKind++;
                else if (count == 4) fourOfAKind++;
            }
            
            if (fourOfAKind == 1 && wildCards == 1) return 6;
            if (threeOfAKind == 1 && wildCards == 2) return 6;
            if (pairCount == 1 && wildCards == 3) return 6;
            if (wildCards == 4) return 6;

            if (fourOfAKind == 1) return 5;
            if (threeOfAKind == 1 && wildCards == 1) return 5;
            if (pairCount == 1 && wildCards == 2) return 5;
            if (wildCards == 3) return 5;

            if (pairCount == 2 && wildCards == 1) return 4;
            if (pairCount == 1 && threeOfAKind == 1) return 4;

            if (threeOfAKind == 1) return 3;
            if (pairCount == 1 && wildCards == 1) return 3;
            if (wildCards == 2) return 3;
            
            if (pairCount == 2) return 2;
            
            if (pairCount == 1) return 1;
            if (wildCards == 1) return 1;
            
            return 0;    
        }
    }

    public int CompareTo(Hand? other) {
        if (other == null) return 1;
        var result = this.Strength.CompareTo(other.Strength);
        if (result != 0) return result;
        for (var ix = 0; ix < 5; ix++) {
            var strengths = JacksWild ? CardStrengthsJacksWild : CardStrengths;
            var myCardStrength = strengths[Cards[ix]];
            var otherCardStrength = strengths[other.Cards[ix]];
            result = myCardStrength.CompareTo(otherCardStrength);
            if (result != 0) return result;
        }

        return 0;
    }
}