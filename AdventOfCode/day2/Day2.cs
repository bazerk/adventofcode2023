using System.Text.RegularExpressions;

namespace AdventOfCode.day2;

public static class Day2 {

    private static IEnumerable<Game> LoadGames(string inputFile) {
        foreach (var line in File.ReadAllLines(inputFile)) {
            var gameSplit = line.Split(":",
                StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries
            );
            var gameIndex = int.Parse(gameSplit[0].Substring(5));
            var roundsData = gameSplit[1].Split(";");
            var rounds = new List<Colours>();

            foreach (var roundData in roundsData) {
                var colourSplit = roundData.Split(",",
                    StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries
                );
                var colours = new Colours();
                rounds.Add(colours);
                foreach (var colourData in colourSplit) {
                    var match = Regex.Match(colourData, @"(?<count>[0-9]+)\s+(?<colour>(red|green|blue))");
                    var count = int.Parse(match.Groups["count"].Value);
                    var colour = match.Groups["colour"].Value;
                    colours.SetColour(colour, count);
                }
            }
            
            yield return new Game(gameIndex, rounds);
        }
    }
    
    public static int SolveStar1(string inputFile = "day2/input.txt") {
        var sum = 0;
        var bagContents = new Colours {
            Red = 12,
            Green = 13,
            Blue = 14
        };
        foreach (var game in LoadGames(inputFile)) {
            var possible = true;
            foreach (var round in game.Rounds) {
                if (round.Red > bagContents.Red || round.Green > bagContents.Green || round.Blue > bagContents.Blue) {
                    possible = false;
                    break;
                }
            }
            if (possible) {
                sum += game.Index;
            }
        }
        return sum;
    }
    
    public static int SolveStar2(string inputFile = "day2/input.txt") {
        var sum = 0;
        foreach (var game in LoadGames(inputFile)) {
            var minBalls = new Colours();
            foreach (var round in game.Rounds) {
                minBalls.Red = Math.Max(minBalls.Red, round.Red);
                minBalls.Green = Math.Max(minBalls.Green, round.Green);
                minBalls.Blue = Math.Max(minBalls.Blue, round.Blue);
            }

            var power = minBalls.Red * minBalls.Blue * minBalls.Green;
            sum += power;
        }
        return sum;
    }
}