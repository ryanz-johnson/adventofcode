using System.Runtime.CompilerServices;

public class Day4 : Day
{
    public Day4() : base(4)
    {
    }

    public override void Solve()
    {
        base.Solve();
        puzzle1();
        puzzle2();
    }

    // each of the 8 directions and how it modifies the current cell
    // 0 = right
    // 1 = right down
    // 2 = down
    // 3 = left down
    // 4 = left
    // 5 = left up
    // 6 = up
    // 7 = right up
    private static readonly int[] dx = { 0, 1, 1, 1, 0, -1, -1, -1 };
    private static readonly int[] dy = { 1, 1, 0, -1, -1, -1, 0, 1 };

    private void puzzle1()
    {
        char[][] grid = File.ReadAllLines("C:\\Users\\johnsonryan\\source\\personal\\adventofcode\\adventofcode\\puzzle4input.txt")
                            .Select(line => line.ToCharArray())
                            .ToArray();
        string word = "XMAS";
        int found = 0;
        int rows = grid.Count();
        int cols = grid[0].Count();
        for (int i = 0; i < rows; i++) 
        {
            for (int j = 0; j < rows; j++)
            {
                for (int direction = 0; direction < 8; direction++)
                {
                    found += SearchWord(grid, word, i, j,direction) ? 1 : 0;
                }
            }
        }
        Console.WriteLine(found);
    }

    private void puzzle2()
    {
        char[][] grid = File.ReadAllLines("C:\\Users\\johnsonryan\\source\\personal\\adventofcode\\adventofcode\\puzzle4input.txt")
                            .Select(line => line.ToCharArray())
                            .ToArray();
        int count = CountXPattern(grid);
        Console.WriteLine(count);
    }

    private bool SearchWord(char[][] grid, string word, int x, int y, int direction)
    {
        int length = word.Length;
        int rows = grid.Length;
        int cols = grid[0].Length;
        for (int i = 0; i < length; i++)
        {
            int newX = x + i * dx[direction];
            int newY = y + i * dy[direction];

            if (newX < 0 || newY < 0 || newX >= rows || newY >= cols || grid[newX][newY] != word[i])
            {
                return false;
            }
        }
        return true;
    }

    private int CountXPattern(char[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int count = 0;

        for (int i = 1; i < rows - 1; i++)
        {
            for (int j = 1; j < cols - 1; j++)
            {
                if (grid[i][j] == 'A' && IsXPattern(grid, i, j))
                {
                    count++;
                }
            }
        }

        return count;
    }

    private bool IsXPattern(char[][] grid, int x, int y)
    {
        bool topLeft = false;
        bool bottomLeft = false;

        // check top left to bottom right diagonal
        if((grid[x - 1][y - 1] == 'S' && grid[x + 1][y + 1] == 'M') || (grid[x - 1][y - 1] == 'M' && grid[x + 1][y + 1] == 'S'))
        {
            topLeft = true;
        }
        // check bottom left to top right diagonal
        if((grid[x + 1][y - 1] == 'S' && grid[x - 1][y + 1] == 'M') || (grid[x + 1][y - 1] == 'M' && grid[x - 1][y + 1] == 'S'))
        {
            bottomLeft = true;
        }

        return topLeft && bottomLeft;
    }
}