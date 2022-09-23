using System.Collections.Generic;

public class Collections
{
    private List<int> _list;
    private Stack<int> _stack;
    private Queue<int> _queue;
    private Dictionary<string, int> _dict;
    private int[] _array;

    public void DoSomething()
    {
        _array = new int[] {1, 2, 3};
        _array[2] = 4;
        
        _list = new List<int>{1, 2, 3};
        _list[2] = 4;
        _list.Add(5); // {1, 2, 4, 5}
        _list.Remove(2); //  {1, 2, 5}

        _dict = new Dictionary<string, int>(){};
        _dict.Add("1", 1);
        _dict["1"] = 2;
        _dict.Remove("1");

        _stack = new Stack<int>();
        _stack.Push(1);
        var one = _stack.Pop();
    }
    
}