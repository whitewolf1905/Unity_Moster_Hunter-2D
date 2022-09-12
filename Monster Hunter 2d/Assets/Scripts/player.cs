using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    private float moveForce = 11f;
    private float jumpForce = 10f;
    private float movementX;
    private bool isGround = true;

    public AudioSource jump;
    public AudioSource die;

    private Rigidbody2D myBody;
    private SpriteRenderer sr;

    private float minplayerX = -16.5f;
    private float maxplayerX = 16.5f;
    private Vector3 tempPos;

    // Start is called before the first frame update
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerJump();
    }

    private void FixedUpdate()
    {
        //PlayerJump();
    }


    void PlayerMovement()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;

        if (movementX > 0)
        {
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            sr.flipX = true;
        }

        tempPos = transform.position;

        if (transform.position.x < minplayerX)
        {
            tempPos.x = minplayerX;
        }

        if (transform.position.x > maxplayerX)
        {
            tempPos.x = maxplayerX;
        }

        transform.position = tempPos;

    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            isGround = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jump.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

        if (collision.gameObject.CompareTag("Monster"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverMenu");
        }
    }

}
