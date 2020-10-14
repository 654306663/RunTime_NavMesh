using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo2Map : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        for (int i = -10; i <= 10; i++)
        {
            for (int j = -10; j <= 10; j++)
            {
                GameObject o = Instantiate(cubePrefab, transform);
                o.transform.localPosition = new Vector3(i * 3, 1, j * 3);
            }
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
