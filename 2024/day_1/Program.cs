
namespace advent_of_code_day_1
{
    class Day1
    {
        const string PUZZLE_INPUT = "puzzle_input.txt";
        static void Main(string[] args)
        {
            LocationLists locationLists = ParseInput(PUZZLE_INPUT);

            // Sort lists
            locationLists.leftList.Sort();
            locationLists.rightList.Sort();

            // Confirm both lists are equal length (probably dont need to do this oh well)
            if (locationLists.leftList.Count() != locationLists.rightList.Count())
            {
                Console.WriteLine($"Lists dont equal size. {locationLists.leftList.Count()} != {locationLists.rightList.Count()}");
                return;
            }

            DistanceBetweenLists(locationLists);
            SimilarityScore(locationLists);
        }

        class LocationLists
        {
            public List<int> leftList { get; set; }
            public List<int> rightList { get; set; }

            public LocationLists()
            {
                leftList = new List<int>();
                rightList = new List<int>();
            }
        }

        static LocationLists ParseInput(string filePath)
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

        static void DistanceBetweenLists(LocationLists locationLists)
        {
            // Define total variable
            int result = 0;

            // Loop through the left list and work out the distance to the right list
            for (int i = 0; i < locationLists.leftList.Count(); i++)
            {
                result += Math.Abs(locationLists.leftList[i] - locationLists.rightList[i]);
            }

            Console.WriteLine($"Distance between lists = {result}");
        }

        static void SimilarityScore(LocationLists locationLists)
        {
            int result = 0;

            for (int i = 0; i < locationLists.leftList.Count(); i++)
            {
                result += locationLists.leftList[i] * locationLists.rightList.Count(location_id => location_id == locationLists.leftList[i]);
            }

            Console.WriteLine($"List similarity score = {result}");
        }
    }
}