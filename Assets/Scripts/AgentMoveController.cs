using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMoveController : MonoBehaviour
{
    [SerializeField] float speed = 5;
    private NavMeshAgent agent;
    private LineRenderer line;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        line = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (true)
        // {
        //     float h = Input.GetAxisRaw("Horizontal");
        //     float v = Input.GetAxisRaw("Vertical");

        //     agent.Move(new Vector3(h, 0, v) * speed * Time.deltaTime);
        //     return;
        // }

        //transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);

        if (agent.isStopped == false && agent.pathPending == false && Mathf.Abs(agent.remainingDistance) < 0.05f)
        {
            Debug.LogError("停止了");
            agent.isStopped = true;
        }
        else if (agent.isStopped == false)
        {
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform != null)
            {
                Debug.Log(hit.point);
                agent.isStopped = false;
                this.agent.SetDestination(hit.point);
            }
        }


        if (agent.path.corners.Length > 1)
        {
            line.positionCount = agent.path.corners.Length;
            line.SetPositions(agent.path.corners);
        }
    }

    ///// <summary>
    ///// 绘制移动路线
    ///// </summary>
    //void OnDrawGizmos()
    //{
    //    if (agent != null && agent.enabled == true)
    //    {
    //        var path = agent.path;
    //        // color depends on status
    //        Color c = Color.white;
    //        switch (path.status)
    //        {
    //            case UnityEngine.AI.NavMeshPathStatus.PathComplete:
    //                c = Color.white;
    //                break;

    //            case UnityEngine.AI.NavMeshPathStatus.PathInvalid:
    //                c = Color.red;
    //                break;

    //            case UnityEngine.AI.NavMeshPathStatus.PathPartial:
    //                c = Color.yellow;
    //                break;
    //        }
    //        // draw the path
    //        for (int i = 1; i < path.corners.Length; ++i)
    //            Debug.DrawLine(path.corners[i - 1], path.corners[i], c);
    //    }

    //}
    
}
