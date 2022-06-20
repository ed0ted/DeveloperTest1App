namespace DeveloperTest1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<int> list = File.ReadAllLines(TryGetSolutionDirectoryInfo()+"/Files/10m.txt").Select(int.Parse).ToList();
            list.TrimExcess();
            int count = list.Count;
            //Console.WriteLine(count/2);
            Console.WriteLine("Max value: " + list.Max());
            Console.WriteLine("Min value: " + list.Min());
            if(count%2==0)
                Console.WriteLine("Median: " + 
                    (list[count / 2] + list[count+1/2]));            
            else
                Console.WriteLine("Median: " +
                    list[count / 2]);
            Console.WriteLine("Avarage: " + list.Average());
            int length_up=0;
            int length_down=0;
            int temp_up = list[0];
            int temp_down = list[0];
            int max_up=int.MinValue, max_down=int.MinValue;
            for(int i = 1; i < count; i++)
            {
                //if (list[i] > temp_up)
                //    length_up++;
                //else length_up = 0;

                _ = list[i] > temp_up ? length_up++ : length_up = 0;
                _ = list[i] < temp_up ? length_down++ : length_down = 0;

                max_up = length_up > max_up ? length_up : max_up;
                max_down = length_down > max_down ? length_down : max_down;
            }
            Console.WriteLine("Max rising consistency: " + max_up);
            Console.WriteLine("Max descending consistency: " + max_down);
        }
        public static DirectoryInfo TryGetSolutionDirectoryInfo(string currentPath = null)
        {
            var directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.Parent.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }
    }
}