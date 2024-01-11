using AdventOfCode.day3;

namespace AdventOfCodeTests.day3;

[TestFixture]
[TestOf(typeof(Day3))]
public class Day3Tests {

    [Test]
    public void Star1ExampleInputTest() {
        var result = Day3.SolveStar1("day3/example.txt");
        Assert.That(result, Is.EqualTo(4361));
    }
    
    [Test]
    public void Star2ExampleInputTest() {
        var result = Day3.SolveStar2("day3/example.txt");
        Assert.That(result, Is.EqualTo(467835));
    }
}