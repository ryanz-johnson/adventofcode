using System.Text.RegularExpressions;

public class Day3 : Day
{
    public Day3() : base(3)
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
        List<string> lines = new List<string>(File.ReadAllLines("C:\\Users\\johnsonryan\\source\\personal\\adventofcode\\adventofcode\\puzzle3input.txt"));
        int sum = 0;
        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        foreach(string input in lines)
        {
            sum += getSumOfLine(input, pattern);
        }
        Console.WriteLine(sum);
    }
    
    private void puzzle2() 
    {
        List<string> lines = new List<string>(File.ReadAllLines("C:\\Users\\johnsonryan\\source\\personal\\adventofcode\\adventofcode\\puzzle3input.txt"));
        string pattern = @"(?:mul\((\d{1,3}),(\d{1,3})\)|don't\(\)|do\(\))";
        List<Match> matches = new List<Match>(Regex.Matches(lines[0], pattern).Cast<Match>());

        for(int i = 1; i < lines.Count; i++)
        {
            matches.AddRange(Regex.Matches(lines[i], pattern).Cast<Match>());
        }

        bool enabled = true;
        int sum = 0;
        foreach(Match match in matches)
        {
            if(match.Value == "do()")
            {
                enabled = true;
            }
            else if(match.Value == "don't()")
            {
                enabled = false;
            }
            else if(enabled)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                sum += x * y;
            }
        }
        Console.WriteLine(sum);
    }
    

    static int getSumOfLine(string input, string pattern)
    {
        int sum = 0;
        MatchCollection matches = Regex.Matches(input, pattern);
        foreach (Match match in matches)
        {
            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);
            sum += x * y;
        }
        return sum;      
    }
}