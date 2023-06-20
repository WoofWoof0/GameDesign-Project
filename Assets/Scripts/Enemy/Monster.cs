using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float speed;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);//Move the transform in the direction and distance of translation
    }
}
