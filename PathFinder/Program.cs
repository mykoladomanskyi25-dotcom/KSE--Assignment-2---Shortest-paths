using PathFinder;
using PathFinder.MapGeneration;

var optionsToGenerate = new MapGeneratorOptions()
{
    Height = 10,
    Width = 100,
    //Noise = 0.3f 
    AddTraffic = true,
    
};

var generator = new MapGenerator(optionsToGenerate);
string[,]? map = generator.Generate();

var start = new Point(0,0);
var destination = new Point(optionsToGenerate.Width - 2,optionsToGenerate.Height - 2);

var bfs = new BreadthFirstSearch();
var (path, nodesVisited) = bfs.FindPath(map!, start, destination);


new MapPrinter().Print(map, path);

Console.WriteLine($"\nNodes Visited: {nodesVisited}");
Console.WriteLine($"Path length: {path.Count}");