using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField]
    Transform ParentTr;
    [SerializeField]
    Bar BarSc;
    [SerializeField]
    CameraShake CameraShakeSc;
    [SerializeField]
    public GameObject[] NodePrefab = new GameObject[10];       // Prefab 노드들(올바르지 않는 노드들까지)

    [SerializeField]
    int nNode = 5;
    [SerializeField]            //올바른 노드 갯수(노드 재사용할때 5로 초기화해주기), (0이되면 노드 재사용)
    int nWronNode = 5;           //올바르지 않는 노드 갯수(노드 재사용할때 5로 초기화해주기), (0이되도 노드 재사용X)

    [HideInInspector]
    int TouchPos = 1;
    [HideInInspector]
    bool RightNode;
    [HideInInspector]
    bool LeftNode;
    [HideInInspector]
    GameObject FirstNode;
    [HideInInspector]
    GameObject SecNode;



    // Use this for initialization
    void Start()
    {
        ParentTr.localPosition = new Vector3(0f, ParentTr.localPosition.y, ParentTr.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f) && !BarSc.bGageAccess)
            {
                if (hit.transform.CompareTag("Node") && TouchPos.Equals(hit.transform.GetComponent<NodeType>().Type))
                {
                    if (BarSc.BarGams.transform.localScale.y > 1)
                        BarSc.GageVec3.y -= 0.01f;
                    LRNodeSelect();
                    nNode -= 1;
                    Respawn(hit.transform.gameObject);
                    SetNodePosition(FirstNode, SecNode);
                    ClearNode();
                }
                if (hit.transform.CompareTag("WrongNode") && TouchPos.Equals(hit.transform.GetComponent<NodeType>().Type))
                {
                    //Handheld.Vibrate();
                    CameraShakeSc.bCameraShake = true;
                    BarSc.GageVec3.y += 0.05f;
                    LRNodeSelect();
                    nWronNode -= 1;
                    Respawn(hit.transform.gameObject);
                    SetNodePosition(FirstNode, SecNode);
                    ClearNode();
                }
            }

        }
    }

    void LRNodeSelect()
    {
        int _Nodetile = Random.Range(0, 2);
        if (_Nodetile.Equals(0))
        {
            RightNode = true;
            LeftNode = false;
        }
        else
        {
            RightNode = false;
            LeftNode = true;
        }
    }
    void SetNodePosition(GameObject Target1, GameObject Target2)
    {
        if (RightNode)   //Target1 좌 , Target2 우
        {
            Target1.transform.localPosition =
                new Vector3(-1.7f, Target1.transform.localPosition.y, Target1.transform.localPosition.z);
            Target2.transform.localPosition =
                new Vector3(1.7f, Target1.transform.localPosition.y, Target1.transform.localPosition.z);
        }
        else if (!RightNode)
        {
            Target1.transform.localPosition =
                   new Vector3(1.7f, Target1.transform.localPosition.y, Target1.transform.localPosition.z);
            Target2.transform.localPosition =
                new Vector3(-1.7f, Target1.transform.localPosition.y, Target1.transform.localPosition.z);
        }
    }

    void Respawn(GameObject hit)
    {
        for (int i = 0; i < 10; i++)
        {
            if (TouchPos.Equals(NodePrefab[i].GetComponent<NodeType>().Type))
            {
                NodePrefab[i].transform.localPosition =
                    new Vector3(NodePrefab[i].transform.localPosition.x
                    , NodePrefab[i].transform.localPosition.y + 6f
                    , NodePrefab[i].transform.localPosition.z);

                if (FirstNode == null)
                {
                    FirstNode = NodePrefab[i];
                }
                else
                {
                    if (SecNode == null)
                        SecNode = NodePrefab[i];
                }
            }
            else
            {
                StartCoroutine(Move_Down(NodePrefab[i], 1.5f));
            }
        }

        TouchPos += 1;
        if (TouchPos.Equals(6))
            TouchPos = 1;
    }

    void ClearNode()
    {
        FirstNode = null;
        SecNode = null;
    }

    IEnumerator Move_Down(GameObject Target, float Hire)
    {
        float Top_y = Target.transform.localPosition.y - Hire;
        while (Top_y >= Target.transform.localPosition.y)
        {
            Target.transform.Translate(Vector3.down * Time.deltaTime * 5f);
            yield return null;
        }
        Target.transform.localPosition = new Vector3(Target.transform.localPosition.x, Top_y, Target.transform.localPosition.z);
    }
}
