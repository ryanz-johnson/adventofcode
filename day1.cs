public class Day1 : Day
{    
    public Day1() : base(1)
    {
    }
    public override void Solve() 
    {
        base.Solve();
        puzzle1(); 
        puzzle2();
    }
    
    public void puzzle1() 
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
        for (int i = 0; i < list1.Count; i++)
        {
            int diff = Math.Abs(list1[i] - list2[i]);
            distance += diff;
        }
        Console.WriteLine(distance);
    }

    public void puzzle2() 
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
            foreach (int num in list1)
            {
                if (list2.Contains(num))
                {
                    // count number of times num appears in list2
                    int count = list2.Count(x => x == num);
                    score += count * num;
                }
            }
            Console.WriteLine(score);
    }
}