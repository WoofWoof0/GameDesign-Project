using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogPolyart : MonoBehaviour
{
    [SerializeField] private TerrainGenerator terrainGenerator;

    ////[SerializeField] private float moveSpeed = 5.0f;
    //[SerializeField] private float rotateSpeed = 360.0f;
    //// float rotateMultiplier = 1;

    ////private Rigidbody rb;
    private Animator animator;
    private NavMeshAgent agent;
    ////private Vector3 moveAmount;

    //private Vector3 position;
    //[SerializeField] private Vector3 _rotation;

    void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();//get the animator on the current object
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        //MouseManager.Instance.OnMouseClicked += MovePlayer; //Singleton mode, register the method
    }

    // Update is called once per frame
    private void Update()
    {
        SwitchAnimation();
        terrainGenerator.SpawnTerrain(false, transform.position); //move then spawn every time instead of press W
    }

    private void SwitchAnimation()
    {
        animator.SetFloat("Speed", agent.velocity.sqrMagnitude);
    }

    //private void FixedUpdate()
    //{
    //    //rb.MovePosition(rb.position + moveAmount);
    //}


    /// <summary>
    /// Register this function to the OnMouseClicked event, and call this function when the event is enabled. Get target transform
    /// </summary>
    private void MovePlayer(Vector3 target)
    {
        //    //Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.5f, Input.GetAxis("Vertical")).normalized;
        //    //moveAmount = moveDirection * moveSpeed * Time.deltaTime * rotateMultiplier;

        //    //Quaternion targetRotation = Quaternion.FromToRotation(transform.forward, moveDirection) * transform.rotation;
        //    //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        //    //bool walkAnimation = moveDirection !=Vector3.zero;
        //    ////animator.SetBool("Walk_Anim", walkAnimation);

        //    //rotateMultiplier = Vector3.Angle(transform.forward, moveDirection) > 5.0f ? 0.75f : 1.0f;


        //    //if (Input.GetKey(KeyCode.W)) transform.Translate(Vector3.forward * agent.velocity.sqrMagnitude * Time.deltaTime);
        //    //if (Input.GetKey(KeyCode.S)) transform.Translate(Vector3.back * agent.velocity.sqrMagnitude * Time.deltaTime);

        //    //if (Input.GetKey(KeyCode.D)) _rotation = Vector3.up;
        //    //else if (Input.GetKey(KeyCode.A)) _rotation = Vector3.down;
        //    //else _rotation = Vector3.zero;
        //    //transform.Rotate(_rotation * rotateSpeed * Time.deltaTime);


        agent.destination = target;
    }
}
