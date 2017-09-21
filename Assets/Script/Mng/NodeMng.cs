using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMng : MonoBehaviour
{
    public int Node_Number;

    public int[,] _Nodetile;
    public GameObject[,] _Node;

    [SerializeField]
    GameObject NodePrefab;
    [SerializeField]
    GameObject RongNodePrefab;
    [SerializeField]
    GameObject NodeParents;
    // Use this for initialization
    void Start()
    {
        _Nodetile = new int[2, Node_Number];
        _Node = new GameObject[2, Node_Number];

        for (int i = 0; i < Node_Number; i++)
        {
            NodeCreate(i, Random.Range(0, 2));
            //Debug.Log("Nodetile" + i + " : " + _Nodetile[0, i] + "," + _Nodetile[1, i]);
        }

    }

    void NodeCreate(int Node_count, int F_Node_num)
    {
        _Nodetile[0, Node_count] = F_Node_num;
        _Nodetile[1, Node_count] = (F_Node_num + 1) % 2;

        if (F_Node_num.Equals(1))
        {
            _Node[0, Node_count] = Instantiate(NodePrefab, NodeParents.transform) as GameObject;
            _Node[0, Node_count].transform.localPosition = new Vector3(-1.7f,1.5f * Node_count);
            _Node[0, Node_count].transform.GetComponent<NodeType>().Type = Node_count + 1;
            _Node[1, Node_count] = Instantiate(RongNodePrefab, NodeParents.transform) as GameObject;
            _Node[1, Node_count].transform.localPosition = new Vector3(1.7f, 1.5f * Node_count);
            _Node[1, Node_count].transform.GetComponent<NodeType>().Type = Node_count + 1;
        }
        else
        {
            _Node[0, Node_count] = Instantiate(RongNodePrefab, NodeParents.transform) as GameObject;
            _Node[0, Node_count].transform.localPosition = new Vector3(-1.7f, 1.5f * Node_count);
            _Node[0, Node_count].transform.GetComponent<NodeType>().Type = Node_count + 1;
            _Node[1, Node_count] = Instantiate(NodePrefab, NodeParents.transform) as GameObject;
            _Node[1, Node_count].transform.localPosition = new Vector3(1.7f, 1.5f * Node_count);
            _Node[1, Node_count].transform.GetComponent<NodeType>().Type = Node_count + 1;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
