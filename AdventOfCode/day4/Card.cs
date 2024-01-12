namespace AdventOfCode.day4;

public class Card {
    public int Number { get; init; }
    public int Multiplier { get; set; } = 1;
    public List<int> WinningNumbers { get; init; }
    public List<int> Picks { get; init; }
}