
public class Sequence : Node
{
    public override Status Process()
    {
        var status = base.Process();
        if (status == Status.RUNNING) return Status.RUNNING;

        _currentChild++;
        if (_currentChild >= _children.Count)
        {
            _currentChild = 0;
            return Status.SUCCESS;
        }

        return Status.RUNNING;

    }
}
