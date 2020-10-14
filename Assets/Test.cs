using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bool b = NavMesh.SamplePosition(target.position, out NavMeshHit hit, 10, NavMesh.AllAreas);
            Debug.LogError(b);
            target.position = hit.position;
        }
    }
}
