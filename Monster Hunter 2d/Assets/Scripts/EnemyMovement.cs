using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 10f;
    private Rigidbody2D enemyBody;
    public SpriteRenderer sr;


    private void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        enemyBody.velocity = new Vector2(speed, enemyBody.velocity.y);
        if (transform.position.x < -20f || transform.position.x > 20f)
        {
            Destroy(gameObject);
        }
    }
}
