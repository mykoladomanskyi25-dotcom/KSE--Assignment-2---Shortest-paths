namespace PathFinder.MapGeneration;

public class PriorityQueue
{
    private List<(Point Item, double Priority)> _elements = new();
    public int Count => _elements.Count;
    public void Enqueue(Point point, double priority)
    {
        _elements.Add((point, priority));
    }

    public Point Dequeue()
    {
        int bestIndex = 0;
        for (int i = 1; i < _elements.Count; i++)
        {
            if (_elements[i].Priority < _elements[bestIndex].Priority)
            {
                bestIndex = i;
            }
        }

        Point bestPoint = _elements[bestIndex].Item;
        _elements.RemoveAt(bestIndex);
        return bestPoint;
    }
}