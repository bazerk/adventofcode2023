namespace AdventOfCode.day6;

public static class Day6 {
    private static IEnumerable<(int, int)> LoadData(string inputFile) {
        var lines = File.ReadAllLines(inputFile);
        var timeStr = lines[0].Substring("Time:".Length).Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var distanceStr = lines[1].Substring("Distance:".Length).Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var times = timeStr.Select(int.Parse).ToArray();
        var distances = distanceStr.Select(int.Parse).ToArray();
        if (times.Length != distances.Length) throw new ArgumentException("bad");
        for (var ix = 0; ix < times.Length; ix++) {
            yield return (times[ix], distances[ix]);
        }
    }
    
    public static int SolveStar1(string inputFile = "day6/input.txt") {
        var waysToBeat = new List<int>();
        foreach (var (time, record) in LoadData(inputFile)) {
            var ways = 0;
            for (var held = 1; held < time; held++) {
                var distance = held * (time - held);
                if (distance > record) ways++;
            }
            waysToBeat.Add(ways);
        }
        return waysToBeat.Aggregate((x1, x2) => x1 * x2);
    }
    public static int SolveStar2(string inputFile = "day6/input.txt") {
        var data = LoadData(inputFile);
        var timeStr = "";
        var distStr = "";
        foreach (var (t, d) in data) {
            timeStr += t.ToString();
            distStr += d.ToString();
        }

        var time = long.Parse(timeStr);
        var record = long.Parse(distStr);
        var ways = 0;
        for (var held = 1; held < time; held++) {
            var distance = held * (time - held);
            if (distance > record) ways++;
        }

        return ways;
    }
}