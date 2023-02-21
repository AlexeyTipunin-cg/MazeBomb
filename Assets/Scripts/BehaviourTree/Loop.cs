
public class Loop : Node
{
    public override Status Process()
    {
        var status = _children[_currentChild].Process();
        if (status == Status.RUNNING) return Status.RUNNING;

        _currentChild++;
        if (_currentChild >= _children.Count)
        {
            _currentChild = 0;
        }

        return Status.RUNNING;
    }
}
