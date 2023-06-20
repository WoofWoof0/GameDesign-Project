using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDogMove : MonoBehaviour
{
    Animator animator;
    CharacterController cc;
    [SerializeField] private TerrainGenerator terrainGenerator;
    private float speedRate = 3.0f;
    Vector3 move;

    void Awake()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        move = new Vector3(hor, 0, ver);

        Vector3 speed = move * speedRate;

        //look at move direction
        transform.LookAt(transform.position + move);

        cc.SimpleMove(speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, (Mathf.Clamp(transform.position.z, -18, 8)));//limit moving range

        //update animation
        UpdateAnim();

        terrainGenerator.SpawnTerrain(false, transform.position); //move then spawn every time instead of press W
    }

    void UpdateAnim()
    {
        //based on rigidbody velocity to play animation
        animator.SetFloat("Speed", cc.velocity.sqrMagnitude);
    }

    // kill player when touch water
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.name);
        if (hit.gameObject.name == "Water")
        {
            Destroy(gameObject);
        }
    }
}