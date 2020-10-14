using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float followSpeed = 2f;
    private Vector3 offset;
    [SerializeField] float distanceUp;
    [SerializeField] float distanceAway;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * followSpeed);
        //摄像机跟随
        //Vector3 targetPos = target.position + offset;
        //transform.position = Vector3.Slerp(transform.position, targetPos, followSpeed * Time.deltaTime);
        //Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, followSpeed * Time.deltaTime);
        //得到摄像机要移动的目标位置
        Vector3 targetPosition = target.position + Vector3.up * distanceUp - target.forward * distanceAway;
        //摄像机从当前位置移动到目标位置
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
        //摄像机要看向角色物体
        transform.LookAt(target);
    }
}
