namespace AdventOfCode.day2;

public class Colours {
    public int Red { get; set; } = 0;
    public int Green { get; set; } = 0;
    public int Blue { get; set; } = 0;

    public void SetColour(string colour, int count) {
        switch (colour) {
            case "red":
                Red = count;
                break;
            case "green":
                Green = count;
                break;
            case "blue":
                Blue = count;
                break;
        }
    }
}