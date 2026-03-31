namespace PathFinder.MapGeneration;

public class MapPrinter
{
    public void Print(string[,] maze)
    {
        PrintTopLine(maze);
        for (var row = 0; row < maze.GetLength(1); row++)
        {
            Console.Write($"{row}\t");
            for (var column = 0; column < maze.GetLength(0); column++)
            {
                Console.Write(maze[column, row]);
            }
            Console.WriteLine();
        }
    }

    public void Print(string[,] maze, List<Point> path)
    {
        PrintTopLine(maze);
        for (var row = 0; row < maze.GetLength(1); row++)
        {
            Console.Write($"{row}\t");
            for (var column = 0; column < maze.GetLength(0); column++)
            {
                Point currentPoint = new Point(column, row);
                if (currentPoint.Equals(path[0]))
                {
                    Console.Write("B");
                }
                else if (currentPoint.Equals(path[path.Count - 1]))
                {
                    Console.Write("A");
                }
                else if (path.Contains(currentPoint))
                {
                    // Console.ForegroundColor = ConsoleColor.Green;
                    // Console.Write(maze[column, row]);
                    // Console.ResetColor();

                    Console.Write(".");
                }
                else
                {
                    Console.Write(maze[column, row]);    
                }
                
            }
            Console.WriteLine();
        }
    }
    
    private void PrintTopLine(string [,] maze)
    {
        Console.Write($" \t");
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            Console.Write(i % 10 == 0? i / 10 : " ");
        }
    
        Console.Write($"\n \t");
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            Console.Write(i % 10);
        }
    
        Console.WriteLine("\n");
    }
}