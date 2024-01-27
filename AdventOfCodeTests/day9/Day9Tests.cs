using AdventOfCode.day9;

namespace AdventOfCodeTests.day9;

[TestFixture]
[TestOf(typeof(Day9))]
public class Day9Tests {

    [Test]
    public void Star1ExampleInputTest() {
        var result = Day9.SolveStar1("day9/example.txt");
        Assert.That(result, Is.EqualTo(114));   
    }
    
    [Test]
    public void Star2ExampleInputTest() {
        var result = Day9.SolveStar2("day9/example.txt");
        Assert.That(result, Is.EqualTo(2));   
    }
}