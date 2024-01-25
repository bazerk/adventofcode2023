using System.Text.RegularExpressions;
using AdventOfCode.helpers;

namespace AdventOfCode.day8;

public static class Day8 {
    private class Node {
        public string Label { get; init; }
        public string L { get; init; }
        public string R { get; init; }
    }
    
    private static (string, Dictionary<string, Node>) LoadData(string inputFile) {
        var lines = File.ReadAllLines(inputFile);
        var directions = lines[0];
        var nodes = new Dictionary<string, Node>();
        foreach (var line in lines.Skip(2)) {
            var match = Regex.Match(line, @"(?<label>[\w]+) = \((?<left>[\w]+), (?<right>[\w]+)\)");
            nodes[match.Groups["label"].Value] = new Node {
                Label = match.Groups["label"].Value,
                L = match.Groups["left"].Value,
                R = match.Groups["right"].Value,
            };
        }

        return (directions, nodes);
    }
    
    public static int SolveStar1(string inputFile = "day8/input.txt") {
        var steps = 0;
        var currentNode = "AAA";
        var directionStep = 0;
        var (directions, nodes) = LoadData(inputFile);
        while (currentNode != "ZZZ") {
            steps++;
            var node = nodes[currentNode];
            var direction = directions[directionStep];
            directionStep++;
            if (directionStep >= directions.Length) {
                directionStep = 0;
            }
            currentNode = direction == 'L' ? node.L : node.R;
        }
        
        return steps;
    }

    private static int FindLoopCount(string startNode, string directions, Dictionary<string, Node> nodes) {
        var steps = 0;
        var currentNode = startNode;
        var directionStep = 0;
        while (currentNode[2] != 'Z') {
            steps++;
            var node = nodes[currentNode];
            var direction = directions[directionStep];
            directionStep++;
            if (directionStep >= directions.Length) {
                directionStep = 0;
            }
            currentNode = direction == 'L' ? node.L : node.R;
        }
        
        return steps;
    }

    public static long SolveStar2(string inputFile = "day8/input.txt") {
        var (directions, nodes) = LoadData(inputFile);
        var currentNodes = new List<string>();
        foreach (var node in nodes.Keys) {
            if (node[2] == 'A') {
                currentNodes.Add(node);
            }
        }

        var loopCounts = new List<long>();
        foreach (var node in currentNodes) {
            loopCounts.Add(FindLoopCount(node, directions, nodes));
        }

        return loopCounts.LowestCommonMultiple();
    }
}