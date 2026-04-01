namespace PathFinder.MapGeneration;

public class AStarWeighted : IPathFinder
{
    private int Heuristics(Point start, Point destination, string[,] map)
    {
        int distance = Math.Abs(start.Column - destination.Column) + Math.Abs(start.Row - destination.Row);
        return distance;
    }
    
    private int GetCost(Point start, Point destination, string[,] map)
    {
        if (map[destination.Column, destination.Row] == " ")
            return 1;
        if (map[start.Column, start.Row] == "█")
            return int.MaxValue;
        
        return int.Parse(map[destination.Column, destination.Row]);
    }
    
    public (List<Point>, int) FindPath(string[,] map, Point start, Point destination)
    {
        var queue = new PriorityQueue();
        var visited = new List<Point>();
        var costs = new Dictionary<Point, int>();
        var origins = new Dictionary<Point, Point>();
        
        queue.Enqueue(start, 0);
        costs[start] = 0;
        
        
        while (queue.GetCount() > 0)
        {
            var current = queue.Dequeue();

            if (current.Equals(destination))
            {
                break; 
            }
            
            if (visited.Contains(current))
            {
                continue;
            }
            visited.Add(current);
            
            var neighbours = MapGenerator.GetNeighbours(current.Column, current.Row, map, 1,true);
            
            foreach (var neighbour in neighbours)
            {
                if (!costs.ContainsKey(neighbour))
                {
                    costs.Add(neighbour, int.MaxValue);
                }
                
                int edgeCost = GetCost(current, neighbour, map);
                int heuristicsFunction = Heuristics(neighbour, destination, map);
                
                if (costs[neighbour] > costs[current] + edgeCost)
                {
                    costs[neighbour] = costs[current] + edgeCost;
                    origins[neighbour] = current;
                    int priority = costs[current] + edgeCost + heuristicsFunction;
                    queue.Enqueue(neighbour, priority);
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
        return (path, costs.Count);
    }
}