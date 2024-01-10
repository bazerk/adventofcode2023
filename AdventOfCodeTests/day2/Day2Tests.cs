using AdventOfCode.day2;

namespace AdventOfCodeTests.day2;

[TestFixture]
[TestOf(typeof(Day2))]
public class Day2Tests {

    [Test]
    public void Star1ExampleInputTest() {
        var result = Day2.SolveStar1("day2/example.txt");
        Assert.That(result, Is.EqualTo(8));
    }
    
    [Test]
    public void Star2ExampleInputTest() {
        var result = Day2.SolveStar2("day2/example.txt");
        Assert.That(result, Is.EqualTo(2286));
    }
}