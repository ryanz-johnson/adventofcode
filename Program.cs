using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var program = new Program();
    }

    public Program()
    {
        int now = DateTime.Now.Day;
        for (int i = 1; i <= now; i++)
        {
            var dayType = Type.GetType($"Day{i}");
            if (dayType != null)
            {
                var dayInstance = Activator.CreateInstance(dayType);
                var solveMethod = dayType.GetMethod("Solve");
                solveMethod?.Invoke(dayInstance, null);
            }
        }
    }
}
