using AdventOfCode.day7;

namespace AdventOfCodeTests.day7;

[TestFixture]
[TestOf(typeof(Day7))]
public class Day7Tests {
    [Test]
    public void Star1ExampleInputTest() {
        var result = Day7.SolveStar1("day7/example.txt");
        Assert.That(result, Is.EqualTo(6440));
    }
    [Test]
    public void Star2ExampleInputTest() {
        var result = Day7.SolveStar2("day7/example.txt");
        Assert.That(result, Is.EqualTo(5905));
    }   
}
