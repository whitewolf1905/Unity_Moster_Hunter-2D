using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Debug.Log("collision");
            Destroy(collision.gameObject);
        }
    }
}
