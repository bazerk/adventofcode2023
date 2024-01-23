namespace AdventOfCode.day7;

public static class Day7 {

    private static IEnumerable<Hand> LoadData(string inputFile, bool jacksWild = false) {
        foreach (var line in File.ReadLines(inputFile)) {
            var split = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            yield return new Hand {
                Cards = split[0],
                Bid = int.Parse(split[1]),
                JacksWild = jacksWild
            };
        }
    }

    public static int SolveStar1(string inputFile = "day7/input.txt") {
        var data = LoadData(inputFile).ToList();
        data.Sort();
        var sum = 0;
        for (var ix = 0; ix < data.Count; ix++) {
            sum += data[ix].Bid * (ix + 1);
        }
        return sum;
    }

    public static int SolveStar2(string inputFile = "day7/input.txt") {
        var data = LoadData(inputFile, jacksWild: true).ToList();
        data.Sort();
        var sum = 0;
        for (var ix = 0; ix < data.Count; ix++) {
            sum += data[ix].Bid * (ix + 1);
        }
        return sum;
    }
}