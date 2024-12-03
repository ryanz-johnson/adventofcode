﻿using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        puzzleday3();
        puzzleday3part2();
    }


    static void puzzleday3() 
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

    static void puzzleday3part2()
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
