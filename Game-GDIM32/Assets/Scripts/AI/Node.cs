using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public enum Status { SUCCESS, RUNNING, FAILURE};
    public Status status;
    public List<Node> children = new List<Node>();
    public int currentChild = 0;
    public string name; 

    public Node() { }
    public Node(string n)
    {
        name = n;
    }

    public void AddChild(Node n)
    {
        children.Add(n);
        //Must put in children in the order you want to execute the sequence
    }
}
