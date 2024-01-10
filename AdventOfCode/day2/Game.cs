namespace AdventOfCode.day2;

public class Game {
    public int Index { get; }
    public List<Colours> Rounds { get; }

    public Game(int index, List<Colours> rounds) {
        Index = index;
        Rounds = rounds;
    }
}
