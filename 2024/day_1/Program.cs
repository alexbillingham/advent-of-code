
namespace advent_of_code_day_1
{
    public class Day1
    {
        const string PUZZLE_INPUT = "puzzle_input.txt";
        static void Main(string[] args)
        {
            LocationLists locationLists = ParseInput(PUZZLE_INPUT);
            Console.WriteLine($"Distance between lists = {DistanceBetweenLists(locationLists)}");
            Console.WriteLine($"List similarity score = {SimilarityScore(locationLists)}");
        }

        public class LocationLists
        {
            public List<int> leftList { get; set; }
            public List<int> rightList { get; set; }

            public LocationLists()
            {
                leftList = new List<int>();
                rightList = new List<int>();
            }
        }

        public static LocationLists ParseInput(string filePath)
        {
            // Read contents
            var contents = File.ReadAllLines(filePath).ToList();

            var locationLists = new LocationLists();

            // Split the puzzle input into both lists
            foreach (string item in contents)
            {
                var splitItem = item.Split("   ");
                locationLists.leftList.Add(int.Parse(splitItem[0]));
                locationLists.rightList.Add(int.Parse(splitItem[1]));
            }

            return locationLists;
        }

        public static int DistanceBetweenLists(LocationLists locationLists)
        {
            // Sort lists
            locationLists.leftList.Sort();
            locationLists.rightList.Sort();

            // Define total variable
            int result = 0;

            // Loop through the left list and work out the distance to the right list
            for (int i = 0; i < locationLists.leftList.Count(); i++)
            {
                result += Math.Abs(locationLists.leftList[i] - locationLists.rightList[i]);
            }

            return result;
        }

        public static int SimilarityScore(LocationLists locationLists)
        {
            // Sort lists
            locationLists.leftList.Sort();
            locationLists.rightList.Sort();

            int result = 0;

            for (int i = 0; i < locationLists.leftList.Count(); i++)
            {
                result += locationLists.leftList[i] * locationLists.rightList.Count(location_id => location_id == locationLists.leftList[i]);
            }

            return result;
        }
    }
}