using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] Monster;

    private GameObject spawnedMoster;

    public Transform leftSpawn;
    public Transform rightSpawn;
    public float upPosition;

    private int RandomIndex;
    private int RandomSide;
    private int upDown;


    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }


    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));

            RandomIndex = Random.Range(0, Monster.Length);
            RandomSide = Random.Range(0, 2);
            upDown = Random.Range(0, 2);

            spawnedMoster = Instantiate(Monster[RandomIndex]);


            if (RandomSide == 0)
            {
                if (upDown == 0)
                {
                    spawnedMoster.transform.position = new Vector3(leftSpawn.position.x,
                    upPosition, 0);
                }
                else
                {
                    spawnedMoster.transform.position = new Vector3(leftSpawn.position.x,
                    leftSpawn.position.y, 0);
                }
                
                spawnedMoster.GetComponent<EnemyMovement>().speed = 10f;
            }
            else
            {
                if (upDown == 0)
                {
                    spawnedMoster.transform.position = new Vector3(rightSpawn.position.x,
                    upPosition, 0);
                }
                else
                {
                    spawnedMoster.transform.position = new Vector3(rightSpawn.position.x,
                    rightSpawn.position.y, 0);
                }
                
                spawnedMoster.GetComponent<EnemyMovement>().speed = -10f;
                spawnedMoster.GetComponent<EnemyMovement>().sr.flipX = true;
            }
        }
       
    }
}
