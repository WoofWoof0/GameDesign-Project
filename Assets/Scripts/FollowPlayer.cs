using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothness;

    // Update is called once per frame
    private void LateUpdate()
    {
        if(target != null)
        {
            Vector3 targetPosition = target.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness);
        } 
    }
}
