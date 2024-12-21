namespace TestAdventOfCode;

public class TestDay3
{
    [Fact]
    public void TestParseMulti()
    {
        string input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        int multiResult = advent_of_code_day_3.Day3.ParseCorruptedMemory(input);
        Assert.Equal(expected: 161, actual: multiResult);
    }

    [Fact]
    public void TestParseMultiDoDont()
    {
        /*
        Enabled: mul(2,4) mul(8,5)
        Disabled: mul(5,5)
        */
        string input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
        int multiResult = advent_of_code_day_3.Day3.ParseCorruptedMemory(input, doDontEnabled: true);
        Assert.Equal(expected: 48, actual: multiResult);
    }
}
