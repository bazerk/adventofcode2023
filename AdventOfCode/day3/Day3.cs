using AdventOfCode.helpers;

namespace AdventOfCode.day3;

public static class Day3 {

    private static (int, int, bool) ReadNumberPart1(Grid<char> grid, int x, int y) {
        var buffer = "";
        var isPart = false;
        while (x < grid.Width && char.IsDigit(grid.Items[x, y])) {
            buffer += grid.Items[x, y];
            if (!isPart) {
                foreach (var (nx, ny, ch) in grid.IterateNeighbours((x, y), includeDiagonals: true)) {
                    if (ch != '.' && !char.IsDigit(ch)) {
                        isPart = true;
                    }
                }
            }
            x += 1;
        }
        var value = int.Parse(buffer);
        return (value, x, isPart);
    }
    
    public static int SolveStar1(string inputFile = "day3/input.txt") {
        var sum = 0;
        var grid = new Grid<char>(File.ReadLines(inputFile).ToArray(), x => x);
        
        for (var y = 0; y < grid.Height; y++) {
            for (var x = 0; x < grid.Width; x++) {
                var ch = grid.Items[x, y];
                if (char.IsDigit(ch)) {
                    var (value, newX, isPart) = ReadNumberPart1(grid, x, y);
                    x = newX;
                    if (isPart) {
                        sum += value;
                    }
                }
            }
        }
        
        return sum;
    }

    public static int ReadNumberPart2(Grid<char> grid, int x, int y) {
        while (x > 0 && char.IsDigit(grid.Items[x - 1, y])) {
            x -= 1;
        }

        string buffer = "";
        while (x < grid.Width && char.IsDigit(grid.Items[x, y])) {
            buffer += grid.Items[x, y];
            x += 1;
        }

        return int.Parse(buffer);
    }
    
    public static int SolveStar2(string inputFile = "day3/input.txt") {
        var sum = 0;
        var grid = new Grid<char>(File.ReadLines(inputFile).ToArray(), x => x);

        foreach (var (x, y, ch) in grid.Enumerate()) {
            if (ch != '*') continue;
            var numbers = new List<int>();
            var currentNumberPos = (-1, -1);
            foreach (var (nx, ny, test) in grid.IterateNeighbours((x, y), includeDiagonals: true)) {
                if (!char.IsDigit(test)) {
                    currentNumberPos = (-1, -1);
                    continue;
                }

                if (currentNumberPos == (-1, -1) || currentNumberPos.Item2 != ny || nx > currentNumberPos.Item1 + 1) {
                    numbers.Add(ReadNumberPart2(grid, nx, ny));
                    
                }
                currentNumberPos = (nx, ny);
            }

            if (numbers.Count == 2) {
                sum += numbers[0] * numbers[1];
            }
        }
        
        return sum;
    }
}