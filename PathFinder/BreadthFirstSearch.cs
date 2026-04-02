using PathFinder.MapGeneration;

namespace PathFinder;

public class BreadthFirstSearch : IPathFinder
{
    public (List<Point>, int) FindPath(string[,] map, Point start, Point destination)
    {
            var queue = new Queue<Point>();
            var visited = new List<Point>();
            var origins = new Dictionary<Point, Point>();
            
            queue.Enqueue(start);
            visited.Add(start);
            
            
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                
                if (current.Equals(destination))
                {
                    break; 
                }
                
                var neighbours = MapGenerator.GetNeighbours(current.Column, current.Row, map, 1,true);
                
                foreach (var neighbour in neighbours)
                {
                    if (!visited.Contains(neighbour))
                    {
                        visited.Add(neighbour);
                        origins[neighbour] = current;
                        queue.Enqueue(neighbour);
                    }
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
            return (path, visited.Count);
            
    }
}