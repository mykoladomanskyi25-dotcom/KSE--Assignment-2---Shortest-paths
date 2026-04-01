namespace PathFinder.MapGeneration;

public class PriorityQueue
{
    private List<(Point Item, double Priority)> _elements = new();
    public int Count => _elements.Count;

    private int GetParentIndex(int i) => (i - 1) / 2;
    private int GetLeftChildIndex(int i) => i * 2 + 1;
    private int GetRightChildIndex(int i) => i * 2 + 2;

    private void Swap(int index1, int index2)
    {
        var temp = _elements[index1];
        _elements[index1] = _elements[index2];
        _elements[index2] = temp;
    }

    public void Enqueue(Point point, int priority)
    {
        _elements.Add((point, priority));
        var surfaces =  _elements.Count - 1;
        while (surfaces > 0)
        {
            int parentIndex = GetParentIndex(surfaces);
            if (_elements[surfaces].Priority < _elements[parentIndex].Priority)
            {
                Swap(surfaces, parentIndex);
                surfaces = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    public Point Dequeue()
    {
        var bestElement = _elements[0];
        _elements[0] = _elements[_elements.Count - 1];
        _elements.RemoveAt(_elements.Count - 1);
        var currentIndex = 0;
        while (true)
        {
            int leftChildIndex = GetLeftChildIndex(currentIndex);
            int rightChildIndex = GetRightChildIndex(currentIndex);
            int smallestIndex = currentIndex;
            if (leftChildIndex < _elements.Count && _elements[leftChildIndex].Priority < _elements[smallestIndex].Priority)
            {
                smallestIndex = leftChildIndex;
            }

            if (rightChildIndex < _elements.Count &&
                _elements[rightChildIndex].Priority < _elements[smallestIndex].Priority)
            {
                smallestIndex = rightChildIndex;
            }
            if (smallestIndex == currentIndex)
            {
                break;
            }
            else
            {
                Swap(smallestIndex, currentIndex);
                currentIndex = smallestIndex;
            }
        }
        return bestElement.Item;
    }
}