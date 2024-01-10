namespace AdventOfCode.day1;

public static class Day1 {
    public static int SolveStar1(string inputFile = "day1/input.txt") {
        var sum = 0;
        foreach (var line in File.ReadLines(inputFile)) {
            var first = line.First(char.IsDigit);
            var last = line.Last(char.IsDigit);
            sum += int.Parse($"{first}{last}");
        }
        return sum;
    }

    private static List<Tuple<string, string>> _replacers = [
        new("zero", "0"),
        new("one", "1"),
        new("two", "2"),
        new("three", "3"),
        new("four", "4"),
        new("five", "5"),
        new("six", "6"),
        new("seven", "7"),
        new("eight", "8"),
        new("nine", "9"),
    ];

    public static int SolveStar2(string inputFile = "day1/input.txt") {
        var sum = 0;
        foreach (var l in File.ReadLines(inputFile)) {
            var line = "";
            for (var ix = 0; ix < l.Length; ix++) {
                if (char.IsDigit(l[ix])) {
                    line += l[ix];
                    continue;
                }

                var sub = l.Substring(ix);
                foreach (var (test, replace) in _replacers) {
                    if (sub.StartsWith(test)) {
                        line += replace;
                        break;
                    }
                }                
            }

            var first = line.First(char.IsDigit);
            var last = line.Last(char.IsDigit);
            sum += int.Parse($"{first}{last}");
        }
        return sum;
    }
}