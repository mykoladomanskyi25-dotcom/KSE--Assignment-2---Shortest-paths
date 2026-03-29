namespace PathFinder.MapGeneration;

public class DijkstraShortestPath : IPathFinder
{
    public (List<Point>, int) FindPath(string[,] map, Point start, Point destination)
    {
        var queue = new PriorityQueue();
        var costs = new Dictionary<Point, double>();
        var origins = new Dictionary<Point, Point>();
        
        queue.Enqueue(start, 0);
        costs[start] = 0;
        
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            
            var neighbours = MapGenerator.GetNeighbours(current.Column, current.Row, map, 1,true);

            neighbours.Reverse();
            
            foreach (var neighbour in neighbours)
            {
                string cell = map[neighbour.Column, neighbour.Row];

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
                double newtime = costs[current] + t;

                if (!costs.ContainsKey(neighbour) || newtime < costs[neighbour] )
                {
                    costs[neighbour] = newtime;
                    origins[neighbour] = current;
                    queue.Enqueue(neighbour, newtime);
                }
            }
            
            if (current.Equals(destination))
            {
                break; 
            }
            
        }
        
        var path = new List<Point>();
        var currentPathPoint = destination;
            
        while (!currentPathPoint.Equals(start))
        {
            path.Add(currentPathPoint);
            currentPathPoint = origins[currentPathPoint];
        }
        path.Add(start);
        return (path, costs.Count);
    }
}