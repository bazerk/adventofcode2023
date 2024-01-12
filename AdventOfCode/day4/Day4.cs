namespace AdventOfCode.day4;

public static class Day4 {

    private static List<int> ParseNumbers(string input) => input
        .Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
    
    private static IEnumerable<Card> GetCards(string inputFile) {
        foreach (var line in File.ReadLines(inputFile)) {
            var split = line.Split(":", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var cardNumber = int.Parse(split[0].Substring("Card ".Length));
            var numberSplit =
                split[1].Split("|", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            yield return new Card {
                Number = cardNumber,
                WinningNumbers = ParseNumbers(numberSplit[0]),
                Picks = ParseNumbers(numberSplit[1]),
            };
        }
    }
    
    public static int SolveStar1(string inputFile = "day4/input.txt") {
        var sum = 0;
        foreach (var card in GetCards(inputFile)) {
            var winning = card.Picks.Where(card.WinningNumbers.Contains).Count();
            if (winning > 0) {
                var score = (int)Math.Pow(2, winning - 1);
                sum += score;
            }
        }
        return sum;
    }
    
    public static int SolveStar2(string inputFile = "day4/input.txt") {
        var total = 0;
        var cards = GetCards(inputFile).ToList();
        var cardDict =  cards.ToDictionary(c => c.Number, c => c);
        foreach (var card in cards) {
            var winning = card.Picks.Where(card.WinningNumbers.Contains).Count();
            for (var ix = 1; ix <= winning; ix++) {
                cardDict[card.Number + ix].Multiplier += card.Multiplier;
            }
        }

        return cards.Sum(c => c.Multiplier);
    }
}