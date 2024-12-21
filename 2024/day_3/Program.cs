
using System.Text.RegularExpressions;

namespace advent_of_code_day_3
{
    public class Day3
    {
        const string PUZZLE_INPUT = "puzzle_input.txt";
        static void Main(string[] args)
        {
            var content = File.ReadAllText(PUZZLE_INPUT);
            var resultP1 = ParseCorruptedMemory(content);
            System.Console.WriteLine($"Parsed corrupted memory: {resultP1}");
            var resultP2 = ParseCorruptedMemory(content, doDontEnabled: true);
            System.Console.WriteLine($"Parsed corrupted memory enabled multiplications: {resultP2}");
        }

        public static int ParseCorruptedMemory(string corruptedMemory, bool doDontEnabled = false)
        {
            // Pattern to match mul(num,num)
            Regex REGEX_MUL = new Regex(@"mul\(\d+,\d+\)");
            if (doDontEnabled)
            {
                // Pattern to match all do(), dont() and mul(num,num)
                REGEX_MUL = new Regex(@"do\(\)|don't\(\)|mul\(\d+,\d+\)");
            }

            // Run the regex to get matches
            MatchCollection matchedMulCommands = REGEX_MUL.Matches(corruptedMemory);

            int result = 0;
            bool isEnabled = true;

            // Loop over each match
            foreach (Match match in matchedMulCommands)
            {
                switch (match.Value)
                {
                    // If the match is a do, enable the next mul
                    case "do()":
                        isEnabled = true;
                        break;
                    // If the match is a do, disable the next mul
                    case "don't()":
                        isEnabled = false;
                        break;
                    // Parse and run the mul if its enabled
                    default:
                        if (isEnabled)
                        {
                            result += ParseMulCommand(match.Value);
                        }
                        break;
                }
            }
            return result;
        }

        private static int ParseMulCommand(string mulCmd)
        {
            // Remove the surrounding mul and brackets
            var value = mulCmd.Replace("mul(", "");
            value = value.Replace(")", "");
            // Split into ints
            var splitMatch = value.Split(",");
            var value1 = int.Parse(splitMatch[0]);
            var value2 = int.Parse(splitMatch[1]);
            // Calculate the result
            return value1 * value2;
        }
    }
}