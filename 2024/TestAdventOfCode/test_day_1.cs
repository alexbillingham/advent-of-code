namespace TestAdventOfCode;

public class TestDay1
{
    [Fact]
    public void TestDifferenceBetweenLists()
    {
        // 3   4
        // 4   3
        // 2   5
        // 1   3
        // 3   9
        // 3   3
        advent_of_code_day_1.Day1.LocationLists locationLists = new advent_of_code_day_1.Day1.LocationLists();
        locationLists.leftList = new List<int> { 3, 4, 2, 1, 3, 3 };
        locationLists.rightList = new List<int> { 4, 3, 5, 3, 9, 3 };
        int diffBetweenLists = advent_of_code_day_1.Day1.DistanceBetweenLists(locationLists);
        Assert.Equal(expected: 11, actual: diffBetweenLists);
    }

    [Fact]
    public void TestSimilarityScore()
    {
        // 3   4
        // 4   3
        // 2   5
        // 1   3
        // 3   9
        // 3   3
        advent_of_code_day_1.Day1.LocationLists locationLists = new advent_of_code_day_1.Day1.LocationLists();
        locationLists.leftList = new List<int> { 3, 4, 2, 1, 3, 3 };
        locationLists.rightList = new List<int> { 4, 3, 5, 3, 9, 3 };
        int listsSimilarityScore = advent_of_code_day_1.Day1.SimilarityScore(locationLists);
        System.Console.WriteLine($">>>>>>>>>> {listsSimilarityScore}");
        Assert.Equal(expected: 31, actual: listsSimilarityScore);
    }
}
