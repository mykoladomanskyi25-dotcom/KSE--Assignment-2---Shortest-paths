using PathFinder;
using PathFinder.MapGeneration;



int CountSpaces(string[,] arr)
    {
        int count = 0;

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                string s = arr[i, j];

                if (s != null)
                {
                    foreach (char c in s)
                    {
                        if (c == ' ')
                            count++;
                    }
                }
            }
        }

        return count;
    }

var optionsToGenerate = new MapGeneratorOptions()
{
    Height = 20,
    Width = 20,
    Noise = 0.2f,
    Seed = 1000,
    
    // Height = 10,
    // Width = 100,
    // Noise = 0.5f,
    //AddTraffic = true,
    //TrafficSeed = 13
};

var generator = new MapGenerator(optionsToGenerate);
string[,]? map = generator.Generate();

var start = new Point(0,0);
var destination = new Point(18,18);
//var destination = new Point(optionsToGenerate.Width - 2,optionsToGenerate.Height - 2);

var bfs = new BreadthFirstSearch();
var (path, nodesVisited) = bfs.FindPath(map!, start, destination);

// var dijkstra = new DijkstraShortestPath();
// var (path, nodesVisited) = dijkstra.FindPath(map!, start, destination);

// var astar = new AStarWeighted();
// var (path, nodesVisited) = astar.FindPath(map!, start, destination);
//
// List<Point> AStarPathWeighted =
// [
//     new Point(18, 18),
//     new Point(18, 17),
//     new Point(18, 16),
//     new Point(18, 15),
//     new Point(18, 14),
//     new Point(18, 13),
//     new Point(18, 12),
//     new Point(18, 11),
//     new Point(18, 10),
//     new Point(18, 9),
//     new Point(18, 8),
//     new Point(18, 7),
//     new Point(18, 6),
//     new Point(18, 5),
//     new Point(18, 4),
//     new Point(18, 3),
//     new Point(18, 2),
//     new Point(17, 2),
//     new Point(16, 2),
//     new Point(16, 3),
//     new Point(16, 4),
//     new Point(15, 4),
//     new Point(14, 4),
//     new Point(13, 4),
//     new Point(12, 4),
//     new Point(11, 4),
//     new Point(10, 4),
//     new Point(10, 3),
//     new Point(9, 3),
//     new Point(8, 3),
//     new Point(8, 2),
//     new Point(7, 2),
//     new Point(6, 2),
//     new Point(6, 1),
//     new Point(6, 0),
//     new Point(5, 0),
//     new Point(4, 0),
//     new Point(4, 1),
//     new Point(4, 2),
//     new Point(3, 2),
//     new Point(2, 2),
//     new Point(2, 3),
//     new Point(2, 4),
//     new Point(2, 5),
//     new Point(1, 5),
//     new Point(0, 5),
//     new Point(0, 4),
//     new Point(0, 3),
//     new Point(0, 2),
//     new Point(0, 1),
//     new Point(0, 0)
// ];

// List<Point> DijkstraPathUnweighted =
// [
//     new Point(18, 18),
//     new Point(17, 18),
//     new Point(16, 18),
//     new Point(15, 18),
//     new Point(14, 18),
//     new Point(13, 18),
//     new Point(12, 18),
//     new Point(11, 18),
//     new Point(10, 18),
//     new Point(10, 17),
//     new Point(10, 16),
//     new Point(10, 15),
//     new Point(10, 14),
//     new Point(10, 13),
//     new Point(10, 12),
//     new Point(9, 12),
//     new Point(8, 12),
//     new Point(8, 11),
//     new Point(8, 10),
//     new Point(7, 10),
//     new Point(6, 10),
//     new Point(6, 9),
//     new Point(6, 8),
//     new Point(6, 7),
//     new Point(6, 6),
//     new Point(6, 5),
//     new Point(6, 4),
//     new Point(5, 4),
//     new Point(4, 4),
//     new Point(4, 3),
//     new Point(4, 2),
//     new Point(3, 2),
//     new Point(2, 2),
//     new Point(2, 3),
//     new Point(2, 4),
//     new Point(2, 5),
//     new Point(1, 5),
//     new Point(0, 5),
//     new Point(0, 4),
//     new Point(0, 3),
//     new Point(0, 2),
//     new Point(0, 1),
//     new Point(0, 0)
// ];
new MapPrinter().Print(map, path);
// new MapPrinter().Print(map, AStarPathWeighted);

double totaltime = 0;
foreach (var p in path)
{
    if (p.Equals(start)) continue;
    string cell = map[p.Column, p.Row];

    int n;
    if (cell.Equals(" "))
    {
        n = 1;
    }
    else
    {
        n = int.Parse(cell);
    }
    
    double v = 60.0 - (n - 1.0) * 6.0;
    double t = 1.0 / v;
    totaltime = totaltime + t;
}

Console.WriteLine($"Total time: {totaltime:F2}");

Console.WriteLine($"\nNodes Visited: {nodesVisited}");
Console.WriteLine($"Path length: {path.Count}");

Console.WriteLine(CountSpaces(map));