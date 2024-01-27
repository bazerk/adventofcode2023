namespace AdventOfCode.day9;

public static class Day9 {

    private static IEnumerable<List<int>> LoadData(string filename) {
        foreach (var line in File.ReadLines(filename)) {
            var split = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            yield return split.Select(int.Parse).ToList();
        }
    }
    
    
    public static int SolveStar1(string inputFile = "day9/input.txt") {
        var sum = 0;
        bool IsStable(List<int> values) => values.TrueForAll(x => x == 0);
        foreach (var initialSequence in LoadData(inputFile)) {
            var sequence = initialSequence;
            var stack = new Stack<List<int>>();
            while (!IsStable(sequence)) {
                stack.Push(sequence);
                var next = new List<int>();
                for (var ix = 0; ix < sequence.Count - 1; ix++) {
                    next.Add(sequence[ix + 1] - sequence[ix]);
                }
                sequence = next;
            }

            var addToEnd = 0;
            while (stack.Count > 0) {
                sequence = stack.Pop();
                addToEnd = sequence.Last() + addToEnd;
            }

            sum += addToEnd;
        }
        
        return sum;
    }
    
    public static int SolveStar2(string inputFile = "day9/input.txt") {
        var sum = 0;
        bool IsStable(List<int> values) => values.TrueForAll(x => x == 0);
        foreach (var initialSequence in LoadData(inputFile)) {
            var sequence = initialSequence;
            var stack = new Stack<List<int>>();
            while (!IsStable(sequence)) {
                stack.Push(sequence);
                var next = new List<int>();
                for (var ix = 0; ix < sequence.Count - 1; ix++) {
                    next.Add(sequence[ix + 1] - sequence[ix]);
                }
                sequence = next;
            }

            var subStractFromStart = 0;
            while (stack.Count > 0) {
                sequence = stack.Pop();
                subStractFromStart = sequence[0] - subStractFromStart;
            }

            sum += subStractFromStart;
        }
        
        return sum;
    }
}