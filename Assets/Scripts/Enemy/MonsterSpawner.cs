using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    //private List<GameObject> monsters = new List<GameObject>();
    [SerializeField] private GameObject monster;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minSeparationTime;
    [SerializeField] private float maxSeparationTime;
    [SerializeField] private bool isLeftSide;


    private void Start()
    {
        StartCoroutine(spawnMonster());
    }

    private IEnumerator spawnMonster()
    {
        while (true) 
        { 
            yield return new WaitForSeconds(Random.Range(minSeparationTime, maxSeparationTime));
            GameObject go =Instantiate(monster, spawnPos.position, Quaternion.identity);
            if (isLeftSide)
            {
                go.transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }
}



