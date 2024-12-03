namespace adventofcode;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        puzzleday2();
    }

    static void puzzleday2()
    {
        List<string> lines = new List<string>(File.ReadAllLines("C:\\Users\\johnsonryan\\source\\personal\\adventofcode\\adventofcode\\day2input.txt"));

        // for each level, check if it is valid
        int valid = 0;
        foreach(string line in lines)
        {
            string[] parts = line.Split(" ");
            List<int> levels = new List<int>();
            foreach(string part in parts)
            {
                levels.Add(int.Parse(part.Trim()));
            }
            bool done = false;
            // check if the level is valid
            if(isValid(levels))
            {
                done = true;
                valid++;
            }
            if (!done) {
            // recheck level by removing one level
                for(int i = 0; i < levels.Count; i++)
                {
                    List<int> newLevels = new List<int>(levels);
                    newLevels.RemoveAt(i);
                    if(isValid(newLevels))
                    {
                        valid++;
                        break;
                    }
                }
            }
        }
        
        Console.WriteLine(valid);
    }
    static bool isValid(List<int> levels)
    {
        bool increasing = true;
        bool decreasing = true;
        for(int i = 0; i < levels.Count - 1; i++)
        {
            if(levels[i] > levels[i + 1])
            {
                increasing = false;
            }
            if(levels[i] < levels[i + 1])
            {
                decreasing = false;
            }
            if(!increasing && !decreasing)
            {
                return false;
            }
            if(Math.Abs(levels[i] - levels[i + 1]) > 3 || Math.Abs(levels[i] - levels[i + 1]) < 1)
            {
                return false;
            }
        }
        return true;
    }

    static void puzzle1secondHalf() 
    {
        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();
        string[] lines = File.ReadAllLines("C:\\Users\\johnsonryan\\source\\personal\\adventofcode\\adventofcode\\puzzle1input.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split("   ");
            list1.Add(int.Parse(parts[0].Trim()));
            list2.Add(int.Parse(parts[1].Trim()));
        }
        int score = 0;
        foreach(int num in list1)
        {
            if(list2.Contains(num))
            {
                // count number of times num appears in list2
                int count = list2.Count(x => x == num);
                score += count * num;
            }
        }
        Console.WriteLine(score);
    }


    static void puzzle1()
    {
        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();
        string[] lines = File.ReadAllLines("C:\\Users\\johnsonryan\\source\\personal\\adventofcode\\adventofcode\\puzzle1input.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split("   ");
            list1.Add(int.Parse(parts[0].Trim()));
            list2.Add(int.Parse(parts[1].Trim()));
        }

        list1.Sort();
        list2.Sort();
        int distance = 0;
        for(int i = 0; i < list1.Count; i++)
        {
            int diff = Math.Abs(list1[i] - list2[i]);
            distance += diff;
        }
        Console.WriteLine(distance);
    }
}
