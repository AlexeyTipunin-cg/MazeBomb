using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Node
{
    public enum Status { SUCCESS, RUNNING, FAILURE }
    protected int _currentChild;
    protected List<Node> _children = new List<Node>();

    public void AddChild(Node child)
    {
        _children.Add(child);
    }

    public virtual Status Process()
    {
        return _children[_currentChild].Process();
    }
}
