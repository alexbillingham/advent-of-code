namespace TestAdventOfCode;

public class TestDay2
{
    [Fact]
    public void TestValidReport()
    {
        List<List<int>> reports = [new List<int> { 1, 3, 6, 7, 9 }];
        int numberSafeReports = advent_of_code_day_2.Day2.CountSafeReports(reports);
        Assert.Equal(expected: 1, actual: numberSafeReports);
    }

    [Fact]
    public void TestInValidReport()
    {
        List<List<int>> reports = [new List<int> { 1, 2, 7, 8, 9 }];
        int numberSafeReports = advent_of_code_day_2.Day2.CountSafeReports(reports);
        Assert.Equal(expected: 0, actual: numberSafeReports);
    }

    [Fact]
    public void TestInvalidReportNoIncrease()
    {
        List<List<int>> reports = [new List<int> { 8, 6, 4, 4, 1 }];
        int numberSafeReports = advent_of_code_day_2.Day2.CountSafeReports(reports);
        Assert.Equal(expected: 0, actual: numberSafeReports);
    }

    [Fact]
    public void TestProblemDampener()
    {
        List<List<int>> reports = [
            new List<int> { 7, 6, 4, 2, 1 },  // Safe without dampener
            new List<int> { 1, 2, 7, 8, 9 },  // Unsafe regardless any level removal 
            new List<int> { 9, 7, 6, 2, 1 },  // Unsafe regardless any level removal
            new List<int> { 1, 3, 2, 4, 5 },  // Safe by removing 3
            new List<int> { 8, 6, 4, 4, 1 },  // Safe by removing 4
            new List<int> { 1, 3, 6, 7, 9 },  // Safe without dampener
        ];
        int numberSafeReports = advent_of_code_day_2.Day2.CountSafeReports(reports);
        Assert.Equal(expected: 2, actual: numberSafeReports);
        int numberSafeReportsWithProbDampen = advent_of_code_day_2.Day2.CountSafeReports(reports, problem_dampener: true);
        Assert.Equal(expected: 4, actual: numberSafeReportsWithProbDampen);
    }
}
