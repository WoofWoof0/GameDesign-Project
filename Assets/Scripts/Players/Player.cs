using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Original crossy road player
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField] private TerrainGenerator terrainGenerator;

    private Animator animator;
    private bool isHopping;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();//get the animator on the current object
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isHopping)
        {
            animator.SetTrigger("hop");
            isHopping = true;

            float zDifference = 0; // if z does not change, it is always 0

            // make sure the player is on grid space because (zDifference + transform.position.z) is an integer 
            if (transform.position.z % 1 != 0) 
            {
                zDifference = Mathf.Round(transform.position.z) - transform.position.z;
            }
            MoveCharacter(new Vector3(1, 0, zDifference));
        }
        else if (Input.GetKey(KeyCode.A) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 0, -1));
        }
    }


    private void MoveCharacter(Vector3 difference)
    {
        animator.SetTrigger("hop");
        isHopping = true;
        transform.position = transform.position + difference;
        transform.position = new Vector3(transform.position.x, transform.position.y, (Mathf.Clamp(transform.position.z, -18, 8)));//limit moving range
        terrainGenerator.SpawnTerrain(false, transform.position); //move then spawn every time instead of press W
    }

    //we don't want to hop when the player is hopping
    public void FinishHop()
    {
        isHopping = false;
    }
}
