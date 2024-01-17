using AdventOfCode.day6;

namespace AdventOfCodeTests.day6;

[TestFixture]
[TestOf(typeof(Day6))]
public class Day6Tests {
    [Test]
    public void Star1ExampleInputTest() {
        var result = Day6.SolveStar1("day6/example.txt");
        Assert.That(result, Is.EqualTo(288));
    }
    
    [Test]
    public void Star2ExampleInputTest() {
        var result = Day6.SolveStar2("day6/example.txt");
        Assert.That(result, Is.EqualTo(71503));
    }
}