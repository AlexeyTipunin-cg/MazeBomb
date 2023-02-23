using System;
namespace Assets.Scripts.BehaviourTree
{
    public class Leaf : Node
    {
        private Func<Status> _processMethod;

        public Leaf(Func<Status> processMethod)
        {
            _processMethod = processMethod;
        }
        public override Status Process()
        {
            var status = _processMethod?.Invoke() ?? Status.FAILURE;
            return status;
        }
    }
}

