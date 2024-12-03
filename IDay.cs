public class Day {
    private int dayNumber;
    public Day(int dayNumber)
    {
        this.dayNumber = dayNumber;
    }
    public virtual void Solve() 
    {
        Console.WriteLine("SOLVING DAY " + dayNumber);
    }
}