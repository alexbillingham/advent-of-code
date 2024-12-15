
namespace advent_of_code_day_2
{
    public class Day2
    {
        const string PUZZLE_INPUT = "puzzle_input.txt";
        static void Main(string[] args)
        {
            List<List<int>> reports = ParseInput();
            System.Console.WriteLine($"Parsed {reports.Count} reports.");

            int numberSafeReports = CountSafeReports(reports);
            System.Console.WriteLine($"Valid safe reports: {numberSafeReports}");

            int numberSafeReportsProbDampen = CountSafeReports(reports, problem_dampener: true);
            System.Console.WriteLine($"Valid safe reports with problem dampener enabled: {numberSafeReportsProbDampen}");
        }

        public static int CountSafeReports(List<List<int>> reports, bool problem_dampener = false)
        {
            int numberSafeReports = 0;
            foreach (var report in reports)
            {
                report.ForEach(r => System.Console.Write($"{r} "));

                if (SafeReport(report))
                {
                    System.Console.Write("- Safe!\n");
                    numberSafeReports++;
                }
                else
                {
                    System.Console.Write("- Unsafe.\n");
                    if (problem_dampener)
                    {
                        for (int index = 0; index < report.Count; index++)
                        {
                            List<int> tempReport = report.ToList();
                            tempReport.RemoveAt(index);
                            if (SafeReport(tempReport))
                            {
                                numberSafeReports++;
                                break;
                            }
                        }
                    }
                }
            }
            return numberSafeReports;
        }

        public static bool SafeReport(List<int> report)
        {
            return (AllIncreasing(report) || AllDecreasing(report)) && ValidMinDifference(report, 1) && ValidMaxDifference(report, 3);
        }

        static bool ValidMinDifference(List<int> report, int minDifference)
        {
            for (int index = 1; index < report.Count(); index++)
            {
                if (Math.Abs(report[index - 1] - report[index]) < minDifference)
                {
                    return false;
                }
            }
            return true;
        }

        static bool ValidMaxDifference(List<int> report, int maxDifference, bool problem_dampener = false)
        {
            for (int index = 1; index < report.Count(); index++)
            {
                if (Math.Abs(report[index - 1] - report[index]) > maxDifference)
                {
                    return false;
                }
            }
            return true;
        }

        static bool AllIncreasing(List<int> report, bool problem_dampener = false)
        {
            for (int index = 1; index < report.Count(); index++)
            {
                if (report[index - 1] > report[index])
                {
                    return false;
                }
            }
            return true;
        }

        static bool AllDecreasing(List<int> report, bool problem_dampener = false)
        {
            for (int index = 1; index < report.Count(); index++)
            {
                if (report[index - 1] < report[index])
                {
                    return false;
                }
            }
            return true;
        }

        static List<List<int>> ParseInput(string filePath = PUZZLE_INPUT)
        {
            // Read contents
            var contents = File.ReadAllLines(filePath).ToList();

            List<List<int>> reports = new List<List<int>>();

            foreach (string report in contents)
            {
                // Split the report
                List<string> splitReport = report.Split(" ").ToList();
                // Convert to ints for easier handling
                List<int> intSplitReport = new List<int>();
                foreach (string item in splitReport)
                {
                    intSplitReport.Add(int.Parse(item));
                }
                reports.Add(intSplitReport);
            }

            return reports;
        }
    }
}