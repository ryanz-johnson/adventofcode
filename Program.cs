using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var day1 = new Day1();
        day1.Solve();

        var day2 = new Day2();
        day2.Solve();

        var day3 = new Day3();
        day3.Solve();
    }
}
