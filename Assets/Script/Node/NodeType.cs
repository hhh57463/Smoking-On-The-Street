using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeType : MonoBehaviour {

    public int Type;
    public GameObject Parent;


	// Use this for initialization
	void Start () {
        Parent = transform.parent.gameObject;

        for (int i = 0; i < 10; i++)
        {
            if (Parent.GetComponent<Node>().NodePrefab[i] == null)
            {
                Parent.GetComponent<Node>().NodePrefab[i] = gameObject;
                break;
            }
        }
    }
	
}
