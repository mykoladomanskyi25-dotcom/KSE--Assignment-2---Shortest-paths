using PathFinder;
using PathFinder.MapGeneration;

var optionsToGenerate = new MapGeneratorOptions()
{
    Height = 10,
    Width = 100,
    Noise = 0.5f,
    AddTraffic = true,
    TrafficSeed = 1234
};

var generator = new MapGenerator(optionsToGenerate);
string[,]? map = generator.Generate();

var start = new Point(0,0);
var destination = new Point(optionsToGenerate.Width - 2,optionsToGenerate.Height - 2);

var bfs = new BreadthFirstSearch();
var (path, nodesVisited) = bfs.FindPath(map!, start, destination);


new MapPrinter().Print(map, path);

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