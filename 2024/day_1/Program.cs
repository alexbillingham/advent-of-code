
namespace advent_of_code_day_1
{
    class Day1
    {
        const string PUZZLE_INPUT = "puzzle_input.txt";
        static void Main(string[] args)
        {
            // Read contents
            var contents = File.ReadAllLines(PUZZLE_INPUT).ToList();

            // Define both lists
            var left_list = new List<int>();
            var right_list = new List<int>();

            // Split the puzzle input into both lists
            foreach (string item in contents)
            {
                var split_item = item.Split("   ");
                left_list.Add(int.Parse(split_item[0]));
                right_list.Add(int.Parse(split_item[1]));
            }

            // Sort lists
            left_list.Sort();
            right_list.Sort();

            // Confirm both lists are equal length (probably dont need to do this oh well)
            if (left_list.Count() != right_list.Count())
            {
                Console.WriteLine($"Lists dont equal size. {left_list.Count()} != {right_list.Count()}");
                return;
            }

            DistanceBetweenLists(left_list, right_list);
            SimilarityScore(left_list, right_list);
        }

        static void DistanceBetweenLists(List<int> left_list, List<int> right_list)
        {
            // Define total variable
            int result = 0;

            // Loop through the left list and work out the distance to the right list
            for (int i = 0; i < left_list.Count(); i++)
            {
                result += Math.Abs(left_list[i] - right_list[i]);
            }

            Console.WriteLine($"Distance between lists = {result}");
        }

        static void SimilarityScore(List<int> left_list, List<int> right_list)
        {
            int result = 0;

            for (int i = 0; i < left_list.Count(); i++)
            {
                result += left_list[i] * right_list.Count(location_id => location_id == left_list[i]);
            }

            Console.WriteLine($"List similarity score = {result}");
        }
    }
}