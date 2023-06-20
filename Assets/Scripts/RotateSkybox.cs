using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateSky();
    }

    public void RotateSky()
    {
        RenderSettings.skybox.SetFloat("_Rotation", 0.3f * Time.time);
    }
}
