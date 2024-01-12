using AdventOfCode.day4;

namespace AdventOfCodeTests.day4;

[TestFixture]
[TestOf(typeof(Day4))]
public class Day4Tests {

    [Test]
    public void Star1ExampleInputTest() {
        var result = Day4.SolveStar1("day4/example.txt");
        Assert.That(result, Is.EqualTo(13));
    }
    
    [Test]
    public void Star2ExampleInputTest() {
        var result = Day4.SolveStar2("day4/example.txt");
        Assert.That(result, Is.EqualTo(30));
    }
}