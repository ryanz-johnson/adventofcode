public class Day2: Day
{
    public Day2() : base(2)
    {
    }

    public override void Solve() 
    {
        base.Solve();
        puzzle1();
        puzzle2();
    }

    private void puzzle1() 
    {            
        List<string> lines = new List<string>(File.ReadAllLines("C:\\Users\\johnsonryan\\source\\personal\\adventofcode\\adventofcode\\day2input.txt"));
        int count = 0;
        foreach(string line in lines)
        {
            List<int> levels = new List<int>();
            string[] parts = line.Split(" ");
            foreach(string part in parts)
            {
                levels.Add(int.Parse(part));
            }
            if(isValid(levels))
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }

    private void puzzle2() 
    {    
        List<string> lines = new List<string>(File.ReadAllLines("C:\\Users\\johnsonryan\\source\\personal\\adventofcode\\adventofcode\\day2input.txt"));
        int count = 0;
        foreach(string line in lines)
        {
            List<int> levels = new List<int>();
            string[] parts = line.Split(" ");
            foreach(string part in parts)
            {
                levels.Add(int.Parse(part));
            }
            bool done = false;
            if(isValid(levels))
            {
                done = true;
                count++;
            }
            if (!done) {
                for(int i = 0; i< levels.Count; i++)
                {
                    List<int> newLevels = new List<int>(levels);
                    newLevels.RemoveAt(i);
                    if(isValid(newLevels))
                    {
                        count++;
                        break;
                    }
                }
            }

        }
        Console.WriteLine(count);   

    }

    private bool isValid(List<int> levels)
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
        return increasing || decreasing;
    }
}