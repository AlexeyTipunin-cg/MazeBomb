using Assets.Scripts.BehaviourTree;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static Assets.Scripts.BehaviourTree.Node;

public class BotAgent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _distance;
    [SerializeField] private Transform[] _route;

    private BehaviourTree _behaviourTree;
    private WaitForSeconds _waitForSeconds;
    private AgentStatus _status = AgentStatus.IDLE;
    private enum AgentStatus { IDLE, RUNNING }

    private void Start()
    {
        _behaviourTree = new BehaviourTree();

        Loop loop = new Loop();
        Sequence route = new Sequence();
        for (int i = 0; i < _route.Length; i++)
        {
            var pos = _route[i].position;
            Leaf go = new Leaf(() => GoToNextPoint(pos));
            route.AddChild(go);
        }

        loop.AddChild(route);

        Sequence reverseRoute = new Sequence();
        for (int i = _route.Length - 1; i >= 0; i--)
        {
            var pos = _route[i].position;
            Leaf go = new Leaf(() => GoToNextPoint(pos));
            reverseRoute.AddChild(go);
        }

        loop.AddChild(reverseRoute);
        _behaviourTree.AddChild(loop);

        _waitForSeconds = new WaitForSeconds(Random.Range(0.5f, 1));
        StartCoroutine(Behave());
    }

    private Status GoToNextPoint(Vector3 point)
    {
        var distance = Vector3.Distance(point, transform.position);
        if (_status == AgentStatus.IDLE)
        {
            _agent.SetDestination(point);
            _status = AgentStatus.RUNNING;
        }
        else if (distance < _distance)
        {
            _status = AgentStatus.IDLE;
            return Status.SUCCESS;
        }

        return Status.RUNNING;
    }

    private IEnumerator Behave()
    {
        while (true)
        {
            _behaviourTree.Process();
            yield return _waitForSeconds;
        }
    }
}
